using System;
using System.Collections.Generic;

namespace CSD
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            // call dependency interfaces
            IPerson person = ClassDependency.CRUDPerson();
            IPersonData personData = ClassDependency.CRUDPersonData();


            // initiate data
            Console.WriteLine("Loading data!");


            Console.WriteLine("Data has been loaded!");


        }
    }
}
