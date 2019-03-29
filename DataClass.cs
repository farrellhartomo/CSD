using System;
using System.Collections.Generic;

namespace CSD
{
    public class person
    {
        public string personID { get; set; }
        public string personFirstName { get; set; }
        public string personLastName { get; set; }

        public person(string firstname,string lastname)
        {
            this.personFirstName = firstname;
            this.personFirstName = lastname;
        }

        public person(string ID, string firstname, string lastname)
        {
            this.personID = ID;
            this.personFirstName = firstname;
            this.personFirstName = lastname;
        }
    }

    public class address
    {
        public address(string street, string city, string state, string postNumber)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.postNumber = postNumber;
        }

        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postNumber { get; set; }
        
    }

    public class personalData
    {
        List<person> person = new person();
    }

    interface IMapping
    {

    }
}
