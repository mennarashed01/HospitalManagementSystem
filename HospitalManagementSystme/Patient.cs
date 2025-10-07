using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    internal class Patient: User
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public Patient() { }

        public Patient(int id, string name, string phone, int age, string gender, string address)
            : base(id, name, phone)
        {
            Age = age;
            Gender = gender;
            Address = address;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} | Name: {Name} | Phone: {Phone} | Age: {Age} | Gender: {Gender} | Address: {Address}");

        }
        public override string ToString()
        {
            return $"Patient ID: {Id}, Name: {Name}, Phone: {Phone}, Age: {Age}, Gender: {Gender}, Address: {Address}";
        }



    }
}
