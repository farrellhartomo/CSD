using NUnit.Framework;
using System;
using CSD;
namespace CSD_Testing
{
    [TestFixture()]
    public class TestPerson
    {
        Person _Person = new Person();

        [TestCase()] //TestPerson
        public void TestPersonCreated()
        {
            _Person = new Person("haha", "hihi", "20.09.2019");
            Assert.AreEqual("haha", _Person.PersonFirstName);
            Assert.AreEqual("hihi", _Person.PersonLastName);
            Assert.AreEqual("20.09.2019", _Person.Birthday);
        }

        [TestCase()]
        public void TestPersonUpdate()
        {
            _Person = new Person("haha", "huhu", "21.08.2011");
            _Person.UpdatePerson("viktor", "Jonsson", "04.03.2009");
            Assert.AreEqual("viktor", _Person.PersonFirstName);
            Assert.AreEqual("Jonsson", _Person.PersonLastName);
            Assert.AreEqual("04.03.2009", _Person.Birthday);
        }

        [TestCase()]
        public void PersonCheckNotNull()
        {
            _Person = new Person("haha", "huhu", "21.08.2011");
            _Person.UpdatePerson("", "", "");
            Assert.IsNotNullOrEmpty(_Person.PersonFirstName + " " + _Person.PersonLastName, "Empty");
        }

        [TestCase()]
        public void PersonReturnNullException()
        {
            Assert.Throws<ArgumentNullException>(()=> new Person(null,null,null));
        }
    }

    [TestFixture()]
    public class TestAddress
    {
        Address _address = new Address();

        [TestCase()]
        public void TestCreateAddress()
        {
            _address = new Address("Home", "SV", "Upp", "Swe","75626");
            Assert.AreEqual("Home",_address.AddressID);
            Assert.AreEqual("SV",_address.Street);
            Assert.AreEqual("Upp",_address.City);
            Assert.AreEqual("Swe",_address.State);
            Assert.AreEqual("75626",_address.PostNumber);
        }

        [TestCase()]
        public void TestUpdateAddress()
        {
            _address = new Address("Home", "SV", "Upp", "Swe", "75626");
            _address.UpdateAddress("SJ","Gvl","Swed","76767");
            Assert.AreEqual("SJ", _address.Street);
            Assert.AreEqual("Gvl", _address.City);
            Assert.AreEqual("Swed", _address.State);
            Assert.AreEqual("76767", _address.PostNumber);
        }

        [TestCase()]
        public void TestAddressUpdateNull()
        {
            _address = new Address("Home", "SV", "Upp", "Swe", "75626");
            Assert.False(_address.UpdateAddress(null, null, null, null),"fail update");
        }
    }

    [TestFixture()]
    public class TestPersonalData
    {
        public PersonalData _PersonData = new PersonalData();

        [TestCase()]
        public void TestCreatePD()
        {
            var person = new Person("haha", "hihi", "20.09.2019");
            var addr = new Address("Home", "SV", "Upp", "Swe", "75626");

            _PersonData = new PersonalData(1, person, addr);

            Assert.AreEqual("haha", _PersonData.person.PersonFirstName);
            Assert.AreEqual("hihi", _PersonData.person.PersonLastName);
            Assert.AreEqual("20.09.2019", _PersonData.person.Birthday);
            Assert.AreEqual("Home", _PersonData.GetAddressByID("Home").AddressID);
            Assert.AreEqual("SV", _PersonData.GetAddressByID("Home").Street);
            Assert.AreEqual("Upp", _PersonData.GetAddressByID("Home").City);
            Assert.AreEqual("Swe", _PersonData.GetAddressByID("Home").State);
            Assert.AreEqual("75626", _PersonData.GetAddressByID("Home").PostNumber);
        }

        [TestCase()]
        public void TestGetPersonPDbyID()
        {
            _PersonData = new PersonalData(1, "haha", "hihi", "20.09.2019", "SV", "Upp", "Swe", "75626");

            Assert.AreEqual("SV", _PersonData.GetAddressByID("home").Street);
        }

        [TestCase()]
        public void TestNullAddress()
        {
            Assert.Throws<ArgumentNullException>(()=> new PersonalData(1, null, null, null, null, null, null, null));
        }

    }

    [TestFixture()]
    public class TestPDColl
    {
        PDCollections _PD = new PDCollections();
        PersonalData _PersonData = new PersonalData();

        [TestCase()]
        public void CreatePDColl()
        {
            _PersonData = new PersonalData(1, "haha", "hihi", "20.09.2019", "SV", "Upp", "Swe", "75626");
            _PD.AddData(_PersonData);
            _PD.SetEnum();

            Assert.AreEqual(_PersonData,_PD.SearchByID(1));
        }

        [TestCase()]
        public void TestNullPDColl()
        {
            Assert.Throws<ArgumentNullException>(() => _PD.AddData(null));
        }

        [TestCase()]
        public void TestCollectionCreated()
        {
            _PersonData = new PersonalData(1, "haha", "hihi", "20.09.2019", "SV", "Upp", "Swe", "75626");
            _PD.AddData(_PersonData);

            Assert.IsNotNull(_PD.GetPDCollection());
        }
    }
}