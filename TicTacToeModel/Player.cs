using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeModel
{
    /// <summary>
    /// Game player
    /// </summary>
    public class Player
    {

        /// <summary>
        /// The player's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The player's check symbol (e.g. "X" or "O")
        /// </summary>
        public string Symbol { get; private set; }


        internal Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

    }
}
