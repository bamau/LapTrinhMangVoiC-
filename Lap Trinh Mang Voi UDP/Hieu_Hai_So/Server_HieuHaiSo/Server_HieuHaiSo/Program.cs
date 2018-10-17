using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_TongHaiSo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);

            //b2: Trao doi du lieu  
            List<IPEndPoint> listClient = new List<IPEndPoint>();
            List<int> listso = new List<int>();
            List<int> listsoluong = new List<int>();
            List<int> listn = new List<int>();
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);                                       
            
            while (true)
            {
                byte[] data1 = new byte[10];
                data1 = server.Receive(ref client);
                string dl1 = Encoding.ASCII.GetString(data1, 0, data1.Length);
                string[] m1 = dl1.Split('_');
                int a = int.Parse(m1[0]);
                int i, kq;

                for (i=0; i<listClient.Count; i++)
                {
                    if (client.Equals(listClient.ElementAt(i)))
                    {
                        if(listsoluong.ElementAt(i)<listn.ElementAt(i))
                        {
                            listsoluong[i]++;
                            if (listso.ElementAt(i) == 0)
                            {
                                
                                int b = listso.ElementAt(i);
                                kq = a - b;
                                listso[i] = kq;
                                break;
                            }
                            else
                            {
                                
                                int b = listso.ElementAt(i);
                                kq = b - a;
                                listso[i] = kq;
                                if(listsoluong.ElementAt(i)<listn.ElementAt(i))
                                {
                                    break;
                                }                               
                            }
                            
                        }
                        if (listsoluong.ElementAt(i) > listn.ElementAt(i))
                        {
                            if (listn.ElementAt(i) == 0)
                            {
                                if(m1[1]=="0")
                                {
                                    listn.Add(a);
                                }
                                
                                int b = listso.ElementAt(i);
                                kq = a - b;
                                listso[i] = kq;
                                break;
                            }

                        }
                        if (listsoluong.ElementAt(i) == listn.ElementAt(i))
                        {
                            kq = listso.ElementAt(i);                                             
                            byte[] data2 = new byte[10];
                            data2 = Encoding.ASCII.GetBytes(kq.ToString());
                            server.Send(data2, data2.Length, client);
                            break;
                        }
                    }               
                }
                if (i == listClient.Count)
                {
                    if (m1[1] == "0")
                    {
                        listClient.Add(client);
                        listn.Add(a);
                        listso.Add(0);                        
                        listsoluong.Add(0);
                       
                    }
                    else
                    {
                        listClient.Add(client);
                        listn.Add(0);
                        listso.Add(a);
                        listsoluong.Add(1);
                        
                    }
                }               
            }              
        }
    }
}
