using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);
            List<IPEndPoint> listclient = new List<IPEndPoint>();
            List<int[]> listso = new List<int[]>();
            List<int> listsoluong = new List<int>();
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
           
            while (true)
            {
                byte[] data1 = new byte[10];
                data1 = server.Receive(ref client);
                string so = Encoding.ASCII.GetString(data1, 0, data1.Length);
                string[] cutnumber =so.Split('_');
                int a = int.Parse(cutnumber[0]);              
                int i;
                int[] arr = new int[3];
                for (i = 0; i < listclient.Count; i++)
                {
                    if(client.Equals(listclient.ElementAt(i)))
                    {
                        listsoluong[i]++;
                        if(listsoluong.ElementAt(i)==3)
                        {
                            string menu = "1.Tong ba so,2.Cac so le co trong ba so,3.Thoat";
                            byte[] data = new byte[10];
                            data = Encoding.ASCII.GetBytes(menu);                           
                            server.Send(data, data.Length, listclient.ElementAt(i));

                            byte[] data2 = new byte[10];
                            data2 = server.Receive(ref client);
                            string so1 = Encoding.ASCII.GetString(data2, 0, data2.Length);
                            if(so1=="1")
                            {
                                int kq = arr[0]+arr[1]+arr[2];
                                byte[] data3 = new byte[10];
                                data3 = Encoding.ASCII.GetBytes(kq.ToString());
                                server.Send(data3, data3.Length, listclient.ElementAt(i));
                            }
                        }
                        if(listsoluong.ElementAt(i)<3)
                        {
                            
                            if(cutnumber[1]=="1")
                            {                              
                                arr[0] = a;
                            }
                            if (cutnumber[1] == "2")
                            {                               
                                arr[1] = a;
                            }
                            if (cutnumber[1] == "3")
                            {                               
                                arr[2] = a;
                            }
                           
                        }
                    }
                   
                }
                if (i == listclient.Count)
                {
                    listclient.Add(client);                              
                    listsoluong.Add(1);                   
                    if (cutnumber[1] == "1")
                    {                        
                        arr[0] = a;
                        listso.Add(arr);                                             
                    }
                    if (cutnumber[1] == "2")
                    {
                        arr[1] = a;
                        listso.Add(arr);
                    }
                    if (cutnumber[1] == "3")
                    {
                        arr[2] = a;
                        listso.Add(arr);
                    }
                }
                
            }
        }
    }
}
