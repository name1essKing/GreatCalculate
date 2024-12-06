using Avalonia.Controls;
using GreatCalculate.UI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GreatCalculate.Client.Views.Tabs
{

    public sealed partial class CalculatorTabViewModel : ReactiveViewModelBase
    {
        //поле класса
        private double _firstValue;

        //поле класса
        private double _secondValue;

        //поле класса
        private string _result;
        //поле класса
        private OperationEnum _operator = OperationEnum.Plus;

        // поле класса
        private bool _operationComplete;

        // свойство
        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }
       
        //конструктор
        public CalculatorTabViewModel()
        {
            Result = "0";
        }



        // методы
        public void AddNumber(int newValue)
        {
            if (_operationComplete)
            {
                Result = newValue.ToString();
                _operationComplete = false;  
            }
            else
            {
                if (Result == "0")
                {
                    Result = newValue.ToString();
                }
                else
                {
                    Result = Result + newValue;
                }
            }
        }
        
        public void Square()
        {
            Result = Convert.ToString(Convert.ToDouble(Result) * Convert.ToDouble(Result));
        }
        public void Clearing()
        {
            Result = "0";
        }
        public void Backspace()
        {
            if (Result.Length > 1)
            {
                Result = Result.Remove(Result.Length - 1);
            }
            else if (Result.Length == 1)
            {
                Result = "0";
            }
        }
        public void SquareRoot()
        {
           Result = Convert.ToString(Math.Sqrt(Convert.ToDouble(Result)));
        }

        public void OnClick()
        {
            _firstValue = 0;
            _secondValue = 0;
            _operator = OperationEnum.Plus;
            Result = "0";
        }


        public void ErorNotify()
        {
            Result = "Исходные данные не являются числами";
        }
        public void ChangeToDivider()
        {

            if (double.TryParse(Result, out double resultValue))
            {
                Result = resultValue > 0 || resultValue < 0 ?
                     Convert.ToString(-resultValue) : 
                      resultValue.ToString();
            }   
            else
            {
                ErorNotify();
                return;
            }

        }
        public void PerformOperation(OperationEnum operation)
        {

            switch (_operator, operation)
            {
                case (OperationEnum.Dividing, OperationEnum.Dividing):
                {
                    _secondValue = _secondValue / 1;
                    break;
                }

                case (OperationEnum.Multiply, OperationEnum.Dividing) or (OperationEnum.Dividing, OperationEnum.Multiply):
                {
                    Result = Convert.ToString(_secondValue);
                    _operator = operation;
                    break;
                }

                case (OperationEnum.Multiply, OperationEnum.Multiply):
                {
                    Result = Convert.ToString(_secondValue);
                    break;
                }

                default:
                {
                    if (!double.TryParse(Result, out _secondValue))
                    {
                        ErorNotify();
                        return;
                    }
                    break;
                }
            }


            switch (_operator)
            {
                case OperationEnum.Plus:
                {
                    _firstValue += _secondValue;
                    break;
                }

                case OperationEnum.Minus:
                {
                     _firstValue -= _secondValue;
                     break;
                }

                case OperationEnum.Multiply:
                {
                    if (Result == Convert.ToString(_firstValue))
                    {
                        break;    
                    }

                    else
                    {
                        _firstValue *= _secondValue;
                        break;
                    }
                        
                }

                case OperationEnum.Dividing:
                {
                    if (_secondValue == 0)
                    {
                        Result = "Деление на ноль невозможно";
                        _firstValue = 0;
                        _secondValue = 0;
                        return;
                    }

                    else if (Result == Convert.ToString(_firstValue))
                    {
                        break;
                    }



                    else if (Result == "0")
                    {
                        break;
                    }

                    else 
                    { 
                        _firstValue /= _secondValue;
                        break;
                    }
                }


            }

            if (operation == OperationEnum.Result)
            {
                Result = Convert.ToString(_firstValue);
                _operator = OperationEnum.Plus;
                _firstValue = 0;
                _secondValue = 0;
                _operationComplete = true;
            }
            else
            {
                _operator = operation;
                Result = "0";
            }

        }


    

    
    }
    

}
    