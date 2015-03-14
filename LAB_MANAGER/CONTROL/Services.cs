using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Runtime.ConstrainedExecution;
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
    class Services
    {
        public WebServices Network = new WebServices();
        public AppServices Local = new AppServices();
    }

    class WebServices
    {
        //string sttpostHTTPS;
        //public static string errorHTTPS;

        #region Hashing
        // hash password truoc khi gui len server
        public string hashpass(string refpass, ref bool ckchass)
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
        #endregion Hashing

        #region Connect to server
        //  gui thong tin POST len web http
        public string POST(ref bool errorW, ref string errorWEBS, string Url, params string[] postdata)
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
                request.Timeout = 36000;

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

        //  gui thong tin POST len web http security
        public string POSTHTTPS(ref bool errorW, ref string errorWEBS, string url, params string[] postdata)
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
                http.Timeout = 36000;
                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                Stream stream = response.GetResponseStream();

                System.IO.StreamReader streamread = new System.IO.StreamReader(stream);
                result = streamread.ReadToEnd();
                streamread.Close();
                //Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                errorWEBS = ex.Message;
                errorW = true;
            }
            return result;
        }
        #endregion Connect to server

        #region Response from server
        //public bool ErrRes = false;
        //public string MessRes = null;
        //public string MessResstt = null;
        public void showresponse(string path, string Data, string url, ref bool ErrRes, ref string MessRes, ref string MessResstt)
        {
            bool cmpres = false;
            try
            {
                Console.WriteLine("Data[0] is : \"" + Data[0] + "\", Data[1] is : \"" + Data[1] + "\"");
                if (Data[0].Equals('<') || Data[0].Equals('?') || Data[0].Equals('!') || Data[0].Equals(' ') || Data[0].Equals('\r') || Data[0].Equals('\n')
                 || Data[1].Equals('<') || Data[1].Equals('?') || Data[1].Equals('!') || Data[1].Equals(' ') || Data[1].Equals('\r') || Data[1].Equals('\n'))
                    cmpres = true;
                else
                    cmpres = false;
            }
            catch (Exception ex)
            {
                ErrRes = true;
                MessRes = ex.Message;
                //MessageBox.Show(ex.Message);
            }

            /*if (ErrRes)
            {
                ErrRes = false;
                MessRes="Connection timed out";
            }
            else */
            if (cmpres)
            {
                System.Diagnostics.Process myproc = new System.Diagnostics.Process();
                
                //string mydocpath = @"C:\Users\Public\Documents\";
                CONTROL.Services services = new CONTROL.Services();
                services.Local.writetofile(Data, path);
                //richText_Stt.Text = "Connected successful \n" + url;
                MessResstt = "Connected successfully";
                System.Diagnostics.Process.Start(path);
                cmpres = false;
            }
            else
            {
                MessResstt = "Connected to : " + url + "\n" + Data;
                //Console.WriteLine("Method successful.");
            }
            /*
              IAsyncResult result;
        Action action = () =>
        {
            // Your code here
        };

        result = action.BeginInvoke(null, null);

        if (result.AsyncWaitHandle.WaitOne(10000))
            Console.WriteLine("Method successful.");
        else
            Console.WriteLine("Method timed out.");
        }*/

        #endregion Response from server
        }
    }
    class AppServices
    {
        #region Write file
        // ghi data vao file
        public void writetofile(string data, string path)
        {
            StreamWriter sw;
            //sw = File.CreateText("c:\\testtext.txt");
            //sw.WriteLine("this is just a test");

            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
                sw.Close();
            }
            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(data);
            tw.Close();
        }
        #endregion Write file

        #region Convert Type
        // doi char[] sang string
        string resultstring;
        public string chararraytostring(char[] inchart)
        {
            foreach (char tmp in inchart)
            {
                resultstring += tmp.ToString();
            }
            return resultstring;
        }

        // doi char[] sang char
        char resultchar;
        public char chararraytochar(char[] inchart)
        {

            foreach (char tmp in inchart)
            {
                resultchar += tmp;
            }
            return resultchar;
        }

        // doi Byte[] sang HexString
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        // doi char[] sang string
        public string CharArrayToString(char[] data)
        {
            string des = null;
            foreach (char tmp in data)
            {
                if (!tmp.Equals(' '))
                    des += tmp.ToString();
            }
            return des;
        }
        #endregion Convert Type

        #region Configuration COMport
        // define the function refresh COM port list
        public void RefreshserialPortLAB_MANAGERList(ref ComboBox cmB_COMport, ref bool errorCOM, ref SerialPort serialPortRFID)
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshserialPortLAB_MANAGERList(ref errorCOM,cmB_COMport.Items.Cast<string>(), cmB_COMport.SelectedItem as string, serialPortRFID.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmB_COMport.Items.Clear();
                cmB_COMport.Items.AddRange(OrderedPortNames());
                cmB_COMport.SelectedItem = selected;
            }
        }
        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string[] ports;
        private string RefreshserialPortLAB_MANAGERList(ref bool errorCOM, IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            ports = SerialPort.GetPortNames();

            if (ports.Length != 0)
            {
                errorCOM = false;
                // First determain if there was a change (any additions or removals)
                bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

                // If there was a change, then select an appropriate default port
                if (updated)
                {
                    // Use the correctly ordered set of port names
                    ports = OrderedPortNames();

                    // Find newest port if one or more were added
                    string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                    // If the port was already open... (see logic notes and reasoning in Notes.txt)
                    if (PortOpen)
                    {
                        if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                        else if (!String.IsNullOrEmpty(newest)) selected = newest;
                        else selected = ports.LastOrDefault();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(newest)) selected = newest;
                        else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                        else selected = ports.LastOrDefault();
                    }
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }
        #endregion Configuration COMport
        
        #region Process

        public void demoprocess()
        {
            string tmp = null;
            /*foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                tmp += p.ProcessName + " - " + p.Id+"\n";*/
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("firefox"))
                tmp += p.ProcessName + " - " + p.Id + "\n";
                MessageBox.Show(tmp);
        }
     
        #endregion Process


    }
}
