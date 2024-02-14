namespace MiniGame;

class Game
{
    private int height = Console.WindowHeight;
    private int width = Console.WindowWidth;

    public Game()
    {
        if (CheckWindowResize(height: Console.WindowHeight, width: Console.WindowWidth))
        {
            Console.Clear();
            System.Console.WriteLine("Cosnole is resized!");
            Environment.Exit(0);
        }
    }
    /// <summary>
    /// return true if window is resized!
    /// </summary>
    /// <param name="height">window height</param>
    /// <param name="width">window width</param>
    /// <returns>bool</returns>
    private bool CheckWindowResize(int height, int width)
    {
        if (this.height != height || this.width != width)
            return true;

        return false;
    }
}