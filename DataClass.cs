using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CSD
{

    public class Person 
    {
        
        private string PersonFirstName { get; set; }
        private string PersonLastName { get; set; }
        private string Birthday { get; set; }
        //private List<Address> Address { get; set; }

        public Person(string fname, string lname, string bday)
        {
            this.PersonFirstName = fname;
            this.PersonLastName = lname;
            this.Birthday = bday;
        }

        public Person()
        {
            this.UpdateName(PersonFirstName, PersonLastName);
            this.Birthday = BirthDay;
        }

        public void UpdateName(string fname, string lname)
        { 
            this.PersonFirstName = fname;
            this.PersonLastName = lname;
        }

        public string PersonName
        {
            get
            {
                return PersonFirstName +" "+ PersonLastName;
            }
        }

        public string BirthDay
        {
            get { return this.Birthday; }
            set { this.Birthday = value; }
        }

        //public void SetAddress(Address a)
        //{
        //    this.Address.Add(a);
        //}

        public void Print()
        {
            Console.WriteLine("Person name: {0} {1}", this.PersonFirstName, this.PersonLastName);
            Console.WriteLine("Birthday: {0}", this.Birthday);
        }
    }

    //Class Address
    public class Address
    {
        private int AddressID; 
        private string Street { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string PostNumber { get; set; }

        public Address(int aID,string street, string city, string state, string post) 
        {
            this.AddressID = aID;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostNumber = post;
        }

        public Address()
        {
            this.UpdateAddress(Street, City, State, PostNumber);
        }

        public void UpdateAddress(string street, string city, string state, string post)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostNumber = post;
        }

        public string FullAddress()
        {
            return Street + "," + City + "," + State;
        }

        public string PostNum()
        {
            return this.PostNumber;
        }

        public virtual void PrintAddress()
        {
            Console.WriteLine("Personal Address : {0}, {1}, {2}", this.Street, this.City, this.State);
            Console.WriteLine("Zip/Postal Code: {0}", this.PostNumber);
        }


    }

    public class WorkAddress : Address
    {
        protected string OfficeName { get; set; }

        public WorkAddress() { }

        public WorkAddress(int aID, string street, string city, string state, string post,string oname): base ( aID,street, city, state, post)
        {
            SetOfficeName(oname);
        }

        public void SetOfficeName(string oname)
        {
            this.OfficeName = oname;
        }

        public override void PrintAddress()
        {
            Console.WriteLine("Work Address : {0}", base.FullAddress());
            Console.WriteLine("Zip/Postal Code: {0}", base.PostNum());
        }
    }

    public class PersonalData : IPersonalData
    {
        private int PersonID;
        private Person person;
        private List<Address> address;

        public PersonalData()
        {
            person = new Person();
            address = new List<Address>();
        }

        public int ID
        {
            get { return PersonID; }
            set { PersonID = value; }
        }

        public int GetID()
        {
            return this.PersonID;
        }

        public void SetID(int i)
        {
            this.PersonID = i;
        }

        public PersonalData(int i, Person p, Address a)
        {
            this.PersonID = i;
            this.person = p;
            address = new List<Address>();
            this.address.Add(a);
        }

        public string GetPersonName()
        {
            return this.person.PersonName;
        }

        public bool PersonNameDuplicateCheck(string name)
        {
            if (this.person.PersonName == name)
                return false;
            else return true;
        }

        public void CreateDefaultPD()
        {
            person = new Person();
            address = new List<Address>();
        }

        public void SetPersonalData(int i, Person p, Address a)
        {
            this.PersonID = i;
            this.person = p;
            this.address.Add(a);
        }

        public void SetPersonName(string fname, string lname)
        {
            this.person.UpdateName(fname, lname);
        }

        public void SetPersonBDay(string bday)
        {
            this.person.BirthDay = bday;
        }

        public void SetAddress(string street, string city, string state, string post)
        {
            Address tempAddr = new Address();
            tempAddr.UpdateAddress(street, city, state, post);
            this.address.Add(tempAddr);
        }

        public Person CreatePerson(string fname, string lname, string bday)
        {
            Person temp = new Person();
            temp.UpdateName(fname, lname);
            temp.BirthDay = bday;
            return temp;
        }

        public Address CreateAddress(string street, string city, string state, string post)
        {
            Address tempAddr = new Address();
            tempAddr.UpdateAddress(street, city, state, post);
            return tempAddr;
        }

        public string[] GetAddress()
        {
            string[] temp = new string[this.address.Count];
            for (int i = 0; i < address.Count; i++)
            {
                temp[i] = this.address.ToArray()[i].FullAddress();
            }
            return temp;
        }

        public ArrayList GetPersonalData()
        {
            ArrayList temp = new ArrayList();

            temp.Add(this.person.PersonName);
            temp.Add(this.person.BirthDay);
            if (address != null)
            {
                this.address.ForEach(delegate (Address a)
                {
                    temp.Add(a.FullAddress());
                    temp.Add(a.PostNum());
                });
            }

            return temp;
        }

        public void Print()
        {
            Console.WriteLine("ID: {0}", PersonID);
            Console.WriteLine("Name: {0}", person.PersonName);
            Console.WriteLine("Birthday: {0}", person.BirthDay);
            foreach (var i in address)
            {
                i.PrintAddress();
            }
        }

        public void PrintDataEntity()
        {
            ArrayList dataprint = GetPersonalData();
            Console.Write("{ ");
            for (int i = 0; i < dataprint.Count; i++)
            {
                if (i < (dataprint.Count - 1))
                {
                    object item = dataprint[i];
                    Console.Write(item);
                    Console.Write(", ");
                }
                else
                {
                    object item = dataprint[i];
                    Console.Write(item);
                }

            }
            Console.Write(" }");
            Console.WriteLine();
        }
    }


    public interface IPersonalData
    {
        void SetPersonName(string fname, string lname);
        void SetPersonBDay(string bday);
        int GetID();
        void SetID(int id);
        void CreateDefaultPD();
        void SetPersonalData(int i, Person p, Address a);
        Person CreatePerson(string fname, string lname, string bday);
        Address CreateAddress(string street, string city, string state, string post);
        ArrayList GetPersonalData();
        void Print();
        string[] GetAddress();
        void PrintDataEntity();
    }
}

