using MauiProperDaily.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiProperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DashboardViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; } 
        public decimal Balance { get; set; }
        public decimal InCome { get; set; }
        public decimal Expenses { get; set; }
        public string NoData { get; set; }

        public DashboardViewModel()
        {
            FillData();
        }

        public void FillData()
        {
            var transactions = App.TransactionsRepo.GetItems();
            transactions = transactions.OrderByDescending(x => x.OperationDate).ToList();

            Transactions = new ObservableCollection<Transaction>(transactions);

            Balance = 0;
            InCome = 0;
            Expenses = 0;
            NoData = "No Data found, click on the button to add a new transaction";

            foreach (var transaction in Transactions)
            {
                if (transaction.IsIncome)
                    InCome += transaction.Amount;
                else
                    Expenses += transaction.Amount;
            }

            Balance = InCome - Expenses;
        }
    }
}
