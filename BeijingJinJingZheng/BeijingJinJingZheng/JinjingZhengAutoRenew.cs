using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JinjingZheng;
using Newtonsoft.Json;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.IO;
using NetDemo;

namespace BeijingJinJingZheng
{

    public class Carapplyarr
    {
        public string applyid;
        public string carid;
        public string cartype;
        public string engineno;
        public string enterbjend;
        public string enterbjstart;
        public string existpaper;
        public string licenseno;
        public string loadpapermethod;
        public string remark;
        public string status;
        public string syscode;
        public string syscodedesc;
        public string userid;
    }

    public class EnterCarInfo
    {
        public string carid;
        public string userid;
        public string licenseno;
        public string applyflag;
        public string applyid;
        public Carapplyarr[] carapplyarr;
    }

    public class EnterCartListResponse
    {
        public EnterCarInfo[] datalist;
        public string rescode;
        public string resdes;
    }



    public class JinjingZhengAutoRenew
    {

        public enum RunState
        {
            Captcha,
            EnterCarList,
            WaitingNet,
            Waiting,
        }

        



        UserConfig mConfig;
        Thread mWorkerThread;
        public RunState State = RunState.EnterCarList;
        private JinJingZhengAPI api = new JinJingZhengAPI();
        public bool IsRun
        {
            get
            {
                return mWorkerThread != null;
            }
        }


        public void Run(UserConfig config)
        {
            if (mWorkerThread != null) return;
            mConfig = config;
            LogWrapper.LogInfo("启动服务...");
            mWorkerThread = new Thread(_workerhread);
            mWorkerThread.Start();
            State = RunState.EnterCarList;
            
        }

        public void Stop()
        {
            if (mWorkerThread == null) return;
            mWorkerThread.Abort();
            mWorkerThread = null;
            LogWrapper.LogInfo("停止服务...");
        }

        //上一次检查时的进京证到期时间
        DateTime lastCarEndTime = DateTime.MinValue;

        void _workerhread()
        {


            //启动
            //1.获取列表
            //2.1 输出列表
            //2.2 检查是否需要申请
            //2.3 检查是否有申请成功的
            //3.等待N秒,跳到1
            //退出

            while (true) {

                switch (State) {
                    case RunState.EnterCarList:
                    {

                        // 获取进京证列表
                        State = RunState.WaitingNet;
                        LogWrapper.LogInfo("正在获取进京证列表...");
                            api.GetEnterCarList(mConfig.UserID, (result, ex) => {
                            if (ex == null) {
                                HandleCheckEnterCar(result as JObject);
                            }else{
                                HandleError("获取进京证列表失败", ex);
                            }
                        });
                    }
                    break;

                    case RunState.WaitingNet:
                    Thread.Sleep(1000);
                    break;
                    case RunState.Waiting:
                    LogWrapper.LogInfo("正在等待下次检查...");
                    Thread.Sleep(1000*mConfig.Interval);
                    State = RunState.EnterCarList;
                    break;
                }



            }
        }


        void HandleError(string prefix,System.Exception ex)
        {
            LogWrapper.LogError(prefix+":" + ex.Message);
            State = RunState.Waiting;
        }


        /// <summary>
        /// 识别验证码
        /// </summary>
        void HandleCaptcha(Carapplyarr carinfo)
        {
            LogWrapper.LogInfo("正在获取验证码...");
            State = RunState.WaitingNet;
            api.GetCaptcha((result,ex) => {
                if (result != null && result is Image) {
                    try {
                        LogWrapper.LogInfo("获取验证码成功，正在识别中...");
                        var img = result as Image;
                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        var bytes = ms.GetBuffer();
                        ms.Close();

                        string str = NetRecognizePic.CJY_RecognizeBytes(bytes, bytes.Length, mConfig.CJYUsername, Utils.MD5String(mConfig.CJYPassword), "96001", "1104", "0", "0", "");
                        JObject recognizeRet = JObject.Parse(str);

                        string err_no = recognizeRet["err_no"].ToString();
                        string err_str = recognizeRet["err_str"].ToString();
                        if (err_no == "0") {
                            string pic_id = recognizeRet["pic_id"].ToString();
                            string pic_str = recognizeRet["pic_str"].ToString();
                            img.Save("./code_" + pic_str + "_" + pic_id + ".jpeg");
                            img.Dispose();
                            LogWrapper.LogInfo("验证码识别成功：" + pic_str);
                            HandleSubmitpaper(carinfo, pic_str, pic_id);

                        } else {
                            LogWrapper.LogInfo("验证码识别失败：" + err_str);
                        }
                    } catch(Exception e) {
                        LogWrapper.LogInfo("识别验证码时，发生异常：" + e.ToString());
                    }

                    State = RunState.Waiting;

                } else {
                    LogWrapper.LogInfo("获取验证码失败：" + ex!=null ? ex.Message : "验证码图片无效.");
                    State = RunState.Captcha;
                }
            });
        }

        /// <summary>
        /// 申请进京证
        /// </summary>
        /// <param name="result"></param>
        void HandleCheckEnterCar(JObject result)
        {
            try
            {
                EnterCartListResponse rep = JsonConvert.DeserializeObject<EnterCartListResponse>(result.ToString());
                if (rep.rescode == "200") {

                    // 1.获取当前所有进京证信息
                    List<Carapplyarr> enterCarInfolist = new List<Carapplyarr>();
                    if (rep.datalist != null) {
                        foreach (var carInfo in rep.datalist) {
                            if (carInfo.carapplyarr != null) {
                                foreach (var entercar in carInfo.carapplyarr) {
                                    enterCarInfolist.Add(entercar);
                                }
                            }
                        }
                    }

                    if (enterCarInfolist.Count <= 0) {
                        LogWrapper.LogInfo("当前没有进京证信息,无法为您申请新的进京证!");
                        State = RunState.Waiting;
                        return;
                    }

                    // 2.检查是否需要申请新的进京证


                    // 计算当前进京证有效期
                    DateTime carStartTime = DateTime.MaxValue;
                    DateTime carEndTime = DateTime.MinValue;
                    DateTime carReadlEndTime = DateTime.MinValue;//进京证实际到期时间,不包过审核中的进京证
                    LogWrapper.LogInfoFormat("您现在共有 {0} 个进京证", enterCarInfolist.Count);
                    foreach (var entercar in enterCarInfolist) {
                        var enterbjstart = DateTime.Parse(entercar.enterbjstart);
                        var enterbjend = DateTime.Parse(entercar.enterbjend);
                        if (enterbjstart < carStartTime) carStartTime = enterbjstart;
                        if (entercar.status == "1" || entercar.status == "2") {
                            if (enterbjend > carEndTime) carEndTime = enterbjend;
                        }
                        
                        string statusStr = "状态:未知";
                        if (entercar.status == "0") {
                            statusStr = " 状态:审核失败";
                        } else if (entercar.status == "1") {
                            statusStr = "状态:审核成功";
                            if (enterbjend > carReadlEndTime) carReadlEndTime = enterbjend;
                        } else if (entercar.status == "2") {
                            statusStr = "状态:审核中";
                        }

                        LogWrapper.LogInfoFormat("进京证 {0} {1} 至 {2} {3}", entercar.licenseno, enterbjstart.ToString("yyyy-MM-dd"),
                        enterbjend.ToString("yyyy-MM-dd"), statusStr);
                    }




                    LogWrapper.LogInfoFormat("您当前进京证的有效期是 {0} 至 {1}", carStartTime.ToString("yyyy-MM-dd"),
                        carEndTime.ToString("yyyy-MM-dd"));


                    //如果进京证有效期的截止时间是今天,则申请新的进京证
                    var now = DateTime.Now;
                    if (carEndTime.Year == now.Year && carEndTime.Month == now.Month && carEndTime.Day == now.Day) {
                        // 申请新进京证
                        LogWrapper.LogInfo("您的进京证即将到期,正在为您申请新的进京证");

                        HandleCaptcha(enterCarInfolist[0]);

                        //State = RunState.Waiting;
                        return;
                    }

                    // 3.检查是否有新进京证申请成功
                    if (carReadlEndTime > lastCarEndTime) {
                        string str = string.Format("进京证审核成功 {0} {1} 至 {2}", enterCarInfolist[0].licenseno, carStartTime.ToString("yyyy-MM-dd"),
                        carReadlEndTime.ToString("yyyy-MM-dd"));
                        LogWrapper.LogInfo(str);
                        if (mConfig.EnableMail) {
                            string time = carStartTime.ToString("yyyy-MM-dd") + "-" + carReadlEndTime.ToString("yyyy-MM-dd");
                            if (SendMail("进京证审核成功:" + enterCarInfolist[0].licenseno, time)) {
                                LogWrapper.LogInfo("提醒邮件发送成功...");
                            } else {
                                LogWrapper.LogInfo("提醒邮件发送失败...");
                            }
                        }
                    }
                    lastCarEndTime = carReadlEndTime;


                    State = RunState.Waiting;


                } else {
                    LogWrapper.LogErrorFormat("获取进京证列表失败 {0}:{1}", rep.rescode, rep.resdes);
                }
                State = RunState.Waiting;

            } catch (Exception e)
            {
                LogWrapper.LogErrorFormat("获取进京证列表失败 {0}",e.Message);
            }
            

        }

        /// <summary>
        /// 申请进京证
        /// </summary>
        /// <param name="carinfo">车辆信息</param>
        /// <param name="pic_str">验证码文本</param>
        /// <param name="pic_id">验证码图片ID</param>
        void HandleSubmitpaper(Carapplyarr carinfo,string pic_str,string pic_id)
        {
            var enterBjStart = DateTime.Now.AddDays(1);
            LogWrapper.LogInfoFormat("正在申请进京证 进京日期 {0} 进京时间 {1} 天", enterBjStart.ToString("yyyy-MM-dd"), mConfig.InbjDuration);
            State = RunState.WaitingNet;
            api.Submitpaper(mConfig.UserID, mConfig.InbjDuration, enterBjStart, carinfo.licenseno, carinfo.engineno, mConfig.CarTypeCode,
                mConfig.VehicleType, Image.FromFile(mConfig.DrivingPhoto),
                Image.FromFile(mConfig.CarPhoto),
                mConfig.DriverName,
                mConfig.DriverLicenseno,
                Image.FromFile(mConfig.DriverPhoto),
                Image.FromFile(mConfig.PersonPhoto),
                carinfo.carid,
                mConfig.CarModel,
                mConfig.CarRegTime,
                pic_str,
                (result, ex) => {
                    var ret = result as JObject;
                    if (ex == null) {
                        string rescode = ret["rescode"].ToString();
                        string resdes = ret["resdes"].ToString();
                        if (rescode == "200") {
                            LogWrapper.LogInfo("进京证申请成功,正在审核中.");
                            if (SendMail("进京证申请成功,正在审核" + carinfo.licenseno, enterBjStart.ToString("yyyy-MM-dd")+" " + mConfig.InbjDuration+"天")) {
                                LogWrapper.LogInfo("提醒邮件发送成功...");
                            } else {
                                LogWrapper.LogInfo("提醒邮件发送失败...");
                            }
                        } else {
                            LogWrapper.LogError(string.Format("申请进京证失败.错误码:{0} 错误信息:{1}", rescode, resdes));
                            SendMail("进京证申请失败:" + rescode, resdes);
                            if (resdes.Contains("验证码错误")) {
                                // 验证码错误
                                LogWrapper.LogInfo("正在向超级鹰报告验证码错误信息...");
                                //try {
                                //    string str = NetRecognizePic.CJY_ReportError(mConfig.CJYUsername, Utils.MD5String(mConfig.CJYPassword), pic_id, "96001");
                                //    JObject reportError = JObject.Parse(str);
                                //    string err_no = reportError["err_no"].ToString();
                                //    string err_str = reportError["err_str"].ToString();
                                //    if (err_no == "0") {
                                //        LogWrapper.LogInfo("向超级鹰报告验证码错误信息成功!");
                                //    } else {
                                //        LogWrapper.LogInfo("向超级鹰报告验证码错误信息失败：" + err_str);
                                //    }
                                //} catch {
                                //    LogWrapper.LogInfo("向超级鹰报告验证码错误信息时，发生错误!");
                                //}

                                // 继续识别验证码
                                //HandleCaptcha(carinfo);
                            }
                        }

                    } else {
                        HandleError("申请进京证失败,网络异常", ex);
                    }

                    State = RunState.Waiting;

                });


        }

        public bool SendMail(string title, string content)
        {

            string useremail = mConfig.UserMailID;
            string password = mConfig.UserMailPassword;
            string to = mConfig.ToMail;
            MailMessage msg = new MailMessage(useremail, to);

            msg.Subject = title;
            msg.Body = content;
            msg.IsBodyHtml = false;
            msg.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            msg.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            msg.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();

            string[] usernameAndHost = useremail.Split('@');
            string host = "smtp." + usernameAndHost[1];
            string uname = usernameAndHost[0];
            client.Host = host;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(uname, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try {
                client.Send(msg);
                LogWrapper.LogError("邮件发送成功:");
                return true;
            } catch (Exception e) {
                LogWrapper.LogError("邮件发送失败:" + e.Message);
            }

            return false;
        }




    }
}
