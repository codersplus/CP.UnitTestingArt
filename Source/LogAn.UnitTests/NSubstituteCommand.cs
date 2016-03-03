using LogAn.Interfaces;

namespace LogAnTests
{
    public class NSubstituteCommand
    {
        private readonly ICommand _command;

        public NSubstituteCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();

        }

        public void DonotExecuteCommand()
        {

        }



    }
}