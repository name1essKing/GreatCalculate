using GreatCalculate.UI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculate.Client.Views.Tabs
{
    public class TaskManagerTabViewModel : ReactiveViewModelBase
    {
        private bool _taskManagerMark;

        public bool TaskManagerMark
        {
            get => _taskManagerMark;
            set => this.RaiseAndSetIfChanged(ref _taskManagerMark, value);
        }

        //Конструктор
        public TaskManagerTabViewModel()
        {
            TaskManagerMark = true;
        }

       
    
    
    } 

}
