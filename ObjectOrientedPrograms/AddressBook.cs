using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace ObjectOrientedPrograms
{
    public class Details
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
        List<Details> list = new List<Details>();    //using List name space class
        //Address book Constructor
        public AddressBook()
        {
            Selection();
        }

        //Selection method
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
                case "D": Console.Clear(); Delete(); break;
                case "E": Console.Clear(); Edit(); break;
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
            Check(obj);
        }
        //Checking any details repeated 
        public void Check(Details Obj)
        {
            String Read = File.ReadAllText(@"C:\Users\yempc72\Desktop\AddressBook.json");
            if (Read.Length != 0)
            {
                list = JsonConvert.DeserializeObject<List<Details>>(Read);
            }
            list.Add(Obj);
            File.WriteAllText(@"C:\Users\yempc72\Desktop\AddressBook.json", JsonConvert.SerializeObject(list));
            Selection();
        }
        //Quit method
        public void Quit()
        {
            Console.WriteLine("Successfully Stored All Details................");
            Environment.Exit(0);
        }
        //Displaying Address book details
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("............................................Adress Details................................................");
            Console.WriteLine("___________________________________________________________________________________________________________");
            string Read = File.ReadAllText(@"C:\Users\yempc72\Desktop\AddressBook.json");
            list = JsonConvert.DeserializeObject<List<Details>>(Read);
            foreach (var x in list)
            {
                Console.WriteLine(x + "\n");
            }
            Selection();
        }
        public void Delete()
        {
            Console.Write("Enter the Delete FirstName: ");
            string name = Console.ReadLine();
            string Read = File.ReadAllText(@"C:\Users\yempc72\Desktop\AddressBook.json");
            list = JsonConvert.DeserializeObject<List<Details>>(Read);
            Details[] a = list.ToArray();
            List<Details> d = new List<Details>();
            foreach (Details x in a)
            {
                if (!x.FirstName.Equals(name))
                {
                    d.Add(x);
                }
            }
            ////serializing the List of Person objects
            string serialize = JsonConvert.SerializeObject(d);
            ////Re-writing the json file with deletion
            File.WriteAllText(@"C:\Users\yempc72\Desktop\AddressBook.json", serialize);
            Display();
        }
        public void Edit()
        {
            string Read = File.ReadAllText(@"C:\Users\yempc72\Desktop\AddressBook.json");
            list = (List<Details>)JsonConvert.DeserializeObject<List<Details>>(Read);
            Console.Write("Enter the FirstName: ");
            String name = Console.ReadLine();
            Console.WriteLine("F-->Edit FirstName\nL-->Edit Last Name\nA-->Edit Address\nC-->Edit City\nS-->Edit State\nZ-->Edit Zip\nP-->Edit Phone Number");
            string edit = Console.ReadLine();
            edit.ToUpper();
            foreach (var obj in list)
            {
                if (obj.FirstName.Equals(name))
                {
                    switch (edit)
                    {
                        case "F":
                            Console.Write("Edit First Name: ");
                            string Replace = Console.ReadLine();
                            Console.WriteLine($"{obj.FirstName} Renamed {Replace}");
                            obj.FirstName = Replace;
                            break;
                        case "L":
                            Console.Write("Edit Last Name: ");
                            string LastName = Console.ReadLine();
                            Console.WriteLine($"{obj.LastName} Renamed {LastName}");
                            obj.LastName = LastName;
                            break;
                        case "A":
                            Console.Write("Edit Address: ");
                            string Address = Console.ReadLine();
                            Console.WriteLine($"{obj.Address} Renamed {Address}");
                            obj.Address = Address;
                            break;
                        case "C":
                            Console.Write("Edit City: ");
                            string City = Console.ReadLine();
                            Console.WriteLine($"{obj.City} Renamed {City}");
                            obj.City = City;
                            break;
                        case "S":
                            Console.Write("Edit State: ");
                            string State = Console.ReadLine();
                            Console.WriteLine($"{obj.State} Renamed {State}");
                            obj.State = State;
                            break;
                        case "Z":
                            Console.Write("Edit Zip: ");
                            string Zip = Console.ReadLine();
                            Console.WriteLine($"{obj.Zip} Changed {Zip}");
                            obj.Zip = Zip;
                            break;
                        case "P":
                            Console.Write("Edit Phone: ");
                            string Phone = Console.ReadLine();
                            Console.WriteLine($"{obj.PhoneNo} Changed {Phone}");
                            obj.PhoneNo = Phone;
                            break;
                        default:
                            Console.WriteLine("Pressed Wrong key Enter Again ..................");
                            Edit();
                            break;
                    }
                }
            }
            string Serialize = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"C:\Users\yempc72\Desktop\AddressBook.json", Serialize);
            Selection();
        }
    }
}
