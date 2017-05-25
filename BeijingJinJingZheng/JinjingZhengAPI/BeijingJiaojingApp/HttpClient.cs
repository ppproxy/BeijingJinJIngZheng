using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


public class HttpClient
{
    public string UserAgent = "BeiJingJiaoJing/1.1.1 (iPhone; iOS 10.1.1; Scale/2.00)";
    public string AccepetEncoding = "gzip, deflate";
    public string AcceptLanguage = "zh-Hans-CN;q=1";

    private CookieContainer mCookiesContainer = new CookieContainer();

    public HttpClient()
    {

    }

    public string GetString(string url,string refrerer = "")
    {
        HttpWebRequest request = CreateBaseRequest(url,refrerer);
        request.Method = "GET";
        var rep = request.GetResponse();
        var repStream = rep.GetResponseStream();
        var reader = new StreamReader(repStream);
        var result = reader.ReadToEnd();
        reader.Close();
        return result;
    }

        
    public JObject GetJson(string url, string refrerer = "")
    {
        return JObject.Parse(GetString(url,refrerer));
    }


    public JObject PostJson(string url,string body,string refrerer = "")
        {
            HttpWebRequest request = CreateBaseRequest(url, refrerer);
            request.Method = "POST";
            request.Accept = "application/json";
            byte[] request_body = Encoding.UTF8.GetBytes(body);
            request.ContentLength = request_body.Length;
            request.GetRequestStream().Write(request_body, 0, request_body.Length);
        var rep = request.GetResponse();
            var repStream = rep.GetResponseStream();
            var reader = new StreamReader(repStream);
            var result = reader.ReadToEnd();
            reader.Close();
            return JObject.Parse(result);
        }



    private HttpWebRequest CreateBaseRequest(string url,string refreer = "")
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ProtocolVersion = new Version(1, 1);
        request.UserAgent = UserAgent;
        request.Headers.Add("Accept-Encoding", AccepetEncoding);
        request.Headers.Add("Accept-Language", AcceptLanguage);
        request.KeepAlive = true;
        request.Referer = refreer;

        return request;
    }

}