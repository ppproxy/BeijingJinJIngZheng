using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

[Serializable]
public class CarExtentInfo
{
    /// <summary>
    /// 车牌号
    /// </summary>
    public string carno;


    // extens info
    /// <summary>
    /// 车辆型号
    /// </summary>
    public string model;
    /// <summary>
    /// 注册时间
    /// </summary>
    public string regTime;
    /// <summary>
    /// 车辆正面照片
    /// </summary>
    public Image carPhoto;
    /// <summary>
    /// 行驶证照片
    /// </summary>
    public Image drivingCardPhoto;

    /// <summary>
    /// 机动车类型 12=小型客车
    /// </summary>
    public string vehicletype;
}