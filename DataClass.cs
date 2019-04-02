using System;
using System.Collections;
using System.Collections.Generic;

namespace CSD
{

    public class Person : IPerson
    {
        private string PersonFirstName { get; set; }
        private string PersonLastName { get; set; }
        private string Birthday { get; set; }
        private List<Address> Address = new List<Address>();

        public void SetPerson(string fname, string lname, string bday)
        {
            this.PersonFirstName = fname;
            this.PersonLastName = lname;
            this.Birthday = bday;
        }

        public string PersonName
        {
            get
            {
                return PersonFirstName + PersonLastName;
            }
            set
            {
                this.PersonFirstName = value;
                this.PersonLastName = value;
            }
        }



        public string BirthDay
        {
            get { return this.Birthday; }
            set { this.Birthday = value; }
        }
        public void AddAddress(Address addr)
        {
            this.Address.Add(addr);
        }

        public void Print()
        {
            Console.WriteLine("Person name: {0} {1}", this.PersonFirstName, this.PersonLastName);
            Console.WriteLine("Birthday: {0}", this.Birthday);
            object[] obj = this.Address.ToArray();
            foreach (object value in obj)
            {
                Address item = (Address)value;
                item.PrintAddress();
            }
        }
    }

    public class Address
    {
        private Person Person { get; set; }
        private string Street { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string PostNumber { get; set; }

        public Address(Person p)
        {
            this.Person = p;
        }

        public void SetAddress(string street, string city, string state, string post)
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

        public WorkAddress(Person p, string oname) : base(p)
        {
            this.OfficeName = oname;
        }

        public WorkAddress(Person p) : base(p) { }
    }

    interface IPerson
    {
        void SetPerson(string fname, string lname, string bday);
        void AddAddress(Address addr);
        void Print();
        string PersonName { get; set; }
        string BirthDay { get; set; }
    }

    public class PersonalData : IPersonData
    {
        private int PersonID;
        public Dictionary<int, Person> PersonData = new Dictionary<int, Person>();
        Person person = new Person();

        private int SetID()
        {
            Random rnd = new Random();
            int numID = rnd.Next(100, 199);
            return numID;
        }

        public void SetPersonalData(Person p)
        {
            this.PersonID = SetID();
            this.person = p;
            PersonData.Add(this.PersonID, this.person);
        }


        public List<Person> GetPersonalData(int id)
        {
            if (false)
            {
                throw new ArgumentNullException(nameof(id));
            }

            List<Person> tempPerson = new List<Person>();
            string SearchID = id.ToString();
            foreach(var item in PersonData)
            {
                if (item.Key.ToString().Contains(SearchID))
                {
                    tempPerson.Add(item.Value);
                }
                else
                {
                    return null;
                }
            }
            return tempPerson;
        }

        public void PrintPersonalData()
        {
            foreach(var item in PersonData)
            {
                Console.WriteLine("Full Name: {0}", item.Value.PersonName);
                Console.WriteLine("Birthday: {0}",item.Value.BirthDay);
                item.Value.Print();
            }
        }
    }

    interface IPersonData
    {
        void SetPersonalData(Person p);
        void PrintPersonalData();
    }

    class ClassDependency
    {
        public static IPerson CRUDPerson()
        {
            return new Person();
        }
        public static IPersonData CRUDPersonData()
        {
            return new PersonalData();
        }
    }
}
