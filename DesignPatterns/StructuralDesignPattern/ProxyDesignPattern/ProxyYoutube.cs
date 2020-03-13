using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern.ProxyDesignPattern
{
    public class ProxyYoutube : IYoutube
    {
        RealYoutube Instance;
        public void DownloadVideo()
        {
            if (Instance == null)
            {
                Instance = new RealYoutube();
            }
            Instance.DownloadVideo();
        }
    }
}
