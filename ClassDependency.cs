using System.Collections.Generic;

namespace CSD
{
    class ClassDependency
    {
        public static IPDColl PDColl()
        {
            return new PDCollections();
        }
    }

    interface IGenericOperation
    {
        void Print();
    }

    interface Printing
    {
        void PrintInJson();
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
