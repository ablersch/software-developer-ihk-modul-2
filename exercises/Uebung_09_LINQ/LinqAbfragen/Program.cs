using LinqAbfragen;

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

// Den Mitarbeiter mit der höchsten Personalnummer

// Alle Mitarbeiter sortiert nach Personalnummer.

// Alle aktiven Mitarbeiter der IT Abteilung.

// Alle Vornamen der Mitarbeiter aus der IT Abteilung.

// Alle Mitarbeiter gruppiert nach Abteilung.

// Abteilungen bei denen der Manager mit "Ka" beginnt.

// Den Manger der Abteilung in der Max Mustermann arbeitet

// Gibt es Mitarbeiter mit Personalnummern von 2000 - 3999.

// Name der Abteilungen mit der Anzahl an aktiven Mitarbeiter.