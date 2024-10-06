using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Infrastructure.Commands.Base;

namespace WpfUI.Infrastructure.Commands
{
    public class LambdaCommand(Action<object?>? execute, Predicate<object?>? canExecute = null) : Command
    {
        private readonly Predicate<object?> canExecute = canExecute ?? (_ => true);
        private readonly Action<object?> execute = execute ?? throw new ArgumentNullException(nameof(execute));

        public override bool CanExecute(object? parameter)
            => canExecute.Invoke(parameter);

        public override void Execute(object? parameter)
            => execute.Invoke(parameter);
    }
}
