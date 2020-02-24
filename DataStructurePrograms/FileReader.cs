using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataStructurePrograms
{
    class FileRead
    {
        public FileRead()
        {
            Read();
        }
        static void Read()
        {
            Console.Write("Enter the searching word: ");
            String Word = Console.ReadLine();
            UnOrderedList < String > List= new UnOrderedList<String>();
            String FilePath = @"C:\Users\rajes\OneDrive\Desktop\Demo.txt";
            String []  a=File.ReadAllText(FilePath).Split(' ');
            for(int i = 0; i < a.Length; i++)
            {
                List.Add(a[i]);
            }
            int Lenght = List.Size();
            if (List.Search(Word))
            {
                List.Remove(Word);
            }
            else
            {
                List.Append(Word);
            }
            String st = "";
            for(int i = 0; i < List.Size(); i++)
            {
                st += List.Peek(i)+" ";
            }
            File.WriteAllText(FilePath,st);
        }
         
          
    }
}
