using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace server4
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
            Console.WriteLine("SERVER");
            int flag=0;
            while (true)
            {
                string a = sr.ReadLine();
                Console.WriteLine("Client: "+a);
                if (a == "tam biet" || a == "bye")
                {
                    flag = 1;
                    break;
                }
                Console.Write("Server: ");
                string b = Console.ReadLine();
                sw.WriteLine(b);
                sw.Flush();
                if (b == "tam biet" || b == "bye")
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("CLIENT da dong ket noi");
                Console.ReadLine();
            }
            if(flag==0)
            {
                return;
            }       
            sr.Close();
            sw.Close();
            ns.Close();
            client.Close();
            ss.Stop();
        }
    }
}
