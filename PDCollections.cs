using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CSD
{
    public class PDCollections : IPDColl, IEnumerable<PersonalData>
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
            if (p != null && !IsExist(this.PDColl,p))
            {
                PDColl.Add(p);
            }
        }

        public List<PersonalData> GetPDCollection()
        {
            return this.PDColl;
        }


        public void Clear()
        {
            PDColl.Clear();
        }

        public bool ContainsID(int id)
        {
            return (PDColEnum.Current.PersonID == id);
        }


        private bool IsExist(List<PersonalData> pl,PersonalData pnew)
        {

            foreach(var p in pl)
            {
                if (p.PersonID == pnew.PersonID) {
                    return true;
                }
            }
            return false;
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
        List<PersonalData> GetPDCollection();
        void Clear();
        bool ContainsID(int id);
        PersonalData SearchByID(int id);
        PersonalData SearchByName(string name);
        bool RemoveByID(int id);
    }
}