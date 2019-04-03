using System;
using System.Collections.Generic;

namespace CSD
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<PersonalData> PDCollection = new List<PersonalData>();
            // call dependency interfaces
            IPersonalData pd = ClassDependency.CRUDPersonData();


            // initiate data
            Console.WriteLine("Loading data!");
            PDCollection.Add(new PersonalData(1, pd.CreatePerson("Fx", "Yuhu", "20.03.1993"), pd.CreateAddress("Ab road", "mlm", "swe", "098")));
            PDCollection.Add(new PersonalData(2, pd.CreatePerson("Cu", "Lala", "04.01.1994"), pd.CreateAddress("Ct road", "klk", "idr", "087")));
            PDCollection.Add(new PersonalData(3, pd.CreatePerson("Hu", "Heho", "06.02.1995"), pd.CreateAddress("jik vag", "ume", "swe", "111")));
            PDCollection.Add(new PersonalData(4, pd.CreatePerson("Vi", "Ses", "07.04.1993"), pd.CreateAddress("gij rud", "kla", "pol", "564")));


            Console.WriteLine("Data has been loaded! \n");
            Console.WriteLine("------ Print all data -----");

            foreach (var item in PDCollection)
            {
                item.Print();
                Console.WriteLine();
            }

            Console.WriteLine("Printing in JSON \n");
            foreach (var item in PDCollection)
            {
                item.PrintDataEntity();
            }


        }
    }
}
