using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Client
{ 
   
    public static string StartClient()
    {
        string result = "start";
       // print("Start");
        try
        {
            result = Communicate("localhost", 8888);
        }
        catch (System.Exception ex)
        {
           //result += ex.ToString();                                                 
        }
        return result;
               
    }

    private static string  Communicate(string hostname, int port)
    {
        byte[] bytes = new byte[1024];
        IPHostEntry ipHost = Dns.GetHostEntry(hostname);
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

        Socket sock = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        sock.Connect(ipEndPoint);
        string message = "new message";
        //print(message);
        byte[] data = Encoding.UTF8.GetBytes(message);

        int bytesSent = sock.Send(data);
        int bytesRec = sock.Receive(bytes);
        string answer=Encoding.UTF8.GetString(bytes, 0, bytesRec);
       // print(answer);
        sock.Shutdown(SocketShutdown.Both);
        sock.Close();
        return answer;

    }

    
}
