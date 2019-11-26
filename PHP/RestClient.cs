using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace PHP
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }
        public string MakeRequest()
        {
            try
            {
                string strResponseValue = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

                request.Method = httpMethod.ToString();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("errod code:" + response.StatusCode.ToString());
                    }
                    //Proces používania stream
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }// koniec používania stream reader
                        }
                    } //koniec používania stream
                }
                return strResponseValue;
            }
            catch (Exception)
            {

                MessageBox.Show("Nie je spustený PHP server");
                return String.Empty;
                //throw;
            }
        }
        
    }
}
