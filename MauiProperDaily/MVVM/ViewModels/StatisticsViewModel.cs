using MauiProperDaily.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PropertyChanged;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiProperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSommary> Summary { get ; set; }
        public ObservableCollection<Transaction> SpendingList { get ; set; }

        public void GettransactionSymmary()
        {
            var Data = App.TransactionsRepo.GetItems();
            var result = new List<TransactionsSommary>();
            var groupedTansactions = Data.GroupBy(t => t.OperationDate);

            foreach (var group in groupedTansactions)
            {
                var _transactionSummary = new TransactionsSommary
                {
                    TransactionsDate = group.Key,
                    TransactionsTotal = group.Sum(t => t.IsIncome ? t.Amount : t.Amount),
                    ShownDate = group.Key.ToString("MM/dd")
                };

                result.Add(_transactionSummary);
            }

            result = result.OrderBy(t => t.TransactionsDate).ToList();

            Summary = new ObservableCollection<TransactionsSommary>(result);

            var spendingList = Data.Where(x => x.IsIncome == false);

            SpendingList = new ObservableCollection<Transaction>(spendingList);
        }
    }
}
