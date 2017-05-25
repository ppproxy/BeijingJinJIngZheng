using System;
using System.Windows.Forms;
using JinjingZheng;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BeijingJinJingZheng
{
    public partial class FormLogin : Form
    {
        JinJingZhengAPI api = new JinJingZhengAPI();
        BeijingJiaojingApp app = new BeijingJiaojingApp();
        public FormLogin()
        {
            System.IO.Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            InitializeComponent();
            LogWrapper.OnRecvLog += OnRecvLog;
        }

        private void button_sendverfiy_Click(object sender, EventArgs e)
        {
            try
            {
                app.SendVefiyCode(textBox_phonenum.Text);
                MessageBox.Show("发送成功", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "发送失败");
            }


            //api.SendVerifyCode(textBox_phonenum.Text, "1", (result, ex) =>
            //{
            //    var ret = result as JObject;
            //    if (ex == null)
            //    {
            //        MessageBox.Show(ret["resdes"].ToString(), ret["rescode"].ToString());
            //    }
            //    else
            //    {
            //        MessageBox.Show(ex.Message, "短信发送失败");
            //    }
            //});
        }

        private void button_login_Click(object sender, EventArgs e)
        {


            try
            {
                app.Login(textBox_code.Text);
                textBox_uid.Text = "您的用户ID是:" + app.UserID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "登录失败");
            }


            //api.Login(textBox_phonenum.Text, textBox_code.Text, (result, ex) => {
            //    if (ex == null) {
            //        var ret = result as JObject;
            //        MessageBox.Show(ret["resdes"].ToString(), ret["rescode"].ToString());
            //        Debug.Write(result);
            //        RunInMainthread(() => {
            //            textBox_uid.Text = "您的用户ID是:" + ret["userid"];
            //        });

            //    } else {
            //        MessageBox.Show(ex.Message, "登陆失败");
            //    }
            //});
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {

            LoadConfig();

            if (mConfig.ActAsStartup) {
                button_run_Click(null, null);
            }
            if (mConfig.AutoHide) {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }

        }

        private void button_saveconfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void LoadConfig()
        {
            mConfig = UserConfig.FormFile("./config.json");
            textBox_userid.Text = mConfig.UserID;
            textBox_name.Text = mConfig.DriverName;
            textBox_driverlicenseno.Text = mConfig.DriverLicenseno;
            textBox_inbjduration.Text= mConfig.InbjDuration.ToString();
            textBox_cartypecode.Text= mConfig.CarTypeCode;
            textBox_vehicletype.Text= mConfig.VehicleType;
            textBox_drivingphoto.Text = mConfig.DrivingPhoto;
            textBox_carphoto.Text = mConfig.CarPhoto;
            textBox_driverphoto.Text= mConfig.DriverPhoto;
            textBox_personphoto.Text= mConfig.PersonPhoto;
            textBox_interval.Text= mConfig.Interval.ToString();
            checkBox_actonStartup.Checked = mConfig.ActAsStartup;
            checkBox_autostart.Checked = mConfig.RunOnSystemStartup;
            checkBox_autuhide.Checked = mConfig.AutoHide;
            checkBox_enablemail.Checked = mConfig.EnableMail;
            textBox_mailid.Text = mConfig.UserMailID;
            textBox_mailpassword.Text = mConfig.UserMailPassword;
            textBox_tomail.Text = mConfig.ToMail;
            textBox_carmodle.Text = mConfig.CarModel;
            textBox_carregtime.Text = mConfig.CarRegTime;
            textBox_cjy_username.Text = mConfig.CJYUsername;
            textBox_cjy_password.Text = mConfig.CJYPassword;

        }

        private void SaveConfig()
        {
            mConfig.UserID = textBox_userid.Text;
            mConfig.DriverName = textBox_name.Text;
            mConfig.DriverLicenseno = textBox_driverlicenseno.Text;
            mConfig.InbjDuration = int.Parse(textBox_inbjduration.Text);
            mConfig.CarTypeCode = textBox_cartypecode.Text;
            mConfig.VehicleType = textBox_vehicletype.Text;
            mConfig.DrivingPhoto = textBox_drivingphoto.Text;
            mConfig.CarPhoto = textBox_carphoto.Text;
            mConfig.DriverPhoto = textBox_driverphoto.Text;
            mConfig.PersonPhoto = textBox_personphoto.Text;
            mConfig.Interval = int.Parse(textBox_interval.Text);
            mConfig.ActAsStartup = checkBox_actonStartup.Checked;
            mConfig.AutoHide = checkBox_autuhide.Checked;
            if (mConfig.RunOnSystemStartup != checkBox_autostart.Checked) {
                mConfig.RunOnSystemStartup = checkBox_autostart.Checked;
                SetAutoRun(mConfig.RunOnSystemStartup);
            }

            mConfig.EnableMail = checkBox_enablemail.Checked;
            mConfig.UserMailID = textBox_mailid.Text;
            mConfig.UserMailPassword= textBox_mailpassword.Text;
            mConfig.ToMail= textBox_tomail.Text;
            mConfig.CarModel = textBox_carmodle.Text;
            mConfig.CarRegTime = textBox_carregtime.Text;
            mConfig.CJYUsername = textBox_cjy_username.Text;
            mConfig.CJYPassword = textBox_cjy_password.Text;

            mConfig.Save("./config.json");
        }

        void SetAutoRun(bool run)
        {
            if (run) //设置开机自启动  
{
                MessageBox.Show("设置开机自启动，需要修改注册表", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("JcShutdown", path);
                rk2.Close();
                rk.Close();
            } else //取消开机自启动  
              {
                MessageBox.Show("取消开机自启动，需要修改注册表", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("JcShutdown", false);
                rk2.Close();
                rk.Close();
            }
        }

        private UserConfig mConfig;
        private JinjingZhengAutoRenew auto = new JinjingZhengAutoRenew();

        void RunInMainthread(Action action)
        {
            try
            {
                this.BeginInvoke((Action)(delegate () {
                    action?.Invoke();
                }));
            }
            catch (System.Exception ex)
            {
                Debug.Write(ex.Message);
            }

        }

        private void button_run_Click(object sender, EventArgs e)
        {
            if (!auto.IsRun) {
                auto.Run(mConfig);
                button_run.Text = "停止";
            } else {
                auto.Stop();
                button_run.Text = "启动";
            }



        }

        void OnRecvLog(LogLevel lv, string info)
        {

            string log = string.Format("{0} [{1}]:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               lv.ToString(), info);

            RunInMainthread(() => {
                textBox_log.Text += log + "\r\n";
            });
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }



        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) {
                this.FormClosing -= new FormClosingEventHandler(this.FormLogin_FormClosing);
                auto.Stop();
                Application.Exit();//退出整个应用程序
            } else {
                e.Cancel = true;  //取消关闭事件,并最小化;
            }
        }
    }
}
