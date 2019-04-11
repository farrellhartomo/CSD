using System;
using System.Collections.Generic;

namespace CSD
{
    public class Print : IPrinting
    {
        public void PrintCollection(List<PersonalData> p)
        {
            var x = p.GetEnumerator();

            while (x.MoveNext())
            {
                PrintPersonalData(x.Current);
            }
        }

        public void PrintAddress(Address a)
        {
            if (a is Address)
            {
                Console.WriteLine("Personal Address : {0}, {1}, {2}", a.Street, a.City, a.State);
                Console.WriteLine("Zip/Postal Code: {0}", a.PostNumber);
            }
            else if (a is WorkAddress)
            {
                Console.WriteLine("Work Address : {0}", a.FullAddress());
                Console.WriteLine("Zip/Postal Code: {0}", a.PostNum());
            }
            else
            {
                Console.WriteLine("No Address.");
            }
        }

        public void PrintPersonalData(PersonalData pd)
        {
            Console.WriteLine("ID: {0}", pd.PersonID);
            Console.WriteLine("Name: {0}", pd.person.PersonName);
            Console.WriteLine("Birthday: {0}", pd.person.Birthday);
            foreach (var i in pd.addressList)
            {
                PrintAddress(i);
            }
        }
        public void PrintPerson(Person pd)
        {
            Console.WriteLine("Name: {0}", pd.PersonName);
            Console.WriteLine("Birthday: {0}", pd.Birthday);
        }
    }
}