using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern.FacadeDesignPattern
{
    /// <summary>
    /// Facade Design pattern minimize the complexity and client can easly interact with subsystem
    /// </summary>
    public static class DisplayAddress
    {
        static IReadFiles Instance;

        //Calling JsonFileReader
        public static void FromJsonFile()
        {
            Instance = new JsonFileReader();
            Instance.ReadFile();
        }
        //Calling TextFileReader
        public static void FromTextFile()
        {
            Instance = new TextFileReader();
            Instance.ReadFile();
        }
    }
}
