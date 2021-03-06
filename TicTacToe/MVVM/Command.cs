using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TicTacToe
{

    public class Command : ICommand
    {

        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public Command(Action execute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }

    }

}
