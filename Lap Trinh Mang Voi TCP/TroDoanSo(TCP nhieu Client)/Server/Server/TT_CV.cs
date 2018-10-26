using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Server
{
    class TT_CV
    {
        Socket s;
        int so;
        static Boolean flag = false;
        static List<Socket> listClient = new List<Socket>();
        public TT_CV(Socket sv, int N)
        {
            s = sv;
            so = N;
            listClient.Add(s);
        }
        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);          
            while (true)
            {
                string a = sr.ReadLine();
                int so1 = int.Parse(a);
                if (flag == true)
                {
                    sw.WriteLine("Da co nguoi doan trung! That bai");
                    sw.Flush();
                    break;
                }
                else
                {
                    if (so1 > so)
                    {
                        sw.WriteLine("Lon Hon");
                        sw.Flush();
                    }
                    if (so1 < so)
                    {
                        sw.WriteLine("Nho Hon");
                        sw.Flush();
                    }
                    if (so1 == so)
                    {                        
                        sw.WriteLine("Bang Nhau");
                        sw.Flush();
                        flag = true;
                        break;
                    }
                }              
            }
        }
    }
}
