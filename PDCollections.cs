using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CSD
{
    public class PDCollections : IPDColl, IGenericOperation, IEnumerable<PersonalData>
    {
        private List<PersonalData> PDColl;

        public PDCollections()
        {
            PDColl = new List<PersonalData>();
        }

        //create by singular PDColl
        public void AddData(PersonalData p)
        {
            PDColl.Add(p);
        }

        public int Count()
        {
            return this.PDColl.Count; 
        }

        public void Clear()
        {
            PDColl.Clear();
        }

        public bool ContainsID(int id)
        {
            bool state = false;

            for (int i = 0; i < PDColl.Count;i++)
            {
                PersonalData temp = PDColl[i];
                if (temp.PersonID ==id)
                {
                    state = true;
                }
            }
            return state;
        }

        public bool UpdatePersonData(int id,string fname,string lname,string bday)
        {
            bool updateStat = false;
            PersonalData temp = SearchByID(id); 
            if (ContainsID(id))
            {
                temp.person.PersonFirstName = fname;
                temp.person.PersonLastName = lname;
                temp.person.Birthday = bday;
                updateStat = true;
            }
            return updateStat;
        }

        public bool UpdatePersonAddress(int person_id, string address_id, string street, string city, string state, string post)
        {
            bool updateStat = false;
            var temp = PDColl.GetEnumerator();

            while (updateStat == false)
            {
                if (temp.Current.PersonID == person_id)
                {
                    temp.Current.GetAddressByID(address_id).UpdateAddress(street,city,state,post); 
                    updateStat = true;
                }
                else
                {
                    temp.MoveNext();
                }
            }


            return updateStat;
        }

        public PersonalData SearchByID(int id)
        {
            PersonalData temp = PDColl.Find(delegate (PersonalData p) {
                return p.PersonID == id;
            });
            return temp;
        }

        public PersonalData SearchByName(string name)
        {
            PersonalData temp = PDColl.Find(delegate (PersonalData p) {
                return p.person.PersonName == name;
            });
            return temp;
        }

        public bool RemoveByID(int id)
        {
            bool temp = false;
            for (int i = 0; i < PDColl.Count; i++)
            {
                PersonalData CurrentItem = PDColl[i];
                if (PDColl[i].PersonID == id)
                {
                    PDColl.RemoveAt(i);
                    break;
                }

            }
            return temp;
        }

        public void Print()
        {
            //print each 
        }

        public void PrintAll()
        {
            //print all
        }

        public IEnumerator<PersonalData> GetEnumerator()
        {
            return new PDCollEnum(PDColl);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class PDCollEnum : IEnumerator<PersonalData>
    {
        private List<PersonalData> _coll;
        private int currentIndex = -1;

        public PDCollEnum(List<PersonalData> pd)
        {
            _coll = pd;
        }

        public PersonalData Current
        {
            get
            {
                try
                {
                    return _coll[currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        object IEnumerator.Current => this.Current;

        PersonalData IEnumerator<PersonalData>.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;
            return (currentIndex < _coll.Count);
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }


    interface IPDColl
    {
        void AddData(PersonalData item);
        int Count();
        void Clear();
        bool ContainsID(int id);
        PersonalData SearchByID(int id);
        bool UpdatePersonData(int id, string fname, string lname, string bday);
        PersonalData SearchByName(string name);
        bool RemoveByID(int id);
    }
}