using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculate.Client.Views.Tabs
{
    public sealed partial class CalculatorTabViewModel
    {
        public sealed class CalculatorTabViewModelCommands
        {
            public CalculatorTabViewModelCommands(CalculatorTabViewModel vm)
            {
                Square = ReactiveCommand.Create(() =>
                {
                    vm.Square();
                });
                Clearing = ReactiveCommand.Create(() =>
                {
                    vm.Clearing();
                });
                Backspace = ReactiveCommand.Create(() =>
                {
                    vm.Backspace();
                });
                AddNumber = ReactiveCommand.Create<int>((int newValue) =>
                {
                    vm.AddNumber(newValue);
                });
                SquareRoot = ReactiveCommand.Create(() =>
                {
                    vm.SquareRoot();
                });
                ChangeToDivider = ReactiveCommand.Create(() =>
                {
                    vm.ChangeToDivider();
                });
                PerformOperation = ReactiveCommand.Create<OperationEnum>((operation) =>
                {
                    vm.PerformOperation(operation);
                });
                OnClick = ReactiveCommand.Create(() =>
                {
                    vm.OnClick();
                });
                ErorNotify = ReactiveCommand.Create(() =>
                {
                    vm.ErorNotify();
                });
            }

            public IReactiveCommand Square { get; }
            public IReactiveCommand Clearing { get; }
            public IReactiveCommand Backspace { get; }
            public ReactiveCommand<int, Unit> AddNumber { get; }
            public IReactiveCommand SquareRoot { get; }
            public IReactiveCommand ChangeToDivider { get; }
            public ReactiveCommand<OperationEnum, Unit> PerformOperation { get; }
            public IReactiveCommand OnClick { get; }
            public IReactiveCommand ErorNotify { get; }
        
        }

        private CalculatorTabViewModelCommands _commands;

        public CalculatorTabViewModelCommands Commands => _commands ??= new(this);
    }
}
