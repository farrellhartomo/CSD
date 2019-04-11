using System;

namespace CSD
{
    public class Person 
    {

        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string Birthday { get; set; }

        public Person(string fname, string lname, string bday)
        {
            this.PersonFirstName = fname;
            this.PersonLastName = lname;
            this.Birthday = bday;
        }

        public Person()
        {

        }

        public bool PersonNameDuplicateCheck(string name)
        {
            if (this.PersonName == name)
                return false;
            else return true;
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
                return PersonFirstName + " " + PersonLastName;
            }
        }

        public void UpdatePerson(string fname, string lname, string bday)
        {
            this.PersonFirstName = fname;
            this.PersonLastName = lname;
            this.Birthday = bday;
        }

        public void Print()
        {
            Console.WriteLine("Person name: {0} {1}", this.PersonFirstName, this.PersonLastName);
            Console.WriteLine("Birthday: {0}", this.Birthday);
        }
    }
}
