using System.Collections;

namespace CSD
{
    public interface IPersonalData1
    {
        Address CreateAddress(string street, string city, string state, string post);
        Person CreatePerson(string fname, string lname, string bday);
        bool Equals(object obj);
        string[] GetAddress();
        ArrayList GetPersonalData();
        void Print();
        void PrintDataEntity();
        void SetAddress(string street, string city, string state, string post);
        void SetPersonalData(int i, Person p, Address a);
        void SetPersonName(string fname, string lname);
    }
}