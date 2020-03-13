using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern.ProxyDesignPattern
{
    class Client
    {
        static void Main(String [] args)
        {
            IYoutube instance = new ProxyYoutube();
            instance.DownloadVideo();
        }
    }
}
