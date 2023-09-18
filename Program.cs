namespace Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] maze = {
                new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                new char[] {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#'},
                new char[] {'#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#'},
                new char[] {'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                new char[] {'#', ' ', '#', '#', '#', '#', ' ', '#', ' ', '#'},
                new char[] {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#', 'O', '#'},
                new char[] {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            };

            byte playerX = 1;
            byte playerY = 1;

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
                    }
                }

                if (playerY == 5 && playerX == 8) 
                {
                    win = true;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("      Grattis!");
                    Console.WriteLine(/*"Grattis du har vunnit!"*/);
                    Console.WriteLine("      Du vann!");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    //Console.ReadLine("Vill du spela igen?(Y/N): ");
                }
            }
        }
    }
}