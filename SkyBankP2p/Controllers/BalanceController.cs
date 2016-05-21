using SkyBankP2p.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyBankP2p.Controllers
{
    public class BalanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var transactionsBefore = db.Transactions.Where(x => x.DateTime.Month < DateTime.Now.Month).ToList();
            var transactionsAfter = db.Transactions.Where(x => x.DateTime.Month >= DateTime.Now.Month).ToList();
            var wallets = db.Wallets.ToList();

            var model = new BalanceViewModel();

            foreach (var wallet in wallets)
            {
                var startAmount = transactionsBefore.Where(x => x.Wallet == wallet).Sum(x => x.Amount);
                var endAmount = transactionsAfter.Where(x => x.Wallet == wallet).Sum(x => x.Amount);

                var item = new BalanceViewModel.Item
                {
                    Name = wallet.Name,
                    StartAmount = -startAmount,
                    EndAmount = -endAmount
                };
                model.Items.Add(item);
            };

            var debt = db.BudgetCategories.Where(x => x.Name == "Кредиты и займы").FirstOrDefault();
            model.Items.Add(new BalanceViewModel.Item
            {
                Name = "Долг",
                StartAmount = -transactionsBefore.Where(x => x.BudgetCategoryId == debt.Id).Sum(x => x.Amount),
                EndAmount = -transactionsAfter.Where(x => x.BudgetCategoryId == debt.Id).Sum(x => x.Amount)
            });

            return PartialView(model);
        }
    }
}