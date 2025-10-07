using System.Data;

namespace HospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            string dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            string DoctorFilePath = Path.Combine(dataFolder, "doctors.txt");
            string PatientFilePath = Path.Combine(dataFolder, "Patients.txt");
            string AppointmentFilePath = Path.Combine(dataFolder, "Appointments.txt");



            Hospital hospital = new Hospital();
 
            hospital.Doctors = FileManager.LoadDoctors(DoctorFilePath);
            hospital.UpdateDoctorCount();
            hospital.patients = FileManager.LoadPatients(PatientFilePath);
            hospital.UpdatePatientCount();
            hospital.appointments = FileManager.LoadAppointments(AppointmentFilePath);
            hospital.UpdateAppointmentCount();

            while (true)
            {
                ShowMainMenu();
                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            while (true)
                            {
                                int num;
                                Doctor doctor;
                                HandleDoctorMenu();
                                int.TryParse(Console.ReadLine(), out num);
                                if (num == 1)
                                {
                                    int id;
                                    string name, phone, specialization, email;
                                    Console.WriteLine("Enter Doctor Deteils : ");

                                    Console.Write("ID: ");
                                    int.TryParse(Console.ReadLine(), out id);

                                    Console.Write("Name: ");
                                    name = Console.ReadLine();

                                    Console.Write("Phone: ");
                                    phone = Console.ReadLine();

                                    Console.Write("Specialization: ");
                                    specialization = Console.ReadLine();

                                    Console.Write("Email: ");
                                    email = Console.ReadLine();
                                    doctor = new Doctor()
                                    {
                                        Id = id,
                                        Name = name,
                                        Phone = phone,
                                        Specialization = specialization,
                                        Email = email
                                    };

                                    hospital.AddDoctor(doctor);
                                }
                                else if (num == 2)
                                {
                                    hospital.ViewAllDoctors();
                                }
                                else if (num == 3)
                                {
                                    int id;
                                    Console.Write("Enter id to search: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    hospital.SearchDoctorByID(id);
                                }
                                else if (num == 4)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter valid number");
                                    HandleDoctorMenu();
                                }
                            }
                            break;
                        case 2:
                            while (true)
                            {
                                int num;
                                Patient patient;
                                HandlePatientMenu();
                                int.TryParse(Console.ReadLine(), out num);
                                if (num == 1)
                                {
                                    int id, age;
                                    string name, phone,gender , Address;
                                    Console.WriteLine("Enter Patient Deteils : ");

                                    Console.Write("ID: ");
                                    int.TryParse(Console.ReadLine(), out id);

                                    Console.Write("Name: ");
                                    name = Console.ReadLine();

                                    Console.Write("Age: ");
                                    int.TryParse(Console.ReadLine(), out age);

                                    Console.Write("phone: ");
                                    phone = Console.ReadLine();

                                    Console.Write("gender: ");
                                    gender = Console.ReadLine();

                                    Console.Write("Address: ");
                                    Address = Console.ReadLine();

                                    patient = new Patient()
                                    {
                                        Id = id,
                                        Name = name,
                                        Phone = phone,
                                        Age = age,
                                        Gender = gender,
                                        Address= Address
                                    };

                                    hospital.AddPatient(patient);
                                }
                                else if (num == 2)
                                {
                                    hospital.ViewAllPatients();
                                }
                                else if (num == 3)
                                {
                                    int id;
                                    Console.Write("Enter id to search: ");
                                    int.TryParse(Console.ReadLine(), out id);
                                    hospital.SearchPatientByID(id);
                                }
                                else if (num == 4)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter valid number");
                                    HandleDoctorMenu();
                                }
                            }
                            break;
                        case 3:
                            while (true)
                            {
                                int num;
                                Appointment appointment;
                                HandleAppointmentMenu();
                                int.TryParse(Console.ReadLine(), out num);
                                if (num == 1)
                                {
                                    int id , Doctor_id, Patient_id;
                                    DateTime Date;
                                    string status;
                                    Console.WriteLine("Enter Appointment Deteils : ");

                                    Console.Write("ID: ");
                                    int.TryParse(Console.ReadLine(), out id);

                                    Console.Write("Doctor Id: ");
                                    int.TryParse(Console.ReadLine(), out Doctor_id);

                                    Console.Write("Patient ID: ");
                                    int.TryParse(Console.ReadLine(), out Patient_id);

                                    Console.Write("Status: ");
                                    status = Console.ReadLine();

                                    Console.Write("Date: ");
                                    DateTime.TryParse(Console.ReadLine(), out Date);

                                    appointment = new Appointment()
                                    {
                                        ID = id,
                                        DoctorId = Doctor_id,
                                        PatientId = Patient_id,
                                        Date = Date,
                                        Status = status
                                    };

                                    hospital.AddAppointment(appointment);
                                }
                                else if (num == 2)
                                {
                                    hospital.ViewAllAppointments();
                                }
                                else if (num == 3)
                                {
                                    int id;
                                    string newStatus;
                                    Appointment appointment1;

                                    Console.WriteLine("Enter id of Appointment: ");
                                    int.TryParse(Console.ReadLine(), out id);

                                    appointment1 = hospital.SearchAppointmentByID(id);

                                    if (appointment1 == null)
                                    {
                                        Console.WriteLine("Appointment not found!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter new Status: ");
                                        newStatus = Console.ReadLine();
                                        appointment1.UpdateStatus(newStatus);
                                    }
                                }
                                else if (num == 4)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter valid number");
                                    HandleDoctorMenu();
                                }
                            }
                            break;
                        case 4:
                            //Generate Report
                            hospital.GenerateReport();
                            break;
                        case 5:
                            FileManager.SaveDoctors(hospital.Doctors, DoctorFilePath);
                            FileManager.SavePatients(hospital.patients, PatientFilePath);
                            FileManager.SaveAppointments(hospital.appointments, AppointmentFilePath);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter valid number form 1 to 5");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter valid Choice");
                }
            }
            
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("Welcome to Hospital Management System");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Manage Doctors");
            Console.WriteLine("2. Manage Patients");
            Console.WriteLine("3. Manage Appointments");
            Console.WriteLine("4. Generate Report");
            Console.WriteLine("5. Exit");
            Console.Write("Entery your choice: ");
        }
        public static void HandleDoctorMenu()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Doctor Management");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. View All Doctors");
            Console.WriteLine("3. Search Doctor by ID");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");
        }
        public static void HandlePatientMenu()
        {
            Console.WriteLine("Patient Management");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View All Patients");
            Console.WriteLine("3. Search Patient by ID");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");
        }
        public static void HandleAppointmentMenu()
        {
            Console.WriteLine("Appointment Management");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. schedule Appointment");
            Console.WriteLine("2. View All Appointments");
            Console.WriteLine("3. Update Appointment Status");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");
        }
    }
}
