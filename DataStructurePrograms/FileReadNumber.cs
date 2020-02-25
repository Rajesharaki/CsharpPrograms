using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataStructurePrograms
{
    class FileReadNumber
    {
        public FileReadNumber()
        {
            Read();
        }
        static void Read()
        {
            string FilePath = @"C:\Users\rajes\OneDrive\Desktop\File.txt";
            String[]a=File.ReadAllText(FilePath).Split(' ');
            OrderedList list = new OrderedList();
            //added value from array to string
            for(int i = 0; i < a.Length; i++)
            {
                list.Add(int.Parse(a[i]));
            }
            Console.Write("Enter the searching value: ");
            int num = int.Parse(Console.ReadLine());
            if (list.Search(num))
            {
                list.Remove(num);
            }
            else
            {
                list.Add(num);
            }
            String st = "";
            for (int i = 0; i < list.Size(); i++)
            {
                st += list.Peek(i)+" ";
            }
            File.WriteAllText(FilePath, st);

        }
    }
}
