using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    internal class Hospital
    {
        public Doctor[] Doctors= new Doctor[100];
        private int numberofDoctors =0 ;

        public Patient[] patients = new Patient[500];
        private int numberofPatients = 0;

        public Appointment[] appointments = new Appointment[200];
        private int numberofAppointments = 0;

        public void UpdateDoctorCount()
        {
            numberofDoctors = 0;
            for (int i = 0; i < Doctors.Length; i++)
            {
                if (Doctors[i] != null)
                { numberofDoctors++; }
            }
        }
        public void UpdatePatientCount()
        {
            numberofPatients = 0;
            for (int i = 0; i < patients.Length; i++)
            {
                if (patients[i] != null)
                { numberofPatients++; }
            }
        }
        public void UpdateAppointmentCount()
        {
            numberofAppointments = 0;
            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i] != null)
                { numberofAppointments++; }
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            if (numberofDoctors < Doctors.Length)
            {
                Doctors[numberofDoctors] = doctor;
                numberofDoctors++;
                Console.WriteLine("Doctor added successfully!");
            }
            else
            {
                Console.WriteLine("Error: Doctor list is full!");
            }
        }
        public void AddPatient(Patient patient)
        {
            patients[numberofPatients] = patient;
            numberofPatients++;
            Console.WriteLine("Patient added successfully :)");
        }
        public void AddAppointment(Appointment appointment)
        {
            appointments[numberofAppointments] = appointment;
            numberofAppointments++;
            Console.WriteLine("Appointment added successfully :)");
        }
        public void SearchDoctorByID (int id)
        {
            for(var i =0; i< numberofDoctors; i++)
            {
                if(Doctors[i].Id == id)
                {
                    Console.WriteLine("Doctor found!");
                    Doctors[i].DisplayInfo();
                    return;
                }
            }
            Console.WriteLine("Doctor Not found !"); 
        }
        public Appointment SearchAppointmentByID(int id)
        {
            for (var i = 0; i < numberofAppointments; i++)
            {
                if (appointments[i].ID == id)
                {
                    return appointments[i];
                }
            }
            return null;
        }
        public void SearchPatientByID(int id)
        {
            for (var i = 0; i < numberofPatients; i++)
            {
                if (patients[i].Id == id)
                {
                    Console.WriteLine("Patient found!");
                    patients[i].DisplayInfo();
                    return;
                }
            }
            
            Console.WriteLine("Patient Not found!");
        }
        public void ViewAllDoctors()
        {
            if (numberofDoctors == 0)
            {
                Console.WriteLine("No Doctors available.");
                return;
            }
            for (var i =0;i< numberofDoctors; i++)
            {
                Console.WriteLine(Doctors[i].ToString());
            }
        }
        public void ViewAllPatients()
        {
            if (numberofPatients == 0)
            {
                Console.WriteLine("No Patients available.");
                return;
            }
            for (var i = 0; i < numberofPatients; i++)
            {
                Console.WriteLine(patients[i].ToString());
            }
        }
        public void ViewAllAppointments()
        {
            if(numberofAppointments == 0)
            {
                Console.WriteLine("No Appointments available.");
                return;
            }

            for (var i = 0; i < numberofAppointments; i++)
            {
                Console.WriteLine(appointments[i].ToString());
            }
        }
        public void GenerateReport()
        {
            Console.WriteLine($"Number of Doctors: {numberofDoctors}");
            Console.WriteLine($"Number of Patients: {numberofPatients}");
            Console.WriteLine($"Number of Appointments: {numberofAppointments}");
        }

    }
}
