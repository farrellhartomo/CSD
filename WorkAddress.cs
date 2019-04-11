using System;

namespace CSD
{
    public class WorkAddress : Address
    {
        public string OfficeName { get; set; }

        public WorkAddress() { }

        public WorkAddress(string aID, string street, string city, string state, string post, string oname) : base(aID, street, city, state, post)
        {
            OfficeName = oname;
        }
    }
}

