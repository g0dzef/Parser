using System.Windows.Input;

namespace Parser.WPF.Commands.Base
{
    public abstract class AsyncCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private bool _isExecuting;
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
            }
        }

        public bool CanExecute(object? parameter)
        {
          return !IsExecuting;
        }

        public async void Execute(object? parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object? parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
