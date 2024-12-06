using GreatCalculate.Client.Views.Tabs;
using GreatCalculate.UI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculate.Client.Views
{

    public sealed partial class MainWindowViewModel : ReactiveViewModelBase
    {


        public CalculatorTabViewModel CalculatorTabViewModel { get; }
        public CurrentTimeTabViewModel CurrentTimeTabViewModel { get; }
        public TaskManagerTabViewModel TaskManagerTabViewModel { get; }
        public ProgressBarTabViewModel ProgressBarTabViewModel { get; }

        //конструктор 
        public MainWindowViewModel()
        {
            CalculatorTabViewModel = new CalculatorTabViewModel();
            CurrentTimeTabViewModel = new CurrentTimeTabViewModel();
            TaskManagerTabViewModel = new TaskManagerTabViewModel();
            ProgressBarTabViewModel = new ProgressBarTabViewModel();
        }

        
    }
}   
