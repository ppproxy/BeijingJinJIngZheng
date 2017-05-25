using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseResponse
{
        public string rescode;
        public string resdes;
        public bool IsScuessed()
        {
            return rescode == "200";
        }
}


public class LoginResponse : BaseResponse
{
    public string userid;
    public string userType;
}

public class GetUserCarsResponse : BaseResponse
{
    public Car[] list = new Car[0];
}





public class EnterCartListResponse : BaseResponse
{
    public EnterCarInfo[] datalist = new EnterCarInfo[0];
}