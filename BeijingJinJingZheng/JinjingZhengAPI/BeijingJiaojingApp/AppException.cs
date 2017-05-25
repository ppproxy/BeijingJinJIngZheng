using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AppException : Exception
{
    public string Rescode;
    public string Resdes;
    public AppException(string rescode,string resdes)
    {
        Rescode = rescode;
        Resdes = resdes;
    }
    public override string ToString()
    {
        return "Code:" + Rescode + "\r\nMessage:" + Resdes + "\r\n--------------\r\n" + base.ToString();
    }
}