using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server3
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener ss = new TcpListener(1234);
            ss.Start();
            Socket client = ss.AcceptSocket();
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            Random r = new Random();
            int n = r.Next(100);

            while (true)
            {
                string so = sr.ReadLine();
                int a = int.Parse(so);
                string kq;
                if (a == n)
                {
                    kq = "Bang nhau";
                    sw.WriteLine(kq);
                    sw.Flush();
                    break;
                }
                if (a < n)
                {
                    kq = "Nho hon";
                    sw.WriteLine(kq);
                    sw.Flush();
                }
                if (a > n)
                {
                    kq = "Lon hon";
                    sw.WriteLine(kq);
                    sw.Flush();
                }
            }
            sr.Close();
            sw.Close();
            ns.Close();
            client.Close();
            ss.Stop();
        }
    }
}
