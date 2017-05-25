using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JinjingZheng
{

    public delegate void APICallBack(object result,System.Exception ex=null);
    
 

    public class JinJingZhengAPI
    {

        private JinjingZhengHttpClient http = new JinjingZhengHttpClient();


        /// <summary>
        /// send: {"phone":"xxxxxxx","regist"1"}
        /// rep:{"verification":"","resdes":"短信发送成功","rescode":"200"}
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="regist"></param>
        /// <param name="cb"></param>
        public void SendVerifyCode(string phone, string regist, APICallBack cb)
        {

            JObject o = new JObject();
            o["phone"] = phone;
            o["regist"] = regist;
            string url = "https://api.accidentx.zhongchebaolian.com/mobile/mobile/global/verification";
            http.HttpPost(url, o.ToString(), "application/json","", (result, ex) => {
                if (ex == null) {
                    try {
                        cb?.Invoke(JObject.Parse(Utils.BytesToString(result)));
                    } catch (Exception e) {
                        cb?.Invoke(null, e);
                    }
                } else {
                    cb?.Invoke(null,ex);
                }
            });
        }


        public  void Login(string phone,string valicode,APICallBack cb)
        {

            JObject o = new JObject();
            o["devicetype"] = "0";
            o["lon"] = "116.437342";
            o["phone"] = phone;
            o["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            o["source"] = "0";
            o["lat"] = "39.942857";
            o["token"] = Utils.CalcToken();
            o["deviceid"] = "eac96257058bbe516a14g58434459d25";
            o["citycode"] = "1101";
            o["appkey"] = "0791682354";
            o["valicode"] = valicode;
            o["vertype"] = "1";



            string url = "https://api.accidentx.zhongchebaolian.com/mobile/mobile/global/login";
            http.HttpPost(url, o.ToString(), "application/json","", (result, ex) => {
                if (ex == null) {
                    try {
                        cb?.Invoke(JObject.Parse(Utils.BytesToString(result)));
                    } catch (Exception e) {
                        cb?.Invoke(null, e);
                    }
                } else {
                    cb?.Invoke(null, ex);
                }
            });

        }


        public  void GetEnterCarList(string userid,APICallBack cb)
        {


            string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/entercarlist";
            string data = Utils.SerializeQueryString(new {
                userid = userid,
                appkey = "kkk",
                deviceid = "ddd",
                timestamp = Utils.GetTimestamp(),
                token = Utils.CalcToken(),
                appsource = "jjzx"
            });
            http.HttpPost(url, data, "application/x-www-form-urlencoded; charset=UTF-8", 
                "https://api.jinjingzheng.zhongchebaolian.com/enterbj/jsp/enterbj/index.jsp", (result, ex) => {
                if (ex == null) {
                    try {
                        cb?.Invoke(JObject.Parse(Utils.BytesToString(result)));
                    } catch (Exception e) {
                        cb?.Invoke(null,e);
                    }
                    
                } else {
                    cb?.Invoke(null, ex);
                }
            });
        }


        /// <summary>
        /// 申请进京证
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="inbjduration">进京时长(天)</param>
        /// <param name="inbjtime">进京时间</param>
        /// <param name="licenseno">车牌号</param>
        /// <param name="engineno">引擎号码</param>
        /// <param name="cartypecode">号牌类型 02:小型汽车</param>
        /// <param name="vehicletype">机动车类型 12:小型客车</param>
        /// <param name="drivingphoto">行驶证正面照片</param>
        /// <param name="carphoto">车辆正面照片</param>
        /// <param name="drivername">驾驶员姓名</param>
        /// <param name="driverlicenseno">驾驶证号</param>
        /// <param name="driverphoto">驾驶证照片</param>
        /// <param name="personphoto">本人持身份证照</param>
        /// <param name="carid"></param>
        /// <param name="carmodel">车辆型号</param>
        /// <param name="carregtime">注册时间</param>
        /// <param name="cb"></param>
        public  void Submitpaper(string userid,int inbjduration,DateTime inbjtime,
            string licenseno,string engineno,string cartypecode,string vehicletype, Image drivingphoto,
            Image carphoto,string drivername,string driverlicenseno, Image driverphoto, Image personphoto,string carid,
            string carmodel,string carregtime,string code, APICallBack cb)
        {

            string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/submitpaper";
            string data = Utils.SerializeQueryString(new {
                appsource = "jjzx",
                hiddentime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                inbjentrancecode1 = "05",
                inbjentrancecode = "19",
                inbjduration = inbjduration.ToString(),
                inbjtime = inbjtime.ToString("yyyy-MM-dd"),
                appkey = "",
                deviceid = "",
                token = "",
                timestamp = "",
                userid = userid,
                licenseno = licenseno,
                engineno = engineno,
                cartypecode = cartypecode,
                vehicletype = vehicletype,
                drivingphoto = "IMGDRIVINGPHOTO",
                carphoto = "IMGCARPHOTO",
                drivername = drivername,
                driverlicenseno = driverlicenseno,
                driverphoto = "IMGDRIVERPHOTO",
                personphoto = "IMGPERSONPHOTO",
                gpslon = "",
                gpslat = "",
                phoneno = "",
                imei = "",
                imsi = "",
                carid = carid,
                carmodel = carmodel,
                carregtime = carregtime,
                envGrade = "3",
                code = code.ToLower().Trim(),
                sign = "1e58feb9f557453d82d1b39bf59b663d"
            });

            data = data.Replace("IMGDRIVINGPHOTO", Utils.Image2Base64(drivingphoto));
            data = data.Replace("IMGCARPHOTO", Utils.Image2Base64(carphoto));
            data = data.Replace("IMGDRIVERPHOTO", Utils.Image2Base64(driverphoto));
            data = data.Replace("IMGPERSONPHOTO", Utils.Image2Base64(personphoto));



            http.HttpPost(url, data, "application/x-www-form-urlencoded; charset=UTF-8",
                "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/loadotherdrivers",
                (result, ex) => {
                if (ex == null) {
                    try {
                        cb?.Invoke(JObject.Parse(Utils.BytesToString(result)));
                    } catch (Exception e) {
                        cb?.Invoke(null, e);
                    }
                } else {
                    cb?.Invoke(null, ex);
                }
            });

        }


        public  Image GetCaptcha(APICallBack cb)
        {

            string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/getCaptcha?0." + Utils.GetTimestamp();
            string referer = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/loadotherdrivers";
            http.HttpGet(url, referer, (result, ex) => {
                if (ex == null) {
                    Image img = Image.FromStream(new MemoryStream(result));
                    cb?.Invoke(img, null);
                } else {
                    cb?.Invoke("", ex);
                }

            });

            return null;
        }

        public void GetUserCarList(string userid,APICallBack cb)
        {
            string url = "https://api.accidentx.zhongchebaolian.com/mobile/mobile/global/getusercarlist?appkey=0791682354&dicver=0&sn=c9606ab5ebbab0ae302215156675ab36&userid=" + userid;
            http.HttpGet(url, "", (bytes, ex) => {
                if (ex != null)
                {
                    string json = Utils.BytesToString(bytes);
                    cb?.Invoke(JObject.Parse(json), null);
                }
                else {
                    cb?.Invoke(null, ex);
                }
            });
        }
    }




}
