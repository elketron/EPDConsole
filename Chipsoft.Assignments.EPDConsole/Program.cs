using Microsoft.EntityFrameworkCore;

namespace Chipsoft.Assignments.EPDConsole
{
    public class Program
    {
        //Don't create EF migrations, use the reset db option
        //This deletes and recreates the db, this makes sure all tables exist
        private static EPDDbContext _dbContext;

        private static void AddPatient()
        {
            _dbContext.AddPatient();
        }

        private static void ShowAppointment()
        {
            _dbContext.ShowAppointments();

            Console.WriteLine("toon afspraken van een arts y/n");
            var showPhysician = Console.ReadLine();
            if (showPhysician == "y")
            {
                _dbContext.ShowPhysicianAppointments();
            }

            Console.WriteLine("toon afspraken van een patient y/n");
            var showPatient = Console.ReadLine();
            if (showPatient == "y")
            {
                _dbContext.ShowPatientAppointments();
            }
        }

        private static void AddAppointment()
        {
            _dbContext.AddAppointment(); ;
        }

        private static void DeletePhysician()
        {
            Console.WriteLine("voer het id van de arts in");
            var id = int.Parse(Console.ReadLine());

            _dbContext.DeletePhysician(id);
        }

        private static void AddPhysician()
        {
            _dbContext.AddPhysician();
        }

        private static void DeletePatient()
        {
            Console.WriteLine("voer het id van de patient in");
            var id = int.Parse(Console.ReadLine());

            var patient = _dbContext.Patients.FirstOrDefault(p => p.id == id);
            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
            }
        }

        #region FreeCodeForAssignment
        static void Main(string[] args)
        {
            _dbContext = new EPDDbContext();
            _dbContext.Database.EnsureCreated();
            while (ShowMenu())
            {
                //Continue
            }
        }

        public static bool ShowMenu()
        {

            Console.Clear();
            foreach (var line in File.ReadAllLines("logo.txt"))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("");
            Console.WriteLine("1 - Patient toevoegen");
            Console.WriteLine("2 - Patienten verwijderen");
            Console.WriteLine("3 - Arts toevoegen");
            Console.WriteLine("4 - Arts verwijderen");
            Console.WriteLine("5 - Afspraak toevoegen");
            Console.WriteLine("6 - Afspraken inzien");
            Console.WriteLine("7 - Sluiten");
            Console.WriteLine("8 - Reset db");

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        AddPatient();
                        return true;
                    case 2:
                        DeletePatient();
                        return true;
                    case 3:
                        AddPhysician();
                        return true;
                    case 4:
                        DeletePhysician();
                        return true;
                    case 5:
                        AddAppointment();
                        return true;
                    case 6:
                        ShowAppointment();
                        return true;
                    case 7:
                        return false;
                    case 8:
                        EPDDbContext dbContext = new EPDDbContext();
                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();
                        return true;
                    default:
                        return true;
                }
            }
            return true;
        }

        #endregion
    }
}
