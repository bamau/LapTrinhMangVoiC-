using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_ChatTuanTu
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1 Mo port
            UdpClient client = new UdpClient("127.0.0.1", 9050);
            //b2 Trao doi du lieu
            Console.WriteLine("CLIENT");     
            while (true)
            {
                string chuoi = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(chuoi);
                client.Send(data, data.Length);
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
                if (chuoi == "bye" || chuoi == "tam biet")
                {
                    break;
                }               
                byte[] data1 = new byte[10];
                data1 = client.Receive(ref server);
                string chuoi1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine(chuoi1);
                if (chuoi1 == "bye" || chuoi1 == "tam biet")
                {
                    break;
                }                                      
            }
            client.Close();
        }
    }
}
