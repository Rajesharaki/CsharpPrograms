using System;
using DataStructurePrograms;
using Newtonsoft.Json;
using System.IO;
namespace ObjectOrientedPrograms
{
    struct Details
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNo { get; set; }
        public override string ToString()
        {
            String st = "";
            st += "FirstName: " + FirstName + "\nLastName: " + LastName + "\nAdress: " + Address + "\nCity: " + City + "\nState: " + State + "\nZip: " + Zip + "\nPhoneNo: " + PhoneNo;
            return st;
        }
    }
    class AddressBook
    {
        UnOrderedList<String> list = new UnOrderedList<string>();    //using List name space class
        string FilePath = @"C:\Users\yempc72\Desktop\AddressBook.json";
        public AddressBook()
        {
            Selection();
        }
        public void Selection()
        {
            Console.WriteLine("'A'-->press A to add A new Person\n" +
                               "'Q'-->Press Q to Quit\n" +
                               "'E'-->Press E to Edit Address\n" +
                               "'D'-->Press D to Delete\n"
                               + "'S'-->Press S to Display");
            String select = Console.ReadLine();
            switch (select)
            {
                case "A": Console.Clear(); AddDetail(); break;
                case "Q": Console.Clear(); Quit(); break;
                case "S": Console.Clear(); Display(); break;
                case "D": Console.Clear();Delete();break;
                case "E": Console.Clear();Edit();break;
                default: Console.WriteLine("Invalid Key....Enter correct Key ..."); Selection(); break;
            }
        }
        //Adding Details
        public void AddDetail()
        {
            Console.Write("FirstName: ");
            string FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            string LastName = Console.ReadLine();
            Console.Write("Address: ");
            string Address = Console.ReadLine();
            Console.Write("City: ");
            string City = Console.ReadLine();
            Console.Write("State: ");
            string State = Console.ReadLine();
            Console.Write("Zip: ");
            string Zip = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            string PhNo = Console.ReadLine();
            Details obj = new Details()
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                City = City,
                State = State,
                Zip = Zip,
                PhoneNo = PhNo
            };
            string ob = JsonConvert.SerializeObject(obj); //Convert Details object into Class information or string
            Check(ob);
        }
        //Checking any details repeated 
        public void Check(string value)
        {
            string[] text = File.ReadAllLines(FilePath);  //Reading all text from the file
            for (int i = 0; i < text.Length; i++)
            {
                list.Add(text[i]+"\n");
            }
            if (list.Search(value))
            {
                Console.WriteLine("This Details already exists");
                Selection();
            }
            else
            {
                Console.WriteLine("Successfully stored your details...................");
                list.Add(value+"\n");
            }
            Select();
        }
        public void Select()
        {
            Console.WriteLine("'A'-->press A to add A new Person\n" +
                              "'Q'-->Press Q to Quit\n" +
                               "'D'-->Press D to Delete\n"+ "'E'-->Press E to Edit Address");
            String select = Console.ReadLine();
            switch (select)
            {
                case "A": Console.Clear(); AddDetail(); break;
                case "Q": Console.Clear(); Quit(); break;
                case "D": Console.Clear(); Delete(); break;
                case "E": Console.Clear(); Edit(); break;
                default: Console.WriteLine("Invalid Key....Enter correct Key ..."); Selection(); break;
            }
        }
        //Quit method
        public void Quit()
        {
            Console.WriteLine("Successfully Stored All Details................");
            if (!(list.IsEmpty())) //Storing all details 
            {
                File.WriteAllText(FilePath, list.ToString());
            }
            Environment.Exit(0);
        }
        //Displaying Address book details
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("............................................Adress Details................................................");
            Console.WriteLine("___________________________________________________________________________________________________________");
            String[] a = File.ReadAllLines(FilePath);
            int k = 1;
            for (int i = 0; i < a.Length ; i++)
            {
                Console.WriteLine("Address Number " + (k++));
                Console.WriteLine("_________________________");
                Details r = JsonConvert.DeserializeObject<Details>(a[i]);
                Console.WriteLine(r);
                Console.WriteLine();
            }
            Select();
        }
        public void Delete()
        {
            Console.Write("Enter the FirstName : ");
            String name = Console.ReadLine();
            string [] Name=File.ReadAllLines(FilePath);
            for (int k = 0; k < Name.Length; k++)
            {
                list.Add(Name[k] + "\n");
            }
            for (int i = 0; i < Name.Length; i++)
            {
                Details r = JsonConvert.DeserializeObject<Details>(Name[i]);
                if (r.FirstName == name)
                {
                 
                    list.Remove(r.FirstName);
                    File.WriteAllText(FilePath, list.ToString());
                }
            }
            Display();
        }
        public void Edit()
        {
            Console.WriteLine("1 --> for Edit FirstName\n" +
                "2-->for Edit Last Name\n" +
                "3-->for Edit Address\n" +
                "4-->for Edit City\n" +
                "5-->for Edit State\n" +
                "6-->for Edit Zip\n" +
                "7-->for Edit Phone number");
            int num = int.Parse(Console.ReadLine());
            string[] text = File.ReadAllLines(FilePath);  //Reading all text from the file
            for (int k = 0; k < text.Length; k++)
            {
                list.Add(text[k] + "\n");
            }
            Console.WriteLine(list.ToString());
            if (num == 1)
            {
                Console.Write("Enter the First Name: ");
                string FN = Console.ReadLine();
                for(int i = 0; i < text.Length; i++)
                {
                    Details r = JsonConvert.DeserializeObject<Details>(text[i]);
                    if (r.FirstName == FN)
                    {
                        Console.WriteLine(r.FirstName);
                        Console.WriteLine("Edit FirstName");
                        string name = Console.ReadLine();
                        string find = JsonConvert.SerializeObject(r);
                        string replace= find.Replace(FN, name);
                        list.Add(replace);
                        File.WriteAllText(FilePath, list.ToString());
                    }
                }
            }

           Display();
        }
    }
}
