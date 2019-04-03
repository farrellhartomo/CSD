using System;
using System.Collections.Generic;

namespace CSD
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            // call dependency interfaces
            IPersonalData pd = ClassDependency.CRUDPersonData();


            // initiate data
            Console.WriteLine("Loading data!");
            pd.SetPersonalData(1,pd.CreatePerson("Fx", "Yuhu", "20.03.1993"),pd.CreateAddress("Ab road", "mlm", "swe", "098"));

            Console.WriteLine("Data has been loaded!");
            pd.Print();

        }
    }
}
