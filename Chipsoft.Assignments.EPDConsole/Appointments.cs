

using Microsoft.EntityFrameworkCore;

namespace Chipsoft.Assignments.EPDConsole;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int PhysicianId { get; set; }
    public Physician Physician { get; set; }
}

