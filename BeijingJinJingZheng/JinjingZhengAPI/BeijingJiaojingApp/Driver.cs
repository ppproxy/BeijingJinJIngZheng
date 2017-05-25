using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


/// <summary>
/// 驾驶员
/// </summary>
[Serializable]
public class Driver
{
    /// <summary>
    /// 姓名
    /// </summary>
    public string name;
    /// <summary>
    /// 驾驶证号
    /// </summary>
    public string licenseno;
    /// <summary>
    /// 个人持身份证照片
    /// </summary>
    public Image photo;
    /// <summary>
    /// 驾驶证照片
    /// </summary>
    public Image drivingLicensePhoto;
}

