namespace PlanAZoo;

class Zoo
{
    private string[] pettingZoo =
    {
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
    };
    public Zoo() { }


    private void RandomizeAnimals()
    {
        Random random = new();
        for (int i = 0; i < pettingZoo.Length; i++)
        {
            int r = random.Next(i, pettingZoo.Length);
            //transfer array indexes
            string temp = pettingZoo[i];
            pettingZoo[i] = pettingZoo[r];
            pettingZoo[r] = temp;
        }
    }
    public string[,] ChooseRandomAnimals(School school)
    {
        RandomizeAnimals();
        int animalsPerGroup = this.pettingZoo.Length / school.groups;
        string[,] result = new string[school.groups, animalsPerGroup];
        int start = 0;
        for (int i = 0; i < school.groups; i++)
        {
            for (int j = 0; j < animalsPerGroup; j++)
            {
                result[i, j] = pettingZoo[start++];
            }
        }
        return result;
    }

    public void PrintAnimalsPerGroup(string[,] result)
    {
        for (int i = 0; i < result.GetLength(0); i++)
        {
            Console.Write($"Gropu {i + 1}: ");
            for (int j = 0; j < result.GetLength(1); j++)
            {
                System.Console.Write($"{result[i, j]}   ");
            }
            System.Console.WriteLine();
        }
    }
}