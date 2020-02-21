using System;


namespace CsharpPrograms.FunctionalPrograms
{
    class EuclideanDistance
    {
        public EuclideanDistance()
        {
            FindDistance();
        }
        static void FindDistance()
        {
            Utility u = new Utility();
            Console.Write("Enter the Value of x: ");
            int x = u.ReadInt();
            Console.Write("Enter the Value of y: ");
            int y = u.ReadInt();
            double distance= Math.Sqrt(Math.Pow(x, x) + Math.Pow(y, y));
            Console.WriteLine("Eulidean disatance from origin is: " + distance);
        }
    }
}
