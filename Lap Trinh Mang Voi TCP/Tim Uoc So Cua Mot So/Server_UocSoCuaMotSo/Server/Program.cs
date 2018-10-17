using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
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
            String a = sr.ReadLine();
            int so = int.Parse(a);         
            for (int i = 1; i <= so; i++)
            {
                if(so%i==0)
                {                           
                    sw.WriteLine(i.ToString());
                    sw.Flush();
                }              
            }
            sw.WriteLine("kt");
            sw.Flush();
            sr.Close();
            sw.Close();
            ns.Close();
            client.Close();
            ss.Stop();
        }
    }
}
