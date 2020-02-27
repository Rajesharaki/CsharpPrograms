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
            //create UnOrderedList object
            
            UnOrderedList < String > List= new UnOrderedList<String>();
            String FilePath = @"C:\Users\rajes\OneDrive\Desktop\Demo.txt";
            
            //Read all lines from the text and it returns string array
            String []  a=File.ReadAllText(FilePath).Split(' ');
            
            //Element added from Array to List
            for(int i = 0; i < a.Length; i++)
            {
                List.Add(a[i]);
            }
            int Lenght = List.Size();
            
            //If Element found delete that elment from the List
            if (List.Search(Word))
            {
                List.Remove(Word);
            }
            
            //Else add the element to the list
            else
            {
                List.Append(Word);
            }
            String st = "";
            
            //Convert List to string
            for(int i = 0; i < List.Size(); i++)
            {
                st += List.Peek(i)+" ";
            }
            
            //added all text into the text file
            File.WriteAllText(FilePath,st);
        }
         
          
    }
}
