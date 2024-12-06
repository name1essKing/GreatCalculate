using GreatCalculate.UI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculate.Client.Views.Tabs
{
    public class ProgressBarTabViewModel : ReactiveViewModelBase
    {
        // параметр
        private int _progressBar;

        public int ProgressBar
        {
            get => _progressBar;
            set => this.RaiseAndSetIfChanged(ref _progressBar, value);

        }

        //Конструктор
        public ProgressBarTabViewModel()
        {

            ProgressBar = 30;
        }


        public void ShowActualProgress()
        {
            ProgressBar = ProgressBar + 60;

        }





    }
}
    