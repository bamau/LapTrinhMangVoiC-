
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

                for (i = 0; i < listclient.Count; i++)
                {
                    if(client.Equals(listclient.ElementAt(i)))
                    {
                                                        
                        if (listsoluong.ElementAt(i)<3)
                        {
                            
                            if (cutnumber[1]=="1")
                            {
                                listso[i][0] = a;
                            }
                            if (cutnumber[1] == "2")
                            {
                                listso[i][1] = a;
                            }
                            if (cutnumber[1] == "3")
                            {
                                listso[i][2] = a;
                            }
                            listsoluong[i]++;
                            if (listsoluong[i] != 3)
                            {
                                break;
                            }
                        }
                        
                        if (listsoluong.ElementAt(i) == 3)
                        {
                            string menu = "1.Tong ba so,2.Cac so le co trong ba so,3.Thoat";
                            byte[] data = new byte[10];
                            data = Encoding.ASCII.GetBytes(menu);
                            server.Send(data, data.Length, listclient.ElementAt(i));

                            string so1;
                            do
                            {
                                byte[] data2 = new byte[10];
                                data2 = server.Receive(ref client);
                                so1 = Encoding.ASCII.GetString(data2, 0, data2.Length);
                                if (so1 == "1")
                                {
                                    int kq = listso[i][0] + listso[i][1] + listso[i][2];
                                    byte[] data3 = new byte[10];
                                    data3 = Encoding.ASCII.GetBytes(kq.ToString());
                                    server.Send(data3, data3.Length, listclient.ElementAt(i));

                                }
                                if (so1 == "2")
                                {
                                   
                                    for (int j = 0; j < 3; j++)
                                    {
                                        if (listso[i][j] % 2 != 0)
                                        {                                           
                                            int flag = 0;
                                            byte[] data4 = new byte[10];
                                            data4 = Encoding.ASCII.GetBytes(flag.ToString());
                                            server.Send(data4, data4.Length, listclient.ElementAt(i));
                                            byte[] data3 = new byte[10];
                                            data3 = Encoding.ASCII.GetBytes(listso[i][j].ToString());
                                            server.Send(data3, data3.Length, listclient.ElementAt(i));                                           
                                            if (j==2)
                                            {
                                                flag = 1;
                                                byte[] data5 = new byte[10];
                                                data5 = Encoding.ASCII.GetBytes(flag.ToString());
                                                server.Send(data5, data5.Length, listclient.ElementAt(i));
                                            }

                                        }
                                    }
                                }
                                if (so1 == "3")
                                {
                                    break;
                                }
                            } while (so1 != "3");
                        }
                    }
                   
                }
                if (i == listclient.Count)
                {
                    listclient.Add(client);                              
                    listsoluong.Add(1);
                    int[] arr = new int[3];
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
