using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe;

public class TwoPlayersGame
{
    private static char[,] gameHash = new char[3, 3];
    private static bool player1Move = true;
    private static byte tie = 0;

    /// <summary>
    /// Starting point of tic-tac-toe.
    /// </summary>
    public static void Start()
    {
        Console.WriteLine("Should the player 1 be an 'X' or an 'O'?");

        while (true)
        {
            try
            {
                char player1 = char.Parse(Console.ReadLine()!);
                char player2;

                switch (player1)
                {
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
    }

    /// <summary>
    /// Game preparations, defining players mark and creating hash.
    /// </summary>
    /// <param name="player1">First player mark</param>
    /// <param name="player2">Second player mark</param>
    private static void MainGame(char player1, char player2)
    {
        Console.WriteLine($"Then settings are as follows\nPlayer 1:{player1}\nPlayer 2:{player2}");
        Console.WriteLine("Qucik reminder: remember to set coordinates separatly according to demanded axis.\n");

        for (int i = 0; i < gameHash.GetLength(0); i++)
        {
            for (int j = 0; j < gameHash.GetLength(1); j++)
            {
                gameHash[i, j] = ' ';
            }
        }

        Console.WriteLine(DrawHash());

        Turns(player1, player2);
    }

    /// <summary>
    /// Turns in which particular player can make a move by placing mark. Mark placement depends on x and y axis from user input.
    /// This method also  checks if game was ended by tie.
    /// </summary>
    /// <param name="player1">First player mark</param>
    /// <param name="player2">Second player mark</param>
    private static void Turns(char player1, char player2)
    {
        Console.WriteLine("Player " + ((player1Move == true) ? "1 " : "2 ") + "where do you want to set your mark ?");
        byte x, y;

        while (true)
        {
            try
            {
                Console.WriteLine("write an x axis value");
                x = byte.Parse(Console.ReadLine()!);
                Console.WriteLine("write an y axis value");
                y = byte.Parse(Console.ReadLine()!);

                if (gameHash[y - 1, x - 1] == ' ')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Mark has been already set at this position. Try different coordinates.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\nTry again.");
            }
        }

        Console.Clear();

        if (player1Move)
        {
            gameHash[y - 1, x - 1] = player1;
            player1Move = false;
        }
        else
        {
            gameHash[y - 1, x - 1] = player2;
            player1Move = true;
        }

        Console.WriteLine(DrawHash(gameHash));

        if (CheckIfWin())
        {
            Console.WriteLine("\nPlayer " + ((player1Move == false) ? "1 " : "2 ") + "has won!");
            PlayAgain();
        }
        else if (tie == 8)
        {
            Console.WriteLine("\nThere's no winner. It's a tie!");
            PlayAgain();
        }

        tie++;
        Turns(player1, player2);
    }

    /// <summary>
    /// Checks if game was won.
    /// </summary>
    /// <returns>True if game was won by one of the players</returns>
    private static bool CheckIfWin()
    {
        for (int x = 0; x < gameHash.GetLength(0); x++)
        {
            if (gameHash[x, 0] != ' ' && (gameHash[x, 0] == gameHash[x, 1] && gameHash[x, 1] == gameHash[x, 2]))
            {
                return true;
            }
        }

        for (int y = 0; y < gameHash.GetLength(0); y++)
        {
            if (gameHash[0, y] != ' ' && (gameHash[0, y] == gameHash[1, y] && gameHash[1, y] == gameHash[2, y]))
            {
                return true;
            }
        }

        if (gameHash[1, 1] != ' ' && ((gameHash[0, 0] == gameHash[1, 1] && gameHash[1, 1] == gameHash[2, 2]) || (gameHash[2, 0] == gameHash[1, 1] && gameHash[1, 1] == gameHash[0, 2])))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Method to check if user wants to start a new game thus repeating the cycle of tic-tac-toe.
    /// </summary>
    private static void PlayAgain()
    {
        Console.WriteLine("Do you want to play again?\nPress 'ENTER' to start new game, otherwise app will be closed.");
        ConsoleKeyInfo cki = Console.ReadKey();

        if (cki.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            char[,] gameHash = new char[3, 3];
            player1Move = true;
            tie = 0;
            Start();
        }
        else
        {
            Environment.Exit(0);
        }
    }

    /// <summary>
    /// Draws a blank game hash.
    /// </summary>
    /// <returns>String of blank game hash</returns>
    private static string DrawHash()
    {
        string hash = (
            $"     1 2 3\n" +
            $"     -----\n" +
            $"\n1|    | | " +
            $"\n |   -+-+-" +
            $"\n2|    | | " +
            $"\n |   -+-+-" +
            $"\n3|    | | " +
            $"\n"
        );

        return hash;
    }

    /// <summary>
    /// Draws a game hash of tic-tac-toe.
    /// </summary>
    /// <param name="gameHash"></param>
    /// <returns>String of every array element</returns>
    private static string DrawHash(char[,] gameHash)
    {
        string hash = (
                        $"     1 2 3\n" +
            $"     -----\n" +
            $"\n1|   {gameHash[0, 0]}|{gameHash[0, 1]}|{gameHash[0, 2]}" +
            $"\n |   -+-+-" +
            $"\n2|   {gameHash[1, 0]}|{gameHash[1, 1]}|{gameHash[1, 2]}" +
            $"\n |   -+-+-" +
            $"\n3|   {gameHash[2, 0]}|{gameHash[2, 1]}|{gameHash[2, 2]}"
        );

        return hash;
    }
}

