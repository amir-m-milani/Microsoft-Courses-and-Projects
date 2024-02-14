namespace MiniGame;

class Player
{
    private string[] states = { "('-')", "(^-^)", "(X_X)" };
    private string player;

    int playerX = 0;
    int playerY = 0;
    public Player()
    {
        player = this.states[0];
    }
    public void FreezePlayer()
    {
        System.Threading.Thread.Sleep(1000);
        player = states[0];
    }
    void Move(int speed = 1, bool enabled = false)
    {

        int lastX = playerX;
        int lastY = playerY;
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                playerY -= speed;
                break;
            case ConsoleKey.DownArrow:
                playerY += speed;
                break;
            case ConsoleKey.LeftArrow:
                playerX -= speed;
                break;
            case ConsoleKey.RightArrow:
                playerX += speed;
                break;
            case ConsoleKey.Escape:
                shouldExit = true;
                break;
            default:
                shouldExit = enabled;
                break;
        }
        // Clear the characters at the previous position
        Console.SetCursorPosition(lastX, lastY);
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(" ");
        }

        // Keep player position within the bounds of the Terminal window
        playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
        playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

        // Draw the player at the new location
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
        if (PlayerToFood())
        {
            ChangePlayer();
            ShowFood();
        }
        switch (PlayerCondition())
        {
            case 0:
                Move();
                break;
            case 1:
                Move(speed: 3);
                break;
            case 2:
                FreezePlayer();
                Move();
                break;
            case 99:
                System.Console.WriteLine("something went wrong");
                shouldExit = true;
                break;
        }
    }
    void ChangePlayer()
    {
        player = states[food];
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }


}