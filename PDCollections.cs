using System;
using System.Collections.Generic;

namespace CSD
{
    public class PDCollections : IPDColl
    {
        private List<PersonalData> PDColl;

        public PDCollections()
        {
            PDColl = new List<PersonalData>();
        }

        public int Count()
        {
            return this.PDColl.Count; 
        }

        public void Add(PersonalData item)
        {
            this.PDColl.Add(item);
        }

        public void Clear()
        {
            PDColl.Clear();
        }

        public bool ContainsID(int id)
        {
            bool result = false;

            for (int i = 0; i < PDColl.Count;i++)
            {
                PersonalData temp = PDColl[i];
                if (temp.ID ==id)
                {
                    result = true;
                }
            }
            return result;
        }

        public PersonalData SearchByName(string name)
        {
            PersonalData temp = PDColl.Find(delegate (PersonalData p) {
                return p.GetPersonName() == name;
            });
            return temp;
        }

        public bool RemoveByID(int id)
        {
            bool temp = false;
            for (int i = 0; i < PDColl.Count; i++)
            {
                PersonalData CurrentItem = PDColl[i];
                if (PDColl[i].ID == id)
                {
                    PDColl.RemoveAt(i);
                    break;
                }

            }
            return temp;
        }
    }

    interface IPDColl
    {
        void Add(PersonalData item);
        void Clear();
        int Count();
        PersonalData SearchByName(string name);
        bool RemoveByID(int id);
        bool ContainsID(int id);
    }
}