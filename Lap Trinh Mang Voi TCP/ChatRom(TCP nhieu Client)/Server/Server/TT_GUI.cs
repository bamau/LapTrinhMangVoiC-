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
    class TT_GUI
    {
        Socket s;
        public TT_GUI(Socket sv)
        {
            s = sv;
        }
        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamWriter sw = new StreamWriter(ns);
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            List<IPEndPoint> listClient = new List<IPEndPoint>();
            List<string> liststring = new List<string>();
            while (true)
            {
                int i = 0;
                for(i=0; i<listClient.Count; i++)
                {
                    if (client.Equals(listClient.ElementAt(i)))
                    {
                        continue;
                    }
                    string[] cutString = new string[1024];
                    cutString = liststring[i].Split('_');
                    sw.WriteLine("CLIENT"+i+1+":"+cutString[i]);
                    sw.Flush();
                }
            }
        }
    }
}
