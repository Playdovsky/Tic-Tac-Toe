using System.Collections;

Console.WriteLine("Welcome to tic-tac-toe game!\nXOXOXOXOXOXOXOXOXOX");
Console.WriteLine("It's two player game, so in order to play you have to bring your friend or...\nplay lonely :(\n\n");
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
        Console.WriteLine($"{ex.Message}\nTry again");
    }
}

void MainGame(char player1, char player2)
{
    Console.WriteLine($"Then settings are as follows\nPlayer 1:{player1}\nPlayer 2:{player2}");
    Console.WriteLine("Let's start the game.");
    char[,] gameHash = new char[2, 2];
    Console.WriteLine(" | | \n-+-+-\n | | \n-+-+-\n | | ");
}