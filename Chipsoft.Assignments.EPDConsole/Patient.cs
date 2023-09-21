

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Chipsoft.Assignments.EPDConsole;

public class Patient
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string phone { get; set; }
    [DataType(DataType.EmailAddress)]
    public string email { get; set; }
}

