namespace Labyrinth
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            while (playing)
            {
                Console.Clear();
                Console.WriteLine("Vilken svårighetsgrad vill du spela på?");
                Console.Write("0. Easy, 1. Medium: ");
                string input = Console.ReadLine();
                while (Convert.ToInt32(input) != 0 || Convert.ToInt32(input) != 1)
                {
                    Console.Write("Incorrect input, try again: ");
                    input = Console.ReadLine();
                } 
                int choice = Convert.ToInt32(input);

                PlayLabyrinth(choice);

                Console.Write("Vill du spela igen?(Y/N): ");
                String playAgain = Console.ReadLine();
                if (playAgain != null) { playAgain = playAgain.Substring(0, 1); }
                if (playAgain.ToUpper() == "N") { playing = false; }
            }
        }

        public static void PlayLabyrinth(int choice)
        {
            char[][] maze = MazeChoice(choice);

            byte playerX = 1;//Testing numbers, Easy = 8, Medium = 3
            byte playerY = 1;//Testing numbers, Easy = 5, Medium = 8

            bool win = false;

            while (!win)
            {
                Console.Clear();
                for (int y = 0; y < maze.Length; y++)
                {
                    for (int x = 0; x < maze[y].Length; x++)
                    {
                        if (x == playerX && y == playerY)
                        {
                            Console.Write("P"); //Player location
                        }
                        else
                        {
                            Console.Write(maze[y][x]);
                        }
                    }
                    Console.WriteLine();
                }


                Console.Write("Ange din rörelse (NSEW): ");
                string move = Console.ReadLine();
                if (move.Length > 0)
                {
                    move = move.Substring(0, 1);
                    switch (move.ToUpper())
                    {
                        case "N":
                            if (maze[playerY - 1][playerX] != '#') playerY--;
                            break;
                        case "S":
                            if (maze[playerY + 1][playerX] != '#') playerY++;
                            break;
                        case "E":
                            if (maze[playerY][playerX + 1] != '#') playerX++;
                            break;
                        case "W":
                            if (maze[playerY][playerX - 1] != '#') playerX--;
                            break;
                        default:
                            break;
                    }
                }

                win = IsWin(maze, playerY, playerX);
            }
        }

        public static bool IsWin(char[][] maze, int playerY, int playerX)
        {
            bool win = false;

            if (maze[playerY][playerX] == 'O')
            {
                win = true;
                Console.Clear();
                for (int i = 0; i < maze.Length; i++) 
                {
                    if (i == Math.Floor((double) maze.Length / 2 - 1)) 
                    {
                        for (int j = 0; j < maze[i].Length / 2 - 3; j++) Console.Write(" ");
                        Console.WriteLine("Grattis!");
                    }
                    else if (i == Math.Floor((double) maze.Length / 2 + 1))
                    {
                        for (int k = 0; k < maze[i].Length / 2 - 3; k++) Console.Write(" ");
                        Console.WriteLine("Du vann!");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }

            return win;
        }
        public static char[][] MazeChoice(int choice)
        {
            char[][] maze = {new char[] {'#'} };
            char[][] mazeEasy = {
                new char[] { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                new char[] { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
                new char[] { '#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#' },
                new char[] { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                new char[] { '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', '#' },
                new char[] { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', 'O', '#' },
                new char[] { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
                };

            char[][] mazeMedium = {
                new char[] { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                new char[] { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                new char[] { '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
                new char[] { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                new char[] { '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', ' ', ' ', ' ', '#' },
                new char[] { '#', ' ', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', '#' },
                new char[] { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
                new char[] { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
                new char[] { '#', ' ', '#', ' ', 'O', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', '#' },
                new char[] { '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#' },
                new char[] { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#' },
                new char[] { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
                };

            switch (choice)
            {
                case 0:
                    maze = mazeEasy;
                    break;
                case 1:
                    maze = mazeMedium;
                    break;

            }

            return maze;
        }
    }
}