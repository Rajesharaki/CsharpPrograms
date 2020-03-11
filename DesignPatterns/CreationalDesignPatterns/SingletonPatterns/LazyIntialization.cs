using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    /// <summary>
    /// Make class sealed because if we make class seled nested class also not possible to inhert this class
    /// </summary>
    public sealed class LazyIntialization
    {
        /*Create one static variable that can hold Lazy Intialization object*/
        private static LazyIntialization Instance;

        static int count = 0; //just for check How many objects are create

        /*Make Constructor private because if we make constructor private out side the class we can't create object and that class doesn't have any child class 
        (means inheritance not possible)*/
        private LazyIntialization() { Console.WriteLine("Count: " + (++count)); } //Checking how many objects are create
      
        /*Make method public and static  beacuse if public it's golbal point access method and if it's static we can accecss that method without create an object
          this pattern work fine for single thread in multithreading it's create more than one object */
        public static LazyIntialization GetInstance
        {
            get
            {
                if (Instance == null) 
                {
                    Instance = new LazyIntialization();
                }
                return Instance;
            }
        }

        //Just for checking 
        public void  PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
