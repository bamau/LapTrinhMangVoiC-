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
    class TT_NHAN
    {    
        Socket s;
        public TT_NHAN(Socket sv)
        {
            s = sv;
        }
        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamReader sr = new StreamReader(ns);
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            List<IPEndPoint> listClient = new List<IPEndPoint>();
            List<string> liststring = new List<string>();
            while(true)
            {
                string s = sr.ReadLine();
                int i = 0;
                for(i = 0; i<listClient.Count; i++)
                {
                    if (client.Equals(listClient.ElementAt(i)))
                    {
                        liststring[i] = liststring[i]+ "_" + s;
                    }
                }
                if(i == listClient.Count)
                {
                    listClient.Add(client);
                    liststring.Add(s);
                }
            }
        }
    }
}
