using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeModel
{
    /// <summary>
    /// A game field
    /// </summary>
    public class Field
    {

        /// <summary>
        /// Stores the player who has checked this field (null if unchecked)
        /// </summary>
        public Player CheckedPlayer { get; internal set; }

        /// <summary>
        /// Check this field
        /// </summary>
        public void Check()
        {
            if (CheckedPlayer == null && !Game.Instance.GameEnded)
            {
                CheckedPlayer = Game.Instance.CurrentPlayer;
                Game.Instance.CheckGameStatus();
            }
        }

    }
}
