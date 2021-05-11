using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace HTTPComm
{
    public class HTTPWebComm
    {
        string URL;
        string message;
        string resultStr;

        HttpWebRequest request;

        public void SetURL(string url)
        {
            URL = url;
        }

        public void setMessage(string msg)
        {
            message = msg;
        }

        public void Reqeust()
        {
            request = (HttpWebRequest)WebRequest.Create(URL);
            byte[] sendData =UTF8Encoding.UTF8.GetBytes(message);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            StreamWriter sw = new StreamWriter(request.GetRequestStream());


            sw.Write(message);
            sw.Close();
        }

        public string Response()
        {
            HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            resultStr = streamReader.ReadToEnd();

            streamReader.Close();
            httpWebResponse.Close();
            return resultStr;

        }
    }
}
