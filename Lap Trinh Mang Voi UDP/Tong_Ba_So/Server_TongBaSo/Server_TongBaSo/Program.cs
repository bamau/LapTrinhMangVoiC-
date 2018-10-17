using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_HieuHaiSo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);

            //b2: Trao doi du lieu
            List<int> dssoluong = new List<int>();
            List<int> dsso = new List<int>();
            List<int> dsn = new List<int>();
            List<IPEndPoint> dsclient = new List<IPEndPoint>();
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data1 = new byte[10];                                                             
            while (true)
            {            
                data1 = server.Receive(ref client);
                string so1 = Encoding.ASCII.GetString(data1, 0, data1.Length);
                int a = int.Parse(so1);
                int i ;
                int b, kq;
                for (i = 0; i < dsclient.Count; i++)
                {                           
                    if (client.Equals(dsclient.ElementAt(i)))
                    {                      
                        if (dssoluong.ElementAt(i)<dsn.ElementAt(i))
                        {                                                 
                            dssoluong[i]++;
                            b = dsso.ElementAt(i);
                            kq = a + b;
                            dsso[i] = kq;
                            break;                         
                        }
                        if(dssoluong.ElementAt(i)==dsn.ElementAt(i))
                        {
                            b = dsso.ElementAt(i);
                            kq = a + b;
                            dsso[i] = kq;
                            byte[] data3 = new byte[10];
                            data3 = BitConverter.GetBytes(kq);
                            server.Send(data3, data3.Length, client);
                            break;
                        }                                                                                                 
                    }
                    
                }
                if (i == dsclient.Count)
                {
                    dsclient.Add(client);
                    dsso.Add(0);
                    dsn.Add(a);                   
                    dssoluong.Add(1);
                }
            }
        }
    }
}
