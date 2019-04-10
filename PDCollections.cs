using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CSD
{
    public class PDCollections : IPDColl, IGenericOperation, IEnumerable<PersonalData>
    {
        private List<PersonalData> PDColl = new List<PersonalData>();
        private IEnumerator<PersonalData> PDColEnum;

        public PDCollections()
        {
            PDColl = new List<PersonalData>();
            PDColEnum = PDColl.GetEnumerator();
        }

        public void SetupCollection()
        {
            PDColl = new List<PersonalData>();
            PDColEnum = PDColl.GetEnumerator();
        }

        public void SetEnum()
        {
            PDColEnum = PDColl.GetEnumerator();
        }

        //create by singular PDColl
        public void AddData(PersonalData p)
        {
            if (p != null)
            {
                PDColl.Add(p);
            }
        }


        public void Clear()
        {
            PDColl.Clear();
        }

        public bool ContainsID(int id)
        {
            if (PDColEnum.Current.PersonID == id) return true; 
            return false;
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

            while (updateStat == false && !PDColEnum.MoveNext())
            {
                if (PDColEnum.Current.PersonID == person_id && address_id != null)
                {
                    PDColEnum.Current.GetAddressByID(address_id).UpdateAddress(street,city,state,post); 
                    updateStat = true;
                    PDColEnum.Reset();
                }
                else
                {
                    PDColEnum.MoveNext();
                }
            }


            return updateStat;
        }

        public PersonalData SearchByID(int id)
        {
            PDColEnum.Reset();
            while (PDColEnum.MoveNext())
            {
                if (ContainsID(id))
                {
                    return PDColEnum.Current;
                }
                else
                {
                    PDColEnum.MoveNext();
                }
            }      
            return null;
        }

        public PersonalData SearchByName(string name)
        {
            PDColEnum.Reset();
            while (PDColEnum.MoveNext())
            {
                if (PDColEnum.Current.person.PersonName == name)
                {
                    return PDColEnum.Current;
                }
                else
                {
                    PDColEnum.MoveNext();
                }
            }
            return null;
        }

        public bool RemoveByID(int id)
        {

            for (int i = 0; i < PDColl.Count; i++)
            {
                var item = this.PDColl[i];
                if (item.PersonID == id)
                {
                    PDColl.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void PrintEach(string name)
        {
            //print each
            PersonalData temp = SearchByName(name);
            temp.Print();
        }

        public void Print()
        {
            //print all
            PDColEnum.Reset();
            while (PDColEnum.MoveNext())
            {
                PDColEnum.Current.Print();
            }
        }

        public IEnumerator<PersonalData> GetEnumerator()
        {
            return new PDCollEnum(PDColl);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
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
        void SetEnum();
        void SetupCollection();
        void AddData(PersonalData item);
        void Clear();
        bool ContainsID(int id);
        bool UpdatePersonAddress(int person_id, string address_id, string street, string city, string state, string post);
        bool UpdatePersonData(int id, string fname, string lname, string bday);
        PersonalData SearchByID(int id);
        PersonalData SearchByName(string name);
        bool RemoveByID(int id);
        void PrintEach(string name);
        void Print();
    }
}