using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public enum PassCardState
{
    /// <summary>
    /// 审核失败
    /// </summary>
    Invalid = 0,
    /// <summary>
    /// 有效
    /// </summary>
    Ok = 1,
    /// <summary>
    /// 审核中
    /// </summary>
    Verifying,
}

/// <summary>
/// 进京证
/// </summary>
public class PassCard
{
    /// <summary>
    /// 车牌号
    /// </summary>
    public string carno;

    public DateTime StartTime;
    public int days;
    public PassCardState status;
}
