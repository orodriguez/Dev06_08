// See https://aka.ms/new-console-template for more information

var students = new[]
{
    "Abel Lorenzo Garcia Tapia",
    "César Augusto Moreno nuñez",
    "Dayhan Omar Garcia Del Carmen",
    "Eliezer Rosario Rubio",
    "Erick Daves Garcia Perez",
    "Fernando Acosta Valenzuela",
    "Joel Acosta",
    "Juan Elías Rodríguez",
    "Manases Lovera",
    "Mariano José Vásquez Rivas",
    "Michael Gonzalez Tiburcio",
    "Miguel Angel  Dide",
    "Sebastian Fernandez"
};

var random = new Random();
var randomIndex = random.Next(0, students.Length);
var chosen = students[randomIndex];

Console.WriteLine($"The Chosen one is {chosen} 📢");