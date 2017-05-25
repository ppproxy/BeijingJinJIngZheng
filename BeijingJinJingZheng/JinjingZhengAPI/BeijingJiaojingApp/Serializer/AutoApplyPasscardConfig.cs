using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class AutoApplyPasscardConfig
{
    /// <summary>
    /// 驾驶证号
    /// </summary>
    public string DriverLicenseno;
    /// <summary>
    /// 车牌号
    /// </summary>
    public string CarNo;
    /// <summary>
    /// 续期天数
    /// </summary>
    public int days;
    /// <summary>
    /// 是否生效
    /// </summary>
    public bool enable;
}