using MauiProperDaily.MVVM.Views;
using MauiProperDaily.MVVM.Models;
using MauiProperDaily.Repositories;

namespace MauiProperDaily;

public partial class App : Application
{
    public static BaseRepository<Transaction> TransactionsRepo { get; private set; }
	public App(BaseRepository<Transaction> _transactionRepo)
	{
		InitializeComponent();
        TransactionsRepo = _transactionRepo;

		MainPage = new AppContainer();
		//MainPage = new NavigationPage(new DashboardPage());
		//MainPage = new TransactionsPage();
		//MainPage = new StatisticPage();
	}
}
