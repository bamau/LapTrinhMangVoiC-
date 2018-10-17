using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerHieuHaiSo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);

            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data1 = new byte[10];
            data1 = server.Receive(ref client);
            string so1 = Encoding.ASCII.GetString(data1, 0, data1.Length);
            string[] m1 = so1.Split('_');
            int x = 0;
            int y = 0;
            if(m1[1] == "0")
            {
                x = int.Parse(m1[0]);
            }
            else
            {
                y = int.Parse(m1[0]);
            }

            byte[] data2 = new byte[10];
            string so2 = Encoding.ASCII.GetString(data2, 0, data2.Length);
            string[] m2 = so2.Split('_');
            if (m2[1] == "0")
            {
                x = int.Parse(m2[0]);
            }
            else
            {
                y = int.Parse(m2[0]);
            }
            int kq = x - y;
            byte[] data = new byte[10];
            data = Encoding.ASCII.GetBytes(kq.ToString());
            server.Send(data, data.Length, client);

            server.Close();
        }
    }
}
