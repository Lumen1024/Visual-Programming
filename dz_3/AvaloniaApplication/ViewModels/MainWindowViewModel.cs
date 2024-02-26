using AvaloniaApplication.Models;
using AvaloniaApplication.Models.Operators.Double;
using AvaloniaApplication.Models.Operators.Single;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaApplication.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private Calculator _calculator = new Calculator();

        [ObservableProperty]
        private string display = "";

        [ObservableProperty]
        private string errorIndicator = "Transparent";

        public MainWindowViewModel()
        {
            _calculator.OnResultPublish += (string s) => Display = s;
            _calculator.OnErrorOccured += () =>
            {
                Task.Run(() => { ErrorIndicator = "Red"; Thread.Sleep(100); ErrorIndicator = "Transparent"; });
            };
        }

        [RelayCommand]
        private void DotClicked()
        {
            _calculator.AddDot();
        }

        [RelayCommand]
        private void NumpadClicked(int number)
        {
            _calculator.AddNumber(number);
        }

        [RelayCommand]
        private void OperatorClicked(string name)
        {
            switch (name)
            {
                case "plus":
                    _calculator.AddOperator(new CustomPlus());
                    break;
                case "minus":
                    _calculator.AddOperator(new CustomMinus());
                    break;
                case "implify":
                    _calculator.AddOperator(new CustomImplify());
                    break;
                case "division":
                    _calculator.AddOperator(new CustomDivision());
                    break;

                case "factorial":
                    _calculator.AddOperator(new CustomFactorial());
                    break;
                case "cos":
                    _calculator.AddOperator(new CustomCos());
                    break;
                case "sin":
                    _calculator.AddOperator(new CustomSin());
                    break;
                case "tg":
                    _calculator.AddOperator(new CustomTg());
                    break;
                case "stp":
                    _calculator.AddOperator(new CustomStp());
                    break;
                case "ceil":
                    _calculator.AddOperator(new CustomCeil());
                    break;
                case "floor":
                    _calculator.AddOperator(new CustomFloor());
                    break;


                case "mod":
                    _calculator.AddOperator(new CustomMod());
                    break;

                case "lg":
                    _calculator.AddOperator(new CustomLg());
                    break;
                case "ln":
                    _calculator.AddOperator(new CustomLn());
                    break;
            }
        }

        [RelayCommand]
        private void EqualsClicked()
        {
            _calculator.Calculate();
        }



        [RelayCommand]
        private void ReverseClicked()
        {
            _calculator.ReverseNumber();
        }

        [RelayCommand]
        private void ClearClicked()
        {
            _calculator.Clear();
        }

        [RelayCommand]
        private void UndoClicked()
        {
            _calculator.Undo();
        }
    }
}
