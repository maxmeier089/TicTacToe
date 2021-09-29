using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeModel;

namespace TicTacToe
{
    public class MainViewModel : ViewModel
    {

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static MainViewModel Instance { get; private set; }


        /// <summary>
        /// Global status message
        /// </summary>
        public string StatusMessage { get; private set; }


        public FieldViewModel FieldA0 { get; private set; }
        public FieldViewModel FieldB0 { get; private set; }
        public FieldViewModel FieldC0 { get; private set; }
        public FieldViewModel FieldA1 { get; private set; }
        public FieldViewModel FieldB1 { get; private set; }
        public FieldViewModel FieldC1 { get; private set; }
        public FieldViewModel FieldA2 { get; private set; }
        public FieldViewModel FieldB2 { get; private set; }
        public FieldViewModel FieldC2 { get; private set; }


        /// <summary>
        /// Command for resetting the game
        /// </summary>
        public Command ResetCommand { get; private set; }

        private void resetCommand()
        {
            Game.Instance.Reset();

            FieldA0.Notify();
            FieldA1.Notify();
            FieldA2.Notify();
            FieldB0.Notify();
            FieldB1.Notify();
            FieldB2.Notify();
            FieldC0.Notify();
            FieldC1.Notify();
            FieldC2.Notify();

            StatusMessage = Game.Instance.CurrentPlayer.Name + " begins!";
            Notify("StatusMessage");
        }


        /// <summary>
        /// Update the game status
        /// </summary>
        internal void UpdateStatus()
        {
            if (Game.Instance.GameEnded)
            {
                if (Game.Instance.Winner == null)
                {
                    StatusMessage = "Tie!";
                }
                else
                {
                    StatusMessage = Game.Instance.Winner.Name + " wins!";
                }
            }
            else
            {
                StatusMessage = Game.Instance.CurrentPlayer.Name + "'s turn";
            }

            Notify("StatusMessage");
        }



        private MainViewModel()
        {
            StatusMessage = Game.Instance.CurrentPlayer.Name + " begins!";

            FieldA0 = new FieldViewModel(Game.Instance.Fields[0, 0]);
            FieldB0 = new FieldViewModel(Game.Instance.Fields[1, 0]);
            FieldC0 = new FieldViewModel(Game.Instance.Fields[2, 0]);

            FieldA1 = new FieldViewModel(Game.Instance.Fields[0, 1]);
            FieldB1 = new FieldViewModel(Game.Instance.Fields[1, 1]);
            FieldC1 = new FieldViewModel(Game.Instance.Fields[2, 1]);

            FieldA2 = new FieldViewModel(Game.Instance.Fields[0, 2]);
            FieldB2 = new FieldViewModel(Game.Instance.Fields[1, 2]);
            FieldC2 = new FieldViewModel(Game.Instance.Fields[2, 2]);

            ResetCommand = new Command(resetCommand);
        }

        static MainViewModel()
        {
            Instance = new MainViewModel();
        }

    }
}
