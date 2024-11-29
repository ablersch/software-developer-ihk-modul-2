var users = new List<User>()
{
    new User() { Name = "John Doe", Age = 42, City = "Berlin" },
    new User() { Name = "Jane Doe", Age = 34, City = "Berlin"},
    new User() { Name = "Joe Doe", Age = 8, City = "Ulm"},
    new User() { Name = "Another Doe", Age = 15, City = "Ulm"},
    new User() { Name = "Jane Roe", Age = 2, City = "Ulm"},
};

// die ersten beiden User abfragen
var firstTwoUsers = users.Take(2).ToList();

// Nur das Feld Name abfragen
var names = users.Select(x => x.Name).ToList();

// Ein Benutzer mit dem Alter von 8 abfragen. Wird keiner gefunden wird null geliefert
var temp = users.Where(x => x.Age == 8).FirstOrDefault();
//temp = users.First(x => x.Age == 10); // Exception

// Wieviel Elemente gibt es welche ein Alter größer 20 haben
int count = users.Where(x => x.Age > 20).Count();
// Alternative:
//count = users.Count(x => x.Age > 20);

// Sortieren nach Alter dann nach Name
var sortedUsers = users.OrderBy(user => user.Age).ThenByDescending(user => user.Name).ToList();

// Gruppieren nach einem Schlüssel (Stadt)
// Definieren, wie die Gruppen verarbeitet oder dargestellt werden soll.
var grouped = users.GroupBy(x => x.City)
    .Select(group => new
    {
        Stadt = group.Key,
        StadtCount = group.Count()
        //NameUser = group.Select(x => x.Name)
    });

Console.WriteLine();