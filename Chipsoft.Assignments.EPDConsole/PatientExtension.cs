
using System.Text.RegularExpressions;

namespace Chipsoft.Assignments.EPDConsole;

public static class PatientExtensions
{
    public static Patient? PatientDetails()
    {
        Console.WriteLine("voer de naam van de patient in");
        string name = Console.ReadLine();

        Console.WriteLine("voer het adres van de patient in");
        string address = Console.ReadLine();

        Console.WriteLine("telefoonnummer van de patient");
        string phoneNumber = Console.ReadLine()!;
        if (!IsPhoneNumber(phoneNumber) || phoneNumber.Length == 0)
        {
            Console.WriteLine("ongeldig telefoonnummer");
            Console.ReadLine();
            return null;
        }

        Console.WriteLine("email van de patient");
        string email = Console.ReadLine()!;
        if (!IsEmail(email) || email.Length == 0)
        {
            Console.WriteLine("ongeldig email adres");
            Console.ReadLine();
            return null;
        }

        return new Patient()
        {
            name = name,
            address = address,
            phone = phoneNumber,
            email = email
        };
    }

    public static void AddPatient(this EPDDbContext dbContext)
    {
        var patient = PatientDetails();
        if (patient == null)
        {
            return;
        }

        dbContext.Patients.Add(patient);
        dbContext.SaveChanges();
        return;
    }

    private static bool IsPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^([\+]?[0-9]{1,3}[\s]?[0-9]{1,3}[\s]?[0-9]{4,5}[\s]?[0-9]{4})$");
    }

    private static bool IsEmail(string email)
    {
        return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    }
}
