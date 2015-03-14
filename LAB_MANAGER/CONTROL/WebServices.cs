using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Security;
using System.Security.Cryptography;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Windows;

namespace LAB_MANAGER.CONTROL
{
    class WebServices
    {
        string sttpostHTTPS;
        public static string errorHTTPS;
        #region Local Methods
        /*public static string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            req.Proxy = new System.Net.WebProxy(URI, true);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }*/

        /*public static string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Proxy = new System.Net.WebProxy(URI, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }*/

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Local Methods

        #region Event Calls
        // hash password truoc khi gui len server
        public static string hashpass(string refpass, ref bool ckchass)
        {
            string hassstring = null;
            using (MD5 md5Hash = MD5.Create())
            {
                hassstring = GetMd5Hash(md5Hash, refpass);

                //Console.WriteLine("The MD5 hash of " + refpass + " is: " + hash + ".");

                //Console.WriteLine("Verifying the hash...");
                ckchass = VerifyMd5Hash(md5Hash, refpass, hassstring);
                /*if (VerifyMd5Hash(md5Hash, refpass, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }*/
            }
            return hassstring;
        }

        //  gui thong tin POST len server
        public static string POST(ref bool errorW, ref string errorWEBS, string Url, params string[] postdata)
        {
            string result = string.Empty;
            string data = string.Empty;
            string tem = null;
            errorW = false;
            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();

            /*if (postdata.Length < 2)
            {
                MessageBox.Show("Parameters must be even , \"user\" , \"value\" , ... etc", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }*/
            //string name = null;
            for (int i = 0; i < postdata.Length; i += 2)
            {
                data += string.Format("&{0}={1} ", postdata[i], postdata[i + 1]);
            }
            //string tem = "json="; 
            data = data.Remove(0, 1);
            //tem += System.Net.WebUtility.HtmlDecode(data);
            //data = tem;
            tem = null;
            //Console.WriteLine(data);
            byte[] bytesarr = ascii.GetBytes(data);

            foreach (byte tmp in bytesarr)
            {
                tem += tmp.ToString();
            }
            Console.WriteLine(tem);
            //MessageBox.Show(tem);
            try
            {
                //string URL = Url+"?"+postdata[0]+"="+postdata[1]+"&"+postdata[2]+"="+postdata[3];
                string URL = Url;
                WebRequest request = WebRequest.Create(URL);

                request.Method = "POST";
                //request.ContentType = "text/xml";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytesarr.Length;
                request.Timeout = 10800;

                System.IO.Stream streamwriter = request.GetRequestStream();
                streamwriter.Write(bytesarr, 0, bytesarr.Length);
                streamwriter.Close();

                WebResponse response = request.GetResponse();
                streamwriter = response.GetResponseStream();

                System.IO.StreamReader streamread = new System.IO.StreamReader(streamwriter);
                result = streamread.ReadToEnd();
                streamread.Close();
            }
            catch (Exception ex)
            {
                errorWEBS = ex.Message;
                errorW = true;
            }
            return result;
        }

        public static string POSTHTTPS(ref bool errorW, ref string errorWEBS, string url, params string[] postdata)
        {
            string result = string.Empty;
            string data = string.Empty;
            string tem = null;
            errorW = false;
            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();

            /*if (postdata.Length < 2)
            {
                MessageBox.Show("Parameters must be even , \"user\" , \"value\" , ... etc", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }*/
            //string name = null;
            for (int i = 0; i < postdata.Length; i += 2)
            {
                data += string.Format("&{0}={1} ", postdata[i], postdata[i + 1]);
            }
            //string tem = "json="; 
            data = data.Remove(0, 1);
            //tem += System.Net.WebUtility.HtmlDecode(data);
            //data = tem;
            tem = null;
            //Console.WriteLine(data);
            byte[] bytesarr = ascii.GetBytes(data);

            foreach (byte tmp in bytesarr)
            {
                tem += tmp.ToString();
            }
            Console.WriteLine(tem);
            //MessageBox.Show(tem);
            try
            {
                Uri uri = new Uri(url);

                WebRequest http = HttpWebRequest.Create(url);
                http.Timeout = 10800;
                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                Stream stream = response.GetResponseStream();

                System.IO.StreamReader streamread = new System.IO.StreamReader(stream);
                result = streamread.ReadToEnd();
                streamread.Close();
                //Console.WriteLine(result);
            }

            /*catch (UriFormatException e)
            {
                //Console.WriteLine("Invalid URL" + e.Message);
                errorWEBS = "Invalid URL " + e.Message;
                errorW = true;
            }
            catch (IOException e)
            {
                //Console.WriteLine("Could not connect to URL" + e.Message);
                errorWEBS = "Could not connect to URL" + e.Message;
                errorW = true;
            }*/
            catch (Exception ex)
            {
                errorWEBS = ex.Message;
                errorW = true;
            }
            return result;
        }

        #endregion Event Calls
  
        /*public void POSTHTTPSt(string Url, ref string sttHTTPS, ref string referrHTTPS)
        {
            HTTPSService(Url,ref sttHTTPS,ref referrHTTPS);
        }

        private SynchronizationContext syncContext;
        public void HTTPSService(string Url,ref string sttHTTPS, ref string referrHTTPS)
        {
            // Grab SynchronizationContext while on UI Thread   
            syncContext = SynchronizationContext.Current;

            // Create request   
            HttpWebRequest request =
                WebRequest.Create(new Uri(Url,
                    UriKind.Absolute))
                    as HttpWebRequest;
            request.Method = "POST";


            // Make async call for request stream.  Callback will be called on a background thread.  
            IAsyncResult asyncResult =
                request.BeginGetRequestStream(new AsyncCallback(RequestStreamCallback), request);

            sttHTTPS = sttpostHTTPS;
            referrHTTPS = errorHTTPS;
        }
        //private string statusString;
        public void RequestStreamCallback(IAsyncResult ar)
        {
            HttpWebRequest request = ar.AsyncState as HttpWebRequest;
            request.ContentType = "application/atom+xml";
            Stream requestStream = request.EndGetRequestStream(ar);
            StreamWriter streamWriter = new StreamWriter(requestStream);

            streamWriter.Write("<entry xmlns='http://www.w3.org/2005/Atom'>"
            + "<title type='text'>New Restaurant</title>"
            + "<content type='xhtml'>"
            + "  <div xmlns='http://www.w3.org/1999/xhtml'>"
            + "   <p>There is a new Thai restaurant in town!</p>"
            + "   <p>I ate there last night and it was <b>fabulous</b>.</p>"
            + "   <p>Make sure and check it out!</p>"
            + "  </div>"
            + " </content>"
            + "<author>"
            + "   <name>Pilar Ackerman</name>"
            + "  <email>packerman@contoso.com</email>"
            + " </author>"
            + "</entry>");


            // Close the stream.
            streamWriter.Close();

            // Make async call for response.  Callback will be called on a background thread.
            request.BeginGetResponse(new AsyncCallback(ResponseCallback), request);

        }
        public void ResponseCallback(IAsyncResult ar)
        {
            HttpWebRequest request = ar.AsyncState as HttpWebRequest;
            WebResponse response = null;
            try
            {
                response = request.EndGetResponse(ar);
            }
            catch (WebException we)
            {
                //statusString = we.Status.ToString();
                errorHTTPS = we.Status.ToString();
                Console.WriteLine("Error 1 : " + we.Status.ToString());
            }
            catch (SecurityException se)
            {
                //statusString = se.Message;
                //if (statusString == "")
                //   statusString = se.InnerException.Message;
                errorHTTPS = se.Message;
                if (errorHTTPS == "")
                    errorHTTPS = se.InnerException.Message;

            }

            // Invoke onto UI thread  
            syncContext.Post(ExtractResponse, response);
        }

        public void ExtractResponse(object state)
        {
            HttpWebResponse response = state as HttpWebResponse;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader responseReader = new StreamReader(response.GetResponseStream());

                sttpostHTTPS = response.StatusCode.ToString() +
                    " Response: " + responseReader.ReadToEnd();
                //Console.WriteLine(response.StatusCode.ToString() +
                //    " Response: " + responseReader.ReadToEnd());
            }
            else
            {
                sttpostHTTPS = "Post failed: ";// +statusString;
            }   //Console.WriteLine("Post failed: " + statusString);
        }*/

    }
}
