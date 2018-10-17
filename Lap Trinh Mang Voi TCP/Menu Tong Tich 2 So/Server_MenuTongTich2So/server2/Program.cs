using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace server2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener ss = new TcpListener(123);
            ss.Start();
            Socket client = ss.AcceptSocket();
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            string menu = "1.Nhap 2 so,2.Tong 2 so,3.Tich 2 so,4.Thoat";    
            sw.WriteLine(menu);
            sw.Flush();      
            string a, b, c;
            int x=0, y=0;
            int flag = 0;
            do
            {

                c = sr.ReadLine();
                if (c == "1")
                {
                    a = sr.ReadLine();
                    b = sr.ReadLine();
                    x = int.Parse(a);
                    y = int.Parse(b);                
                    flag = 1;
                }
                if (c == "2")
                {
                    sw.WriteLine(flag.ToString());
                    if (flag == 0)
                    {
                        sw.WriteLine("Loi chua nhap!");
                        sw.Flush();
                    }
                    else
                    {
                        int tong = x + y;
                        sw.WriteLine(tong.ToString());
                        sw.Flush();
                    }
                }
                if (c == "3")
                {
                    sw.WriteLine(flag.ToString());
                    if (flag == 0)
                    {
                        sw.WriteLine("Loi chua nhap!");
                        sw.Flush();
                    }
                    else
                    {
                        int tich = x * y;
                        sw.WriteLine(tich.ToString());
                        sw.Flush();
                    }
                }           
            } while (c != "4");
            return;
            sr.Close();
            sw.Close();
            ns.Close();
            client.Close();
            ss.Stop();
        }
    }
}
