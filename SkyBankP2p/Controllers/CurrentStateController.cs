using SkyBankP2p.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyBankP2p.Controllers
{
    public class CurrentStateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CurrentState
        public ActionResult Index()
        {

            var transactions = db.Transactions.ToList();
            var budgetCategories = db.BudgetCategories.ToList();
            var budgetLimits = db.BudgetLimits.ToList();
            var cells = budgetCategories.Select(x => transactions.Where(t => t.BudgetCategory == x).Sum(s => s.Amount)).ToList();

            var model = new CurrentStateViewModel
            {
                Items = budgetCategories.Select(x =>
                    new CurrentStateViewModel.Item
                    {
                        BudgetCategory = x.Name,
                        PlanAmount = (budgetLimits.Where(b => b.BudgetCategoryId == x.Id).FirstOrDefault() ?? new BudgetLimit()).Amount,
                        FactAmount = transactions.Where(t => t.BudgetCategoryId == x.Id).Sum(s => s.Amount),
                    }
                ).ToList()
            };


            return View(model);
        }
    }
}