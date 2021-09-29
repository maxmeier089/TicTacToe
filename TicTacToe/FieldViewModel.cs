using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeModel;

namespace TicTacToe
{
    public class FieldViewModel : ViewModel
    {

        /// <summary>
        /// The Field model
        /// </summary>
        private Field field;


        /// <summary>
        /// The text written on the field button
        /// </summary>
        public string Text
        {
            get
            {
                if (field.CheckedPlayer == null) return "";
                else return field.CheckedPlayer.Symbol;
            }
        }


        /// <summary>
        /// Returns if the field can still be checked
        /// </summary>
        public bool CanBeChecked
        {
            get { return field.CheckedPlayer == null; }
        }


        /// <summary>
        /// Command when the field is pressed
        /// </summary>
        public Command PressCommand { get; private set; }

        private void pressCommand()
        {
            field.Check();
            Notify();
            
            MainViewModel.Instance.UpdateStatus();     
        }


        /// <summary>
        /// Update the view
        /// </summary>
        internal void Notify()
        {
            Notify("Text");
            Notify("CanBeChecked");
        }


        internal FieldViewModel(Field field)
        {
            this.field = field;
            PressCommand = new Command(pressCommand);
        }

    }
}
