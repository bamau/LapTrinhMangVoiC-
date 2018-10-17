using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace client4
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient cl = new TcpClient("127.0.0.1", 1234);
            NetworkStream ns = cl.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            Console.WriteLine("CLIENT");
            int flag=0;
            while (true)
            {
                Console.Write("Client: ");
                string a = Console.ReadLine();
                sw.WriteLine(a);
                sw.Flush();
                if (a == "tam biet" || a == "bye")
                {
                    flag = 0;         
                    break;
                }
                string b = sr.ReadLine();
                Console.WriteLine("Server: "+b);
                if (b == "tam biet" || b == "bye")
                {
                    flag = 1;
                    break;
                }
            }
            if (flag==1)
            {
                Console.WriteLine("SERVER da dong ket noi");
                Console.ReadLine();
            }     
            if(flag==0)
            {
                return;
            }       
            sr.Close();
            sw.Close();
            ns.Close();
            cl.Close();
        }
    }
}
