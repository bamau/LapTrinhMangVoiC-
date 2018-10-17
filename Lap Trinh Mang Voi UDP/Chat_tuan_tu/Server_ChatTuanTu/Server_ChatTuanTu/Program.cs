using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_ChatTuanTu
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1: Mo port
            UdpClient server = new UdpClient(9050);
            //b2 trao doi du lieu
            Console.WriteLine("SERVER");          
            while (true)
            {
                IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = new byte[10];
                data = server.Receive(ref client);
                string chuoi = Encoding.ASCII.GetString(data, 0, data.Length);
                Console.WriteLine(chuoi);
                if(chuoi=="bye"||chuoi=="tam biet")
                {
                   break;
                }              
                string chuoi1 = Console.ReadLine();
                byte[] data1 = new byte[10];
                data1 = Encoding.ASCII.GetBytes(chuoi1);
                server.Send(data1, data1.Length, client);
                if (chuoi1 == "bye" || chuoi1 == "tam biet")
                {
                    break;
                }                              
            }
            server.Close();
        }
    }
}
