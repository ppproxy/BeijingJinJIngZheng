using JinjingZheng;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JinjingZheng
{

    public delegate void HTTPCallback(byte[] result, System.Exception ex = null);







    public class JinjingZhengHttpClient
    {



        private CookieContainer mCookiesContainer = new CookieContainer();

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }


        public void HttpGet(string url,string Referer, HTTPCallback cb)
        {
            try {


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = mCookiesContainer;
                request.Method = "GET";
                request.ProtocolVersion = new Version(1, 1);
                request.UserAgent = "BeiJingJiaoJing/1.1.1 (iPhone; iOS 10.1.1; Scale/2.00)";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "zh-Hans-CN;q=1");
                request.Referer = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/loadotherdrivers";
                request.KeepAlive = true;
                request.BeginGetResponse((result) => {
                    var response =  request.EndGetResponse(result);
                    var response_stream = response.GetResponseStream();
                    var buf = ReadResponseStream(response_stream);
                    response.Close();

                    cb?.Invoke(buf, null);

                }, request);
            } catch (WebException ex) {
                cb?.Invoke(null, ex);
            }
        }


        static byte[] ReadResponseStream(Stream st)
        {
            byte[] buf = new byte[1024];
            BinaryReader br = new BinaryReader(st);
            MemoryStream ms = new MemoryStream();
            int length = 0;
            do {
                length = st.Read(buf,0, buf.Length);
                if (length > 0) {
                    ms.Write(buf, 0, length);
                }
            } while (length > 0);
            return ms.GetBuffer();
        }


        public  void HttpPost(string url, string body, string contenttype, string referer, HTTPCallback cb)
        {
            byte[] request_body = Encoding.UTF8.GetBytes(body);
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
           

                request.Method = "POST";
                request.CookieContainer = mCookiesContainer;
                request.ProtocolVersion = new Version(1, 1);
                request.UserAgent = "BeiJingJiaoJing/1.1.1 (iPhone; iOS 10.1.1; Scale/2.00)";
                request.Accept = "application/json";
                request.ContentType = contenttype;
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "zh-Hans-CN;q=1");
                request.Referer = referer;
                request.KeepAlive = true;

                request.ContentLength = request_body.Length;
                request.GetRequestStream().Write(request_body, 0, request_body.Length);
                request.BeginGetResponse((result) => {
                    var response = request.EndGetResponse(result);
                    var response_stream = response.GetResponseStream();
                    var buf = ReadResponseStream(response_stream);
                    response.Close();
                    cb?.Invoke(buf, null);

                }, request);
            } catch (WebException ex) {
                cb?.Invoke(null, ex);
            }

        }

    }


}

