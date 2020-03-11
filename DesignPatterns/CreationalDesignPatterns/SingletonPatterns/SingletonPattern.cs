using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    /// <summary>
    /// If we want only one object of any class we go for Singleton Pattern
    /// </summary>
    sealed  class SingletonPattern
    {
        //Make object reference static why because static method can handle only static members
        private static SingletonPattern Instance;

        //Make constructor private why because we can't create object out side the class
        private SingletonPattern()
        {

        }

        /*Make GetInstance method public and static if method is public we can access anywhere and method is static 
        without creating an object we can accecss that method */
        public static SingletonPattern GetInstance
        {
            get //Getter method
            {
                if (Instance == null) //if Instace is null create instance of singleton class if not then return previous instance
                {
                    Instance = new SingletonPattern();
                }
                return Instance;
            }
        }
    }
}
