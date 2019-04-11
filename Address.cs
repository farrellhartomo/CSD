using System;

namespace CSD
{
    //Class Address
    public class Address
    {
        public string AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostNumber { get; set; }

        public Address(string id, string street, string city, string state, string post)
        {
            this.AddressID = id;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostNumber = post;
        }

        public Address()
        {

        }

        public bool UpdateAddress(string street, string city, string state, string post)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostNumber = post;
            return true;
        }

        public string FullAddress()
        {
            return Street + "," + City + "," + State;
        }

        public string PostNum()
        {
            return this.PostNumber;
        }


    }
}

