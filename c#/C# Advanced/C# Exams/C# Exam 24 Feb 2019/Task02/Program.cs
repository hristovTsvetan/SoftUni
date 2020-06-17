using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] board = new char[sizeMatrix, sizeMatrix];
            int[] playerPositions = new int[4];

            playerPositions = FillMMatrix(board);

            int playerOneRow = playerPositions[0];
            int playerOneCol = playerPositions[1];
            int playerTwoRow = playerPositions[2];
            int playerTwoCol = playerPositions[3];

            int curPlayerNumber = 2;
            while (curPlayerNumber == 2)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int curPlayerOneRow = playerOneRow;
                int curPlayerOneCol = playerOneCol;
                int curPlayerTwoRow = playerTwoRow;
                int curPlayerTwoCol = playerTwoCol;

                string playerOneDirection = command[0];
                string playerTwoDirection = command[1];

                switch (playerOneDirection)
                {
                    case "up":
                        curPlayerOneRow--;
                        break;
                    case "down":
                        curPlayerOneRow++;
                        break;
                    case "left":
                        curPlayerOneCol--;
                        break;
                    case "right":
                        curPlayerOneCol++;
                        break;
                }

                if (!CheckCoord(board, curPlayerOneRow, curPlayerOneCol))
                {
                    if (playerOneDirection == "up")
                    {
                        curPlayerOneRow = board.GetLength(0) - 1;
                    }
                    else if (playerOneDirection == "down")
                    {
                        curPlayerOneRow = 0;
                    }
                    else if (playerOneDirection == "left")
                    {
                        curPlayerOneCol = board.GetLength(1) - 1;
                    }
                    else
                    {
                        curPlayerOneCol = 0;
                    }
                }

                switch (playerTwoDirection)
                {
                    case "up":
                        curPlayerTwoRow--;
                        break;
                    case "down":
                        curPlayerTwoRow++;
                        break;
                    case "left":
                        curPlayerTwoCol--;
                        break;
                    case "right":
                        curPlayerTwoCol++;
                        break;
                }

                if (!CheckCoord(board, curPlayerTwoRow, curPlayerTwoCol))
                {
                    if (playerTwoDirection == "up")
                    {
                        curPlayerTwoRow = board.GetLength(0) - 1;
                    }
                    else if (playerTwoDirection == "down")
                    {
                        curPlayerTwoRow = 0;
                    }
                    else if (playerTwoDirection == "left")
                    {
                        curPlayerTwoCol = board.GetLength(1) - 1;
                    }
                    else
                    {
                        curPlayerTwoCol = 0;
                    }
                }

                if (board[curPlayerOneRow, curPlayerOneCol] != '*')
                {
                    board[curPlayerOneRow, curPlayerOneCol] = 'x';
                    curPlayerNumber = 1;
                    continue;
                }
                else
                {
                    board[curPlayerOneRow, curPlayerOneCol] = 'f';
                    playerOneRow = curPlayerOneRow;
                    playerOneCol = curPlayerOneCol;
                }

                if (board[curPlayerTwoRow, curPlayerTwoCol] != '*')
                {
                    board[curPlayerTwoRow, curPlayerTwoCol] = 'x';
                    curPlayerNumber = 1;
                    continue;
                }
                else
                {
                    board[curPlayerTwoRow, curPlayerTwoCol] = 's';
                    playerTwoRow = curPlayerTwoRow;
                    playerTwoCol = curPlayerTwoCol;
                }
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }

        }

        public static bool CheckCoord(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }


        private static int[] FillMMatrix(char[,] board)
        {
            int[] playersPositions = new int[4];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] curCol = Console.ReadLine().ToCharArray();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = curCol[col];
                    GetPlayersPositions(playersPositions, row, curCol, col);
                }
            }
            return playersPositions;
        }

        private static void GetPlayersPositions(int[] playersPositions, int row, char[] curCol, int col)
        {
            if (curCol[col] == 'f')
            {
                playersPositions[0] = row;
                playersPositions[1] = col;
            }
            else if (curCol[col] == 's')
            {
                playersPositions[2] = row;
                playersPositions[3] = col;
            }
        }
    }
}
