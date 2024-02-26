using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.data;
using MyApp.foundation;

namespace MyApp.windows.main;

internal class MainViewModel
{
    public LiveData<MainState> state = new LiveData<MainState>(new MainState());
    private Calculator calculator = DependencyContainer.Calculator;
    public void OperatorClicked(OperatorName op)
    {
        switch (op)
        {
            case OperatorName.Plus:
                break;

            case OperatorName.Minus:

                break;
            case OperatorName.Impify:

                break;
            case OperatorName.Division:

                break;
            case OperatorName.Cos:

                break;
            case OperatorName.Sin:

                break;
            case OperatorName.Tg:

                break;
            case OperatorName.Floor:

                break;
            case OperatorName.Ceil:

                break;
            case OperatorName.Mod:

                break;
            case OperatorName.Step:

                break;
            case OperatorName.Factorial:

                break;
            case OperatorName.Ln:

                break;
            case OperatorName.Lg:

                break;
        }
    }

    
    public void NumberClicked(short number)
    {
        calculator.AddNumber(number);
    }

    public void DotClicked()
    {
        calculator.AddDot();
    }

    public void InvertClicked()
    {
        calculator.InvertNumber();
    }

    public void UndoClicked()
    {

    }

    public void ClearClicked()
    {

    }

    public void EqualClicked()
    {
        calculator.CalculateResult();
    }


    public MainViewModel()
    {
        calculator.OnOutputPublished += (string data) =>
        {
            state.Value = new MainState(data);
        };
    }
}

