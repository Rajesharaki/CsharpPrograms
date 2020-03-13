using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern.ProxyDesignPattern
{
    public class RealYoutube : IYoutube
    {
        public void DownloadVideo()
        {

            Console.WriteLine("video Download Completed....");
        }
    }
}
