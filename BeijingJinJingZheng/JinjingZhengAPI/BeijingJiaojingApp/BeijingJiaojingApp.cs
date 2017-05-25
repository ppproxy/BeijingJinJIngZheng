using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JinjingZheng;

public class BeijingJiaojingApp
{
    public string PhoneNumber {get; private set;}
    public string UserID { get; private set; }

    /// <summary>
    /// 发送验证码
    /// </summary>
    /// <param name="phone">手机号</param>
    public void SendVefiyCode(string phone)
    {
        string url = "https://api.accidentx.zhongchebaolian.com/mobile/mobile/global/verification";
        JObject o = new JObject();
        o["phone"] = phone;
        o["regist"] = "1";
        var jobj = mHttpClient.PostJson(url, o.ToString());
        var ret = JsonConvert.DeserializeObject<BaseResponse>(jobj.ToString());
        ThorwExp(ret);
        PhoneNumber = phone;
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="valicode">收到的验证码</param>
    public void Login(string valicode)
    {
        JObject o = new JObject();
        o["devicetype"] = "0";
        o["lon"] = "116.437342";
        o["phone"] = PhoneNumber;
        o["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        o["source"] = "0";
        o["lat"] = "39.942857";
        o["token"] = JinjingZheng.Utils.CalcToken();
        o["deviceid"] = "eac96257058bbe516a14g58434459d25";
        o["citycode"] = "1101";
        o["appkey"] = "0791682354";
        o["valicode"] = valicode;
        o["vertype"] = "1";
        string url = "https://api.accidentx.zhongchebaolian.com/mobile/mobile/global/login";
        var jobj = mHttpClient.PostJson(url, o.ToString());
        var ret = JsonConvert.DeserializeObject<LoginResponse>(jobj.ToString());
        ThorwExp(ret);
        UserID = ret.userid;
    }

    public void LoginWithUserID(string userID)
    {
        UserID = userID;
    }


    public PassCard[] GetPassCards()
    {
        string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/entercarlist";
        string data = JinjingZheng.Utils.SerializeQueryString(new
        {
            userid = UserID,
            appkey = "kkk",
            deviceid = "ddd",
            timestamp = JinjingZheng.Utils.GetTimestamp(),
            token = JinjingZheng.Utils.CalcToken(),
            appsource = "jjzx"
        });

        var jobj = mHttpClient.PostJson(url, data);
        var ret = JsonConvert.DeserializeObject<EnterCartListResponse>(jobj.ToString());
        ThorwExp(ret);
        List<PassCard> cards = new List<PassCard>();
        if (ret.datalist != null) {
            foreach (var carinfo in ret.datalist) {
                if (carinfo.carapplyarr != null) {
                    foreach (var entercar in carinfo.carapplyarr) {
                        PassCard card = new PassCard();
                        card.carno = entercar.licenseno;
                        card.StartTime = DateTime.Parse(entercar.enterbjstart);
                        card.days = (DateTime.Parse(entercar.enterbjend) - card.StartTime).Days;
                        card.status = (PassCardState)(int.Parse(entercar.status));
                        cards.Add(card);
                    }
                }
            }
        }
        return cards.ToArray();
    }

    public Car[] GetCars()
    {
        string url = "https://api.accidentx.zhongchebaolian.com/mobile/mobile/global/getusercarlist?appkey=0791682354&dicver=0&sn=c9606ab5ebbab0ae302215156675ab36&userid=" + UserID;
        var jobj = mHttpClient.GetJson(url);
        var ret = JsonConvert.DeserializeObject<GetUserCarsResponse>(jobj.ToString());
        ThorwExp(ret);
        return ret.list;
    }


    /// <summary>
    /// 申请进京证
    /// </summary>
    /// <param name="car">车辆信息</param>
    /// <param name="driver">驾驶员信息</param>
    /// <param name="starTime">开始时间</param>
    /// <param name="days">天数</param>
    public void ApplyPassCard(Car car,Driver driver,DateTime starTime,int days)
    {
        string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/submitpaper";
        string data = Utils.SerializeQueryString(new
        {
            appsource = "jjzx",
            hiddentime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            inbjentrancecode1 = "05",
            inbjentrancecode = "19",
            inbjduration = days.ToString(),
            inbjtime = starTime.ToString("yyyy-MM-dd"),
            appkey = "",
            deviceid = "",
            token = "",
            timestamp = "",
            userid = UserID,
            licenseno = car.carno,
            engineno = car.engineno,
            cartypecode = car.cartype,
            vehicletype = car.extInfo.vehicletype,
            drivingphoto = "IMGDRIVINGPHOTO",
            carphoto = "IMGCARPHOTO",
            drivername = driver.name,
            driverlicenseno = driver.licenseno,
            driverphoto = "IMGDRIVERPHOTO",
            personphoto = "IMGPERSONPHOTO",
            gpslon = "",
            gpslat = "",
            phoneno = "",
            imei = "",
            imsi = "",
            carid = car.remark,
            carmodel = car.extInfo.model,
            carregtime = car.extInfo.regTime,
            envGrade = "3",
            code = "",
            sign = "1e58feb9f557453d82d1b39bf59b663d"
        });

        data = data.Replace("IMGDRIVINGPHOTO", Utils.Image2Base64(car.extInfo.drivingCardPhoto));
        data = data.Replace("IMGCARPHOTO", Utils.Image2Base64(car.extInfo.carPhoto));
        data = data.Replace("IMGDRIVERPHOTO", Utils.Image2Base64(driver.drivingLicensePhoto));
        data = data.Replace("IMGPERSONPHOTO", Utils.Image2Base64(driver.photo));

        var jobj = mHttpClient.PostJson(url, data);
        var ret = JsonConvert.DeserializeObject<BaseResponse>(jobj.ToString());
        ThorwExp(ret);
    }
    HttpClient mHttpClient = new HttpClient();

    private static void ThorwExp(BaseResponse rep)
    {
        if (!rep.IsScuessed())
        {
            throw new AppException(rep.rescode, rep.resdes);
        }
    }


  
    


}
