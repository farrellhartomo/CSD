using System;
using System.Collections.Generic;

namespace CSD
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IPDColl _PDColl =  ClassDependency.PDColl();
            PersonalData _PersonalData = new PersonalData();
            Person _person = new Person();
            Address _address = new Address();
            WorkAddress _workAddress = new WorkAddress();

            Console.WriteLine("Loading data!");
            _PersonalData = new PersonalData(1,"Fx", "Yuhu", "20.03.1993", "Ab road", "mlm", "swe", "098"); _PDColl.AddData(_PersonalData);
            _PersonalData = new PersonalData(2, "CU", "lala", "10.04.1994", "cd road", "upp", "ops", "012"); _PDColl.AddData(_PersonalData);
            _PersonalData = new PersonalData(3, "Fx", "Yohi", "13.05.1992", "fg road", "sto", "idr", "056"); _PDColl.AddData(_PersonalData);
            _PersonalData = new PersonalData(4, "Fpp", "Yawhu", "22.06.1991", "hi road", "spt", "fkr", "021"); _PDColl.AddData(_PersonalData);

            _PDColl.SetEnum();
            _PDColl.Print();

            _PDColl.SearchByID(3).Print();

            //// call dependency interfaces
            //IPersonalData PD = ClassDependency.CRUDPersonData();
            //IPDColl PDCollections = ClassDependency.PDColl();

            //// initiate data
            //Console.WriteLine("Loading data!");
            //PDCollections.Add(new PersonalData(1, PD.CreatePerson("Fx", "Yuhu", "20.03.1993"), PD.CreateAddress("Ab road", "mlm", "swe", "098")));
            //PDCollections.Add(new PersonalData(2, PD.CreatePerson("Cu", "Lala", "04.01.1994"), PD.CreateAddress("Ct road", "klk", "idr", "087")));
            //PDCollections.Add(new PersonalData(3, PD.CreatePerson("Hu", "Heho", "06.02.1995"), PD.CreateAddress("jik vag", "ume", "swe", "111")));
            //PDCollections.Add(new PersonalData(4, PD.CreatePerson("Vi", "Ses", "07.04.1993"), PD.CreateAddress("gij rud", "kla", "pol", "564")));


            //Console.WriteLine("Data has been loaded! Press any key. \n");
            //// Console.WriteLine("------ Print all data -----");
            //Console.ReadKey();
            //Console.Clear();

            //bool exit = true;
            //do
            //{
            //    Console.WriteLine("Lab Assignment - Farrell Yodihartomo");
            //    Console.WriteLine("Contemporary Software Development - Uppsala University");
            //    Console.WriteLine("2IS055 - Spring 2019");
            //    Console.WriteLine("\n \n---- Menu -----");
            //    Console.WriteLine("Select the operation: ");
            //    Console.WriteLine("1. Create new person (empty address)");
            //    Console.WriteLine("2. Create new person (with address)");
            //    Console.WriteLine("3. Update person name by ID");
            //    Console.WriteLine("4. Search by ID");
            //    Console.WriteLine("5. Search by full name");
            //    Console.WriteLine("99. Delete all the records");
            //    Console.WriteLine("0. Exit");
            //    Console.Write("Your input: ");


            //    int UserInput = Convert.ToInt32(Console.ReadLine());
            //    PersonalData temp = new PersonalData();
            //    Random rnd = new Random();
            //    int setId = rnd.Next(1, 99);
            //    switch (UserInput)
            //    {

            //        case 0:
            //            Console.WriteLine("You are exitting the program.\n");
            //            exit = false;
            //            break;
            //        case 1:
            //            Console.Clear();

            //            Console.WriteLine("Create new personal data\n\n");
            //            Console.Write("Input first name:"); string fname = Console.ReadLine();
            //            Console.Write("Input last name:"); string lname = Console.ReadLine();
            //            Console.Write("Input your birthday (DDMMYYYY):"); string bday = Console.ReadLine();

            //            temp.CreateDefaultPD();
            //            temp.SetID(setId);
            //            temp.SetPersonName(fname, lname);
            //            temp.SetPersonBDay(bday);
            //            PDCollections.Add(temp);

            //            Console.WriteLine("New data has been stored.");
            //            Console.WriteLine("DataID is: {0}",PDCollections.SearchByID(setId).GetID());

            //            Console.WriteLine(" \n\n\nPress any key. \n");
            //            Console.ReadKey();
            //            Console.Clear();
            //            temp = default(PersonalData);
            //            break;
            //        case 2:
            //            Console.Clear();

            //            Console.WriteLine("Create new personal data\n\n");
            //            Console.Write("Input first name: "); fname = Console.ReadLine();
            //            Console.Write("Input last name: ");  lname = Console.ReadLine();
            //            Console.Write("Input your birthday (DDMMYYYY) :"); bday = Console.ReadLine();
            //            Console.Write("Input your street address: "); string street = Console.ReadLine();
            //            Console.Write("Input your city: "); string city = Console.ReadLine();
            //            Console.Write("Input your state: "); string state = Console.ReadLine();
            //            Console.Write("Input your post number: "); string post = Console.ReadLine();

            //            Person tempPerson = temp.CreatePerson(fname, lname, bday);
            //            Address tempAddress = temp.CreateAddress(street, city, state, post);
            //            temp.SetPersonalData(setId,tempPerson,tempAddress);

            //            PDCollections.Add(temp);
            //            Console.WriteLine("New data has been stored.");
            //            Console.WriteLine("DataID is: {0}", PDCollections.SearchByID(setId).GetID());

            //            Console.WriteLine(" \n\n\nPress any key. \n");
            //            Console.ReadKey();
            //            Console.Clear();
            //            temp = default(PersonalData);
            //            break;
            //        case 3:
            //            Console.Clear();

            //            Console.WriteLine("Update new personal name by ID\n\n");
            //            Console.Write("Type the ID here: ");
            //            int idSearch = Convert.ToInt32(Console.ReadLine());
            //            temp = PDCollections.SearchByID(idSearch);
            //            fname = Console.ReadLine();
            //            lname = Console.ReadLine();
            //            temp.SetPersonName(fname, lname);

            //            //temp.SearchByID(idSearch);

            //            Console.WriteLine(" \n\n\nPress any key. \n");
            //            Console.ReadKey();
            //            Console.Clear();
            //            temp = default(PersonalData);
            //            break;
            //        case 4:
            //            Console.Clear();

            //            Console.Write("Search by ID. Type the ID here: ");
            //            idSearch = Convert.ToInt32(Console.ReadLine());
            //            temp = PDCollections.SearchByID(idSearch);
            //            temp.Print();

            //            Console.WriteLine(" \n\n\nPress any key. \n");
            //            Console.ReadKey();
            //            Console.Clear();
            //            temp = default(PersonalData);
            //            break;
            //        case 5:
            //            Console.Clear();
            //            Console.Write("Search by Name. Type full name here: ");
            //            string nameSearch = Console.ReadLine();
            //            temp = PDCollections.SearchByName(nameSearch);
            //            temp.Print();

            //            Console.WriteLine(" \n\n\nPress any key. \n");
            //            Console.ReadKey();
            //            Console.Clear();
            //            break;
            //        case 99:
            //            Console.Clear();
            //            Console.Write("Are you sure (type 'Yes' or 'No')");
            //            string ans = Console.ReadLine();
            //            if(ans == "yes")
            //            {
            //                PDCollections.Clear();
            //                Console.Write("Clear all the database");
            //            }
            //            break;
            //        default:
            //            Console.WriteLine("\n\nPlease give a proper input..\n");
            //            break;
            //    }
            //} while (exit);
        }
    }
}
