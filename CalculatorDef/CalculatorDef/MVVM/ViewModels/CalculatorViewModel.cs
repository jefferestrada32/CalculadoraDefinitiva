using System;
using System.Text;
using System.Windows.Input;
using CalculatorDef.Models;
using PropertyChanged;

namespace CalculatorDef.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel
    {
        private string _currentNumber = string.Empty;
        private double _previousNumber;
        private string _selectedOperator;
        private CalculatorModel _calculatorModel;

        public string CurrentNumber { get; set; }
        public string ErrorMessage { get; set; }
        public string History { get; set; }
        public ICommand NumberCommand { get; private set; }
        public ICommand OperationCommand { get; private set; }
        public ICommand CalculateCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            NumberCommand = new Command<string>(AppendNumber);
            OperationCommand = new Command<string>(SetOperator);
            CalculateCommand = new Command(CalculateResult);
            ClearCommand = new Command(Clear);
            History = string.Empty;
        }

        private void AppendNumber(string number)
        {
            UpdateHistory($"{number}");
            CurrentNumber += number;
        }

        private void SetOperator(string operation)
        {
            _previousNumber = Convert.ToDouble(CurrentNumber);
            _selectedOperator = operation;
            CurrentNumber = string.Empty;
            //UpdateHistory($"{_previousNumber} {_selectedOperator} ");
            UpdateHistory($"{_selectedOperator}");
        }

        private void CalculateResult()
        {
            double currentNumber = Convert.ToDouble(CurrentNumber);

            try
            {
                double result = _calculatorModel.PerformOperation(_previousNumber, currentNumber, _selectedOperator);
                CurrentNumber = result.ToString();
                ErrorMessage = string.Empty;
                //UpdateHistory($"{_previousNumber} {_selectedOperator} {currentNumber}");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void Clear()
        {
            CurrentNumber = string.Empty;
            ErrorMessage = string.Empty;
            History = string.Empty;
            _previousNumber = 0;
            _selectedOperator = null;
        }

        private void UpdateHistory(string entry)
        {
            History += entry;
        }
    }
}
