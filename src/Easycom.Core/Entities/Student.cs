using Easycom.Core.Base;

namespace Easycom.Core.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {

        }
        public Student(string name, string lastname, string phone, string address, string city, string state, string country)
        {
            Name = name;
            LastName = lastname;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            Country = country;
        }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }


    }
}
