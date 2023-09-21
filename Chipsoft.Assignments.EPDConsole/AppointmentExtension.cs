
using Microsoft.EntityFrameworkCore;

namespace Chipsoft.Assignments.EPDConsole;

public static class AppointmentExtension
{
    public static Appointment AppointmentDetails()
    {
        Console.WriteLine("voer de datum van de afspraak in");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("voer de beschrijving van de afspraak in");
        string description = Console.ReadLine();

        Console.WriteLine("voer het id van de patient in");
        int patientId = int.Parse(Console.ReadLine());

        Console.WriteLine("voer het id van de arts in");
        int physicianId = int.Parse(Console.ReadLine());

        return new Appointment() { Date = date, Description = description, PatientId = patientId, PhysicianId = physicianId };
    }

    public static void AddAppointment(this EPDDbContext dbContext)
    {
        var appointment = AppointmentDetails();
        dbContext.Appointments.Add(appointment);
        dbContext.SaveChanges();
    }

    public static void ShowAppointments(this EPDDbContext dbContext)
    {

        var appointments = dbContext.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Physician)
            .ToList();
        foreach (var appointment in appointments)
        {
            Console.WriteLine($"Afspraak op {appointment.Date} voor {appointment.Description}");
            Console.WriteLine($"Patient: {appointment.Patient.id} - {appointment.Patient.name}");
            Console.WriteLine($"Arts: {appointment.Physician.id} - {appointment.Physician.name}");
            Console.WriteLine("");
        }

    }

    public static void ShowPhysicianAppointments(this EPDDbContext dbContext)
    {
        Console.WriteLine("voer het id van de arts in");
        var id = int.Parse(Console.ReadLine());

        var appointments = dbContext.Appointments
            .Where(a => a.PhysicianId == id)
            .Include(a => a.Patient)
            .Include(a => a.Physician)
            .ToList();
        foreach (var appointment in appointments)
        {
            Console.WriteLine($"Afspraak op {appointment.Date} voor {appointment.Description}");
            Console.WriteLine($"Patient: {appointment.Patient.name}");
            Console.WriteLine($"Arts: {appointment.Physician.name}");
            Console.WriteLine("");
        }
    }

    public static void ShowPatientAppointments(this EPDDbContext dbContext)
    {
        Console.WriteLine("voer het id van de patient in");
        var id = int.Parse(Console.ReadLine());

        var appointments = dbContext.Appointments
            .Where(a => a.PatientId == id)
            .Include(a => a.Patient)
            .Include(a => a.Physician)
            .ToList();

        foreach (var appointment in appointments)
        {
            Console.WriteLine($"Afspraak op {appointment.Date} voor {appointment.Description}");
            Console.WriteLine($"Patient: {appointment.Patient.name}");
            Console.WriteLine($"Arts: {appointment.Physician.name}");
            Console.WriteLine("");
        }
    }
}
