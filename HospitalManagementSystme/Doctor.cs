using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    internal class Doctor :User
    {
        public string Email { get; set; }
        public string Specialization { get; set; }

        public Doctor() { }
        public Doctor(int id, string name, string phone, string email, string specialization):base(id, name, phone)
        {
            Email = email;
            Specialization = specialization;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} | Name: {Name} | Phone: {Phone} | Email: {Email} | Specialization: {Specialization}");
        }

        public override string ToString()
        {
            return $"Doctor ID: {Id}, Name: {Name}, Phone: {Phone}, Email: {Email}, Specialization: {Specialization}";
        }

    }
}
