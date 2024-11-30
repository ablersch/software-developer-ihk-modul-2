using Linq;

List<Department> departments = new()
{
    new Department() { Name = "IT", Manager =  "Hans Müller" },
    new Department() { Name = "Sales", Manager =  "Leon Hoover" },
    new Department() { Name = "Production", Manager =  "Karin Fuchs" },
    new Department() { Name = "HR", Manager =  "Katja Ostermann" },
};

List<Employee> employees = new()
{
    new Employee() { FirstName = "Max", LastName = "Mustermann", Number = 2679, Department = departments.FirstOrDefault(x => x.Name == "IT") },
    new Employee() { FirstName = "Ana", LastName = "Nass", Number = 3453, Active = false, Department = departments.FirstOrDefault(x => x.Name == "IT") },
    new Employee() { FirstName = "Tom", LastName = "Ate", Number = 1239, Department = departments.FirstOrDefault(x => x.Name == "Sales") },
    new Employee() { FirstName = "Peter", LastName = "Sil", Number = 9874, Active = false, Department = departments.FirstOrDefault(x => x.Name == "Sales") },
    new Employee() { FirstName = "Eric", LastName = "Finkel", Number = 5468, Department = departments.FirstOrDefault(x => x.Name == "Production") },
    new Employee() { FirstName = "Mathias ", LastName = "Friedmann", Number = 1128, Department = departments.FirstOrDefault(x => x.Name == "Sales") },
    new Employee() { FirstName = "Katja", LastName = "Drechsler", Number = 1111, Active = false, Department = departments.FirstOrDefault(x => x.Name == "IT") },
    new Employee() { FirstName = "Diana", LastName = "Baum", Number = 4567, Department = departments.FirstOrDefault(x => x.Name == "IT") }
};

// Den Mitarbeiter mit dem Nachname "Baum"
var employeeBaum = employees.First(x => x.LastName == "Baum");

// Den Mitarbeiter mit der höchsten Personalnummer
var highestEmployeeNumber = employees.OrderByDescending(e => e.Number).FirstOrDefault();

var maxNumber = employees.Max(e => e.Number);
var highestEmployeeNumber2 = employees.FirstOrDefault(x => x.Number == maxNumber);

// Alle Mitarbeiter sortiert nach Personalnummer
var orderedEmployees = employees.OrderBy(o => o.Number).ToList();

// Alle aktiven Mitarbeiter der IT Abteilung
var itEmployees = employees.Where(x => x.Department.Name == "IT" && x.Active).ToList();

// Alle Vornamen der Mitarbeiter aus der IT Abteilung
var itFirstNamesEmployees = employees.Where(x => x.Department.Name == "IT").Select(s => s.FirstName).ToList();

// Alle Mitarbeiter gruppiert nach Abteilung
var groupedEmployeesByDepartment = employees.GroupBy(g => g.Department.Name).ToList();

// Abteilungen bei denen der Manager mit "Ka" beginnt
var departmentsWithKaManager = departments.Where(x => x.Manager.StartsWith("Ka")).ToList();

// Den Manager der Abteilung in der Max Mustermann arbeitet
var maxsManager = employees.Where(e => e.FirstName == "Max" && e.LastName == "Mustermann").Select(e => e.Department?.Manager).FirstOrDefault();

// Gibt es Mitarbeiter mit Personalnummern von 2000 - 3999
bool employeeRange = employees.Any(s => s.Number >= 2000 && s.Number <= 3999);

// Name der Abteilungen mit der Anzahl an aktiven Mitarbeitern
var departmentsWithActiveEmployeeCount = employees
    .Where(x => x.Active)
    .GroupBy(x => x.Department.Name)
    .Select(group => new
    {
        Department = group.Key,
        Count = group.Count()
    });