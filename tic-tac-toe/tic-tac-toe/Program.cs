using System.Collections;

Console.WriteLine("Welcome to tic-tac-toe game!\nXOXOXOXOXOXOXOXOXOX");
Console.WriteLine("It's two player game, so in order to play you have to bring your friend or... play lonely with yourself.\n\n");
Console.WriteLine("Should the player 1 be an 'X' or an 'O'?");

while (true)
{
    try
    {
        char player1 = char.Parse(Console.ReadLine());
        char player2;

        switch (player1) {
            case 'X':
                player2 = 'O';
                MainGame(player1, player2);
                return;
            case 'O':
                player2 = 'X';
                MainGame(player1, player2);
                return;
            default:
                Console.WriteLine("Something went wrong, try again");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}\nTry again.");
    }
}

void MainGame(char player1, char player2)
{
    Console.WriteLine($"Then settings are as follows\nPlayer 1:{player1}\nPlayer 2:{player2}");
    Console.WriteLine("Qucik reminder: remember to set coordinates separatly according to demanded axis.\n");

    char[,] gameHash = new char[3, 3];
    bool player1Move = true;

    for (int i = 0; i < gameHash.GetLength(0); i++)
    {
        for (int j = 0; j < gameHash.GetLength(1); j++)
        {
            gameHash[i, j] = ' ';
        }
    }

    Console.WriteLine(
    $"     0 1 2\n" +
    $"     -----\n" +
    $"\n0|    | | " +
    $"\n |   -+-+-" +
    $"\n1|    | | " +
    $"\n |   -+-+-" +
    $"\n2|    | | " +
    $"\n"
    );
    Turns(player1, player2, gameHash, player1Move);
}

void Turns(char player1, char player2, char[,] gameHash, bool player1Move)
{
    Console.WriteLine("Player " + ((player1Move == true) ? "1 " : "2 ") + "where do you want to set your mark ?");
    int x, y;

    while (true)
    {
        try
        {
            Console.WriteLine("write an x axis value");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("write an y axis value");
            y = int.Parse(Console.ReadLine());

            if (gameHash[y, x] == ' ')
            {
                break;
            }
            else
            {
                Console.WriteLine("Mark has been already set at this position. Try different coordinates.");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"{ex.Message}\nTry again.");
        }
    }

    Console.Clear();

    if (player1Move)
    {
        gameHash[y, x] = 'X';
        player1Move = false;
    }
    else
    {
        gameHash[y, x] = 'O';
        player1Move = true;
    }

    Console.WriteLine(
        $"     0 1 2\n" +
        $"     -----\n" +
        $"\n0|   {gameHash[0, 0]}|{gameHash[0, 1]}|{gameHash[0, 2]}" +
        $"\n |   -+-+-" +
        $"\n1|   {gameHash[1, 0]}|{gameHash[1, 1]}|{gameHash[1, 2]}" +
        $"\n |   -+-+-" +
        $"\n2|   {gameHash[2, 0]}|{gameHash[2, 1]}|{gameHash[2, 2]}"
        );

    Turns(player1, player2, gameHash, player1Move);
}