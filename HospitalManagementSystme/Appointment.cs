using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalManagementSystem
{
    internal class Appointment
    {
        public int ID { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Appointment() { }

        public Appointment(int id , int doctorid, int patientid, DateTime date, string status)
        {
            ID = id;
            DoctorId = doctorid;
            PatientId = patientid;
            Date = date;
            Status = status;

        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID} | DoctorId: {DoctorId} | PatientId: {PatientId} | Date: {Date} | Status: {Status}");
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine("Status updated successfully!");
            DisplayInfo();
            
        }
        public override string ToString()
        {
            return $"Appointment ID: {ID}, DoctorId: {DoctorId}, PatientId: {PatientId}, Date: {Date}, Status: {Status} ";
        }


    }
}
