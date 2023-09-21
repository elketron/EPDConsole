
namespace Chipsoft.Assignments.EPDConsole;

public static class PhysicianExtension
{
    private static Physician PhysicianDetails()
    {
        Console.WriteLine("voer de naam van de arts in");
        string name = Console.ReadLine();

        Console.WriteLine("voer het adres van de arts in");
        string address = Console.ReadLine();

        return new Physician() { name = name, address = address };
    }

    public static void AddPhysician(this EPDDbContext dbContext)
    {
        var physician = PhysicianDetails();
        dbContext.Physicians.Add(physician);
        dbContext.SaveChanges();
    }

    public static void DeletePhysician(this EPDDbContext dbContext, int id)
    {

        var phycisian = dbContext.Physicians.FirstOrDefault(p => p.id == id);
        if (phycisian != null)
        {
            dbContext.Physicians.Remove(phycisian);
            dbContext.SaveChanges();
        }
    }
}
