using MauiProperDaily.MVVM.ViewModels;

namespace MauiProperDaily.MVVM.Views;

public partial class StatisticPage : ContentPage
{
	public StatisticPage()
	{
		InitializeComponent();
		BindingContext = new StatisticsViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = (StatisticsViewModel)BindingContext;
        vm.GettransactionSymmary();
    }
}