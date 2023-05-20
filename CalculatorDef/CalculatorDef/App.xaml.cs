using CalculatorDef.MVVM.Views;

namespace CalculatorDef;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new CalculatorView());
    }
}
