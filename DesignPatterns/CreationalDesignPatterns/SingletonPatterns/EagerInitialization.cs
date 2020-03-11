using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    public sealed class EagerInitialization
    {
        private static EagerInitialization instance = new EagerInitialization();
        private EagerInitialization()
        {

        }
        public static EagerInitialization GetInstance()
        {
            return instance;
        }
    }
}
