using System;


namespace CsharpPrograms.AlgorithmPrograms
{
    class PermutationString
    {
        public PermutationString()
        {
            Permutation();
        }
        static void Permutation()
        {
            Console.Write("Enter the String: ");
            String str=Console.ReadLine();
            Permute(str, 0, str.Length - 1);
        }
        static void Permute(String str,int f,int l)
        {
            if (f == l)
            {
                Console.WriteLine(str);
            }
            else
            {
                for(int i = f; i <= l; i++)
                {
                    str=Swap(str, f, i);
                    Permute(str, f + 1, l);
                    str = Swap(str, f, i);
                }
            }
            static string Swap(String str,int i,int j)
            {
                Char[]a=str.ToCharArray();
                char temp = a[i];
                a[i] = a[j];
                a[j] = temp;
                string s = new string(a);
                return s;
            }
        }
    }
}
