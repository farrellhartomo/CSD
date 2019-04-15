using NUnit.Framework;
using System;
using CSD;
namespace CSD_Testing
{
    [TestFixture()]
    public class TestPerson
    {
        public Person _Person = new Person();

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

        }
    }

    [TestFixture()]
    public class TestAddress
    {
        public Address _address = new Address();

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
        public void TestUpdateAddress()
        {
            _address = new Address("Home", "SV", "Upp", "Swe", "75626");
            _address.UpdateAddress("SJ","Gvl","Swed","76767");
            Assert.AreEqual("SJ", _address.Street);
            Assert.AreEqual("Gvl", _address.City);
            Assert.AreEqual("Swed", _address.State);
            Assert.AreEqual("76767", _address.PostNumber);
        }

    }
}