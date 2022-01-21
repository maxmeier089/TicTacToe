using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeModel
{
    /// <summary>
    /// Tic Tac Toe game logic
    /// </summary>
    public class Game
    {

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static Game Instance { get; private set; }

        /// <summary>
        /// Game width
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Game Height
        /// </summary>
        public int Height { get; private set; }


        /// <summary>
        /// Array of game fields [Width, Height]
        /// </summary>
        public Field[,] Fields { get; private set; }


        /// <summary>
        /// Player 1
        /// </summary>
        public Player Player1 { get; private set; }

        /// <summary>
        /// Player 3
        /// </summary>
        public Player Player2 { get; private set; }

        /// <summary>
        /// Player who gets to make the next make
        /// </summary>
        public Player CurrentPlayer { get; private set; }


        /// <summary>
        /// Indicates if the game has ended (either win or tie)
        /// </summary>
        public bool GameEnded { get; private set; }

        /// <summary>
        /// If there is a winner, it is stored here
        /// </summary>
        public Player Winner { get; private set; }


        /// <summary>
        /// Check the game status
        /// </summary>
        internal void CheckGameStatus()
        {
            // Check if a player has won
            CheckWin();

            // Switch players
            if (CurrentPlayer == Player1) CurrentPlayer = Player2;
            else CurrentPlayer = Player1;
        }

        /// <summary>
        /// Check if a player has won
        /// </summary>
        private void CheckWin()
        {
            // check columns
            for (int column = 0; column < Width; column++)
            {
                Player columnPlayer = null;

                for (int row = 0; row < Height; row++)
                {
                    Player currentPlayer = Fields[column, row].CheckedPlayer;

                    if (currentPlayer == null)
                    {
                        columnPlayer = null;
                        break;
                    }
                    else
                    {
                        if (columnPlayer == null) columnPlayer = currentPlayer;
                        else if (columnPlayer != currentPlayer)
                        {
                            columnPlayer = null;
                            break;
                        }
                    }
                }

                if (columnPlayer != null)
                {
                    Winner = columnPlayer;
                    GameEnded = true;
                    return;
                }
            }

            // check rows
            for (int row = 0; row < Height; row++)
            {
                Player rowPlayer = null;

                for (int column = 0; column < Width; column++)
                {
                    Player currentPlayer = Fields[column, row].CheckedPlayer;

                    if (currentPlayer == null)
                    {
                        rowPlayer = null;
                        break;
                    }
                    else
                    {
                        if (rowPlayer == null) rowPlayer = currentPlayer;
                        else if (rowPlayer != currentPlayer)
                        {
                            rowPlayer = null;
                            break;
                        }
                    }
                }

                if (rowPlayer != null)
                {
                    Winner = rowPlayer;
                    GameEnded = true;
                    return;
                }
            }

            // check diagonal from top left to bottom right
            if (
                Fields[0,0].CheckedPlayer != null &&
                Fields[0, 0].CheckedPlayer == Fields[1, 1].CheckedPlayer &&
                Fields[1,1].CheckedPlayer == Fields[2,2].CheckedPlayer)
            {
                Winner = Fields[0, 0].CheckedPlayer;
                GameEnded = true;
                return;
            }

            // check diagonal from bottom left to top right
            if (
                Fields[0, 2].CheckedPlayer != null &&
                Fields[0, 2].CheckedPlayer == Fields[1, 1].CheckedPlayer &&
                Fields[1, 1].CheckedPlayer == Fields[2, 0].CheckedPlayer)
            {
                Winner = Fields[0, 2].CheckedPlayer;
                GameEnded = true;
                return;
            }

            // check tie
            for (int column = 0; column < Width; column++)
            {
                for (int row = 0; row < Height; row++)
                {
                    Player currentPlayer = Fields[column, row].CheckedPlayer;

                    if (currentPlayer == null) return;
                }
            }

            // no winner and all fields have been checked -> tie!
            GameEnded = true;
        }


        /// <summary>
        /// Resets the game
        /// </summary>
        public void Reset()
        {
            for (int column = 0; column < Width; column++)
            {
                for (int row = 0; row < Height; row++)
                {
                    Fields[column, row].CheckedPlayer = null;
                }
            }

            GameEnded = false;
            Winner = null;
        }


        private Game()
        {
            Width = 3;
            Height = 3;

            Fields = new Field[Width, Height];

            for (int column = 0; column < Width; column++)
            {
                for (int row = 0; row < Height; row++)
                {
                    Fields[column, row] = new Field();
                }
            }

            Player1 = new Player("Player1", "X");
            Player2 = new Player("Player2", "O");

            CurrentPlayer = Player1;

            GameEnded = false;
        }

        static Game()
        {
            Instance = new Game();
        }

    }
}
