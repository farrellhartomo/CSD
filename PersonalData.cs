using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CSD
{

    public class PersonalData : IGenericOperation
    {
        public int PersonID { set; get; }
        public Person person;
        public List<Address> addressList;

        public PersonalData()
        {
            person = new Person();
            addressList = new List<Address>();
        }



        public PersonalData(int i, Person p, Address a)
        {
            this.PersonID = i;
            this.person = p;
            addressList = new List<Address>();
            this.addressList.Add(a);
        }

        public PersonalData(int i, string fn, string ln, string bd, string st, string ct,string stt, string zip)
        {
            this.PersonID = i;
            Address addr = new Address("home",st,ct,stt,zip);
            addressList =  new List<Address>();
            this.addressList.Add(addr);
            this.person = new Person(fn,ln,bd);
        }

        public Address GetAddressByID(string id)
        {
            Address temp = new Address();
            for (int i = 0; i < addressList.Count; i++)
            {
                if (addressList[i].AddressID == id)
                {
                    temp = addressList[i];
                }
            }
            return temp;
        }

        public void Print()
        {
            Console.WriteLine("ID: {0}", PersonID);
            Console.WriteLine("Name: {0}", person.PersonName);
            Console.WriteLine("Birthday: {0}", person.BirthDay);
            foreach (var i in addressList)
            {
                i.Print();
            }
        }


    }

    public interface IPersonalData
    {
        Address GetAddressByID(int id);
        ArrayList GetPersonalData();
    }
}

