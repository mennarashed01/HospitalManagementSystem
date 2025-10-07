using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HospitalManagementSystem
{
    internal static class FileManager
    {
        public static void SaveDoctors(Doctor[] doctors, string filepath)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i =0; i < doctors.Length; i++)
            {
                if (doctors[i] != null)
                    stringBuilder.AppendLine($"{doctors[i].Id},{doctors[i].Name},{doctors[i].Phone},{doctors[i].Email},{doctors[i].Specialization}");
            }
            File.WriteAllText(filepath, stringBuilder.ToString());
            Console.WriteLine("Doctors saved successfully!");
        }
        public static Doctor[] LoadDoctors(string filePath)
        {
            if (!File.Exists(filePath))
                return new Doctor[100]; 

            var lines = File.ReadAllLines(filePath);
            Doctor[] doctors = new Doctor[100];
            int index = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 5 && index < 100)
                {
                    doctors[index++] = new Doctor
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Phone = parts[2],
                        Email = parts[3],
                        Specialization = parts[4]
                    };
                }
            }
            return doctors;
        }

        public static void SavePatients(Patient[] patients, string filepath)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < patients.Length; i++)
            {
                if (patients[i] != null)
                    sb.AppendLine($"{patients[i].Id},{patients[i].Name},{patients[i].Phone},{patients[i].Age},{patients[i].Gender},{patients[i].Address}");
            }
            File.WriteAllText(filepath,sb.ToString());
            Console.WriteLine("Patients saved successfully!");
        }
        public static Patient[] LoadPatients(string filepath)
        {
            if (!File.Exists(filepath))
                return new Patient[100]; 

            var lines = File.ReadAllLines(filepath);
            Patient[] Patients = new Patient[100];
            int index = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 6 && index < 100)
                {
                    Patients[index++] = new Patient
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Phone = parts[2],
                        Age = int.Parse(parts[3]),
                        Gender = parts[4],
                        Address = parts[5]
                    };
                }
            }
            return Patients;
        } 
        public static void SaveAppointments(Appointment[] appointments, string filepath)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i] != null)
                    sb.AppendLine($"{appointments[i].ID},{appointments[i].DoctorId},{appointments[i].PatientId},{appointments[i].Date},{appointments[i].Status}");
            }
            File.WriteAllText(filepath, sb.ToString());
            Console.WriteLine("appointments saved successfully!");
        }
        public static Appointment[]  LoadAppointments(string filepath)
        {
            if (!File.Exists(filepath))
                return new Appointment[500];

            string[] lines = File.ReadAllLines(filepath);
            Appointment[] appointments = new Appointment[100];
            int index = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 5 && index < 100)
                {
                    DateTime date;
                    DateTime.TryParse(parts[3], out date);
                    appointments[index++] = new Appointment
                    {
                        ID = int.Parse(parts[0]),
                        DoctorId = int.Parse(parts[1]),
                        PatientId = int.Parse(parts[2]),
                        Date = date,
                        Status = parts[4]
                    };
                }
            }
            return appointments;
        }
    }
}
