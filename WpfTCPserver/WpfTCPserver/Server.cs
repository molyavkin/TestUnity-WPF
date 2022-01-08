using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfTCPserver
{
    public class Server
    {
        public void StartServer()
        {
            IPHostEntry iPHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = iPHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8888);

            Socket sock = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Bind(ipEndPoint);
                sock.Listen(10);
                while (true)
                {
                    Socket s = sock.Accept();
                    string data = null;
                    byte[] bytes = new byte[1024];
                    int bytesCount = s.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesCount);
                    //string reply = "Quey size: " + data.Length.ToString() + " chars";
                    WeatherResponse wr = new WeatherResponse();
                    Controller.GetInfo();
                    //     string reply = wr.GetTemperatureInfo();
                    //   string reply = "Какие-то данные";
                    string reply = Controller.GetInfo();
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    s.Send(msg);
                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        break;
                    }

                    s.Shutdown(SocketShutdown.Both);
                    s.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
    }
}
