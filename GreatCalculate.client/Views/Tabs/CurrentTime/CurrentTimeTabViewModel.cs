using GreatCalculate.UI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculate.Client.Views.Tabs
{
    public class CurrentTimeTabViewModel : ReactiveViewModelBase
    {
        // параметр
        private string _currentTime;

        public string CurrentTime
        {
            get => _currentTime;
            set => this.RaiseAndSetIfChanged(ref _currentTime, value);

        }
       
        //Конструктор
        public CurrentTimeTabViewModel() 
        {
             
             SetCurrentTime();
        }


        public void SetCurrentTime() 
        {
            CurrentTime = DateTime.Now.ToString("dd MMMM HH:mm:ss");

        }





    }   

    
    
}
