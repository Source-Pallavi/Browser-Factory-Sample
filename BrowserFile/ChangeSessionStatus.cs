using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BrowserFile
{
    class ChangeSessionStatus
    {
        static void Main(string[] args)
        {
            string reqString = "{\"status\":\"completed\", \"reason\":\"\"}";

            byte[] requestData = Encoding.UTF8.GetBytes(reqString);
            Uri myUri = new Uri(string.Format("https://www.browserstack.com/automate/sessions/<session-id>.json"));
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
            myWebRequest.ContentType = "application/json";
            myWebRequest.Method = "PUT";
            myWebRequest.ContentLength = requestData.Length;
            using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);

            NetworkCredential myNetworkCredential = new NetworkCredential("pallavidubey1", "EYS2N9avp4xvnPsHxvqw");
            CredentialCache myCredentialCache = new CredentialCache();
            myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myCredentialCache;

            myWebRequest.GetResponse().Close();
        }
    }
}

