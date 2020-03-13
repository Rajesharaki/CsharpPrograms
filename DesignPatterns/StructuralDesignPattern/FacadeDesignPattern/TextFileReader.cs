using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DesignPatterns.StructuralDesignPattern.FacadeDesignPattern
{
    public class TextFileReader : IReadFiles
    {

        //Reading address from text file
        public void ReadFile()
        {
            string ReadFile=File.ReadAllText(@"C:\Users\yempc72\Desktop\VisualStudioPrograms\Project\DesignPatterns\StructuralDesignPattern\FacadeDesignPattern\TextFileAddressBook.txt");
            Console.WriteLine(ReadFile);
        }
    }
}
