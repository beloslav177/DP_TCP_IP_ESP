using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace PHP
{
    class TCPClass
    {
        public int Hodnota = 0;
        public NetworkStream netStream;
        public TcpClient tcpClient;
        public int numBytesRead;
        //public string str;
        public TCPClass()
        { }

        public bool Connect(string hostName, int port)
        {
            tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect(hostName, port);
                netStream = tcpClient.GetStream();
                Debug.WriteLine("Connected");
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error..... " + e.StackTrace);
            }
            return false;
        }
        public void Disconnect()
        {
            if ((tcpClient != null) && (tcpClient.Connected))
            {
                tcpClient.GetStream().Close();
                tcpClient.Close();
            }
        }
        public bool SendMsg(string msg)
        {
            if (tcpClient == null) return false;
            try
            {
                if (tcpClient.Connected)
                {
                    Stream stream = tcpClient.GetStream();
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] sendData = asen.GetBytes(msg);
                    stream.Write(sendData, 0, sendData.Length);
                    return true;
                }
                else
                {
                    Debug.WriteLine("TCP client not connected!");
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error..... " + e.StackTrace);
            }
            return false;
        }
        public void ReadMsg(string responseData)
        {
            if (!tcpClient.Connected || tcpClient == null)
                try
                {
                    {
                        //byte[] data = new byte[1024];
                        //using (MemoryStream ms = new MemoryStream())
                        //{
                        //    Debug.WriteLine("Data sa prijmaju");
                        //    while (netStream!= null)
                        //    {
                        //        numBytesRead = netStream.Read(data, 0, data.Length);
                        //        ms.Write(data, 0, numBytesRead);
                        //        Debug.WriteLine("numBytesRead=" + numBytesRead.ToString() + "; msCount=" + ms.ToArray().Count());
                        //    }
                        //    str = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
                        //}

                        Byte[] data1 = new byte[1024];
                        while (netStream != null)
                        {
                            responseData = String.Empty;
                            numBytesRead = netStream.Read(data1, 0, data1.Length);
                            responseData = Encoding.ASCII.GetString(data1, 0, numBytesRead);
                        }

                    }
                }
                catch (Exception)
                {

                    throw;
                }
        }
		public void RemoveChars(PhpJSON php)
		{
			try
			{
				string str = "1000-000090243328-0000";
				string strom = str.Substring(9, str.Length - 9);
				string stram = str.Substring(9, str.Length - 9);
				str.Remove(str.Length - 5);

				string mystr = "1000-000090243328-0000";
				mystr = mystr.Substring(9, mystr.Length - 14);

			
				php.txtShelve.Text = mystr;

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}

		}
	}
}
