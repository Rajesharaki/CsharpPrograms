using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DesignPatterns.StructuralDesignPattern.FacadeDesignPattern
{
    /// <summary>
    /// JsonFileReader Implements IReaderFiles interface
    /// </summary>
    public class JsonFileReader : IReadFiles
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PinCode { get; set; }
        string FilePath = @"C:\Users\yempc72\Desktop\VisualStudioPrograms\Project\DesignPatterns\StructuralDesignPattern\FacadeDesignPattern\JsonAddressBook.json";
       
        /// <summary>
        /// Reading Address from JsonFile
        /// </summary>
        public void ReadFile()
        {
            string JsonString=File.ReadAllText(FilePath);
            var JsonFileReaderObjeect=JsonConvert.DeserializeObject<JsonFileReader>(JsonString);
            Console.WriteLine(JsonFileReaderObjeect);
        }

        //To string method
        public override string ToString()
        {
            return $"Name:{this.Name}\nAddress:{Address}\nPhoneNumber:{this.PhoneNumber}\nPincode:{this.PinCode}";
        }
    }
}
