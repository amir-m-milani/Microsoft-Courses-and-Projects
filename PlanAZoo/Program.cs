namespace PlanAZoo;

class Program
{
    static void Main(string[] args)
    {
        School schoolA = new();
        School schoolB = new(3);
        School schoolC = new(2);
        Zoo zoo = new();
        System.Console.WriteLine("School A: ");
        zoo.PrintAnimalsPerGroup(zoo.ChooseRandomAnimals(schoolA));
        System.Console.WriteLine("School B: ");
        zoo.PrintAnimalsPerGroup(zoo.ChooseRandomAnimals(schoolB));
        System.Console.WriteLine("School C: ");
        zoo.PrintAnimalsPerGroup(zoo.ChooseRandomAnimals(schoolC));
    }
}
