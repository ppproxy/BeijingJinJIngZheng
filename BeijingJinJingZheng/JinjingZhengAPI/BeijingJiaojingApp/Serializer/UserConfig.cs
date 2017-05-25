using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class UserConfig
{
    public string PhoneNum;
    public string UserID;
    public Driver[] Drivers;
    public CarExtentInfo[] Cars;
    public AutoApplyPasscardConfig ApplyConfigs;
}