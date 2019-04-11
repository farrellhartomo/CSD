using System.Collections.Generic;

namespace CSD
{
    class ClassDependency
    {
        public static IPDColl PDColl()
        {
            return new PDCollections();
        }
        public static IPrinting Print()
        {
            return new Print();
        }
    }

    interface IGenericOperation
    {

    }

    interface IPrinting
    {
        void PrintCollection(List<PersonalData> p);
        void PrintAddress(Address a);
        void PrintPerson(Person pd);
        void PrintPersonalData(PersonalData pd);
        //void PrintInJson();
    }

    //public void PrintDataEntityInJson()
    //{
    //    Console.Write("{ ");
    //    for (int i = 0; i < this.Count; i++)
    //    {
    //        if (i < (dataprint.Count - 1))
    //        {
    //            object item = dataprint[i];
    //            Console.Write(item);
    //            Console.Write(", ");
    //        }
    //        else
    //        {
    //            object item = dataprint[i];
    //            Console.Write(item);
    //        }

    //    }
    //    Console.Write(" }");
    //    Console.WriteLine();
    //}
}
