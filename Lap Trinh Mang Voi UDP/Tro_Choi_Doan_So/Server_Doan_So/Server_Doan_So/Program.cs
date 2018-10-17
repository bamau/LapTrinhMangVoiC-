using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_Doan_So
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);
            //b2 trao doi du lieu
            List<IPEndPoint> dsClient = new List<IPEndPoint>();
            // List<int> dsso = new List<int>();    
            int flag = 0;
            Random r = new Random();
            int n = r.Next(100);
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data1 = new byte[10];
            while (true)
            {
                string kq;
                int i;
                if (flag == 1)
                {
                    //gui ket qua cho client doan trung
                    string show = ("Ban da doan dung!!Chuc Mung");
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(show);
                    server.Send(data, data.Length, client);
                    //xoa client doan trung trong dsclient
                    dsClient.Remove(client);
                    //duyet tat ca cac client con lai
                    for (int j = dsClient.Count; j > 0; j--)
                    {
                        kq = "Da co nguoi doan trung! Rat Tiec";
                        byte[] data4 = new byte[10];
                        data4 = Encoding.ASCII.GetBytes(kq);
                        server.Send(data4, data4.Length, dsClient.ElementAt(j - 1));
                        //Gui lai falg cho ben thua
                        byte[] data5 = new byte[10];
                        data5 = Encoding.ASCII.GetBytes(flag.ToString());
                        server.Send(data5, data5.Length, dsClient.ElementAt(j - 1));

                        string show1 = ("Ban da thua");
                        byte[] data3 = new byte[10];
                        data3 = Encoding.ASCII.GetBytes(show1);
                        server.Send(data3, data3.Length, dsClient.ElementAt(j - 1));
                        // xoa client da gui thong tin
                        dsClient.RemoveAt(j - 1);

                    }
                    r = new Random();
                    n = r.Next(100);
                }
                data1 = server.Receive(ref client);
                string so1 = Encoding.ASCII.GetString(data1, 0, data1.Length);
                int a = int.Parse(so1);
                for (i = 0; i < dsClient.Count; i++)
                {
                    if (client.Equals(dsClient.ElementAt(i)))
                    {
                        if (a == n)
                        {
                            flag = 1;
                            kq = "Bang Nhau";
                            byte[] data = new byte[10];
                            data = Encoding.ASCII.GetBytes(kq);
                            server.Send(data, data.Length, client);
                            //gui flag ve cho client
                            byte[] data5 = new byte[10];
                            data5 = Encoding.ASCII.GetBytes(flag.ToString());
                            server.Send(data5, data5.Length, client);
                            break;
                        }
                        if (a < n)
                        {
                            flag = 0;
                            kq = "So " + a + " nho hon so can doan!";
                            byte[] data = new byte[10];
                            data = Encoding.ASCII.GetBytes(kq);
                            server.Send(data, data.Length, client);
                            //Gui flag ve cho client
                            byte[] data5 = new byte[10];
                            data5 = Encoding.ASCII.GetBytes(flag.ToString());
                            server.Send(data5, data5.Length, client);
                            break;

                        }
                        if (a > n)
                        {
                            flag = 0;
                            kq = "So " + a + " lon hon so can doan!";
                            byte[] data = new byte[10];
                            data = Encoding.ASCII.GetBytes(kq);
                            server.Send(data, data.Length, client);
                            //Gui flag ve cho client
                            byte[] data5 = new byte[10];
                            data5 = Encoding.ASCII.GetBytes(flag.ToString());
                            server.Send(data5, data5.Length, client);
                            break;
                        }
                    }
                }
                //Client chua co trong list
                if (i == dsClient.Count)
                {
                    dsClient.Add(client);
                    if (a == n)
                    {
                        flag = 1;
                        kq = "Bang Nhau";
                        byte[] data = new byte[10];
                        data = Encoding.ASCII.GetBytes(kq);
                        server.Send(data, data.Length, client);
                        //Gui flag ve cho client
                        byte[] data5 = new byte[10];
                        data5 = Encoding.ASCII.GetBytes(flag.ToString());
                        server.Send(data5, data5.Length, client);
                        break;
                    }
                    if (a < n)
                    {
                        flag = 0;
                        kq = "So " + a + " nho hon so can doan!";
                        byte[] data = new byte[10];
                        data = Encoding.ASCII.GetBytes(kq);
                        server.Send(data, data.Length, client);
                        //Gui flag ve cho client
                        byte[] data5 = new byte[10];
                        data5 = Encoding.ASCII.GetBytes(flag.ToString());
                        server.Send(data5, data5.Length, client);
                    }
                    if (a > n)
                    {
                        flag = 0;
                        kq = "So " + a + " lon hon so can doan!";
                        byte[] data = new byte[10];
                        data = Encoding.ASCII.GetBytes(kq);
                        server.Send(data, data.Length, client);
                        //Gui flag ve cho client
                        byte[] data5 = new byte[10];
                        data5 = Encoding.ASCII.GetBytes(flag.ToString());
                        server.Send(data5, data5.Length, client);
                    }
                }
            }
        }
    }
}
