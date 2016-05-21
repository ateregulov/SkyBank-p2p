using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkyBankP2p.Models;

namespace SkyBankP2p.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.BudgetCategory).Include(t => t.OperationType).Include(t => t.Wallet);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.BudgetCategoryId = new SelectList(db.BudgetCategories, "Id", "Name");
            ViewBag.OperationTypeId = new SelectList(db.OperationTypes, "Id", "Name");
            ViewBag.WalletId = new SelectList(db.Wallets, "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,Amount,BudgetCategoryId,OperationTypeId,WalletId,Comment")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetCategoryId = new SelectList(db.BudgetCategories, "Id", "Name", transaction.BudgetCategoryId);
            ViewBag.OperationTypeId = new SelectList(db.OperationTypes, "Id", "Name", transaction.OperationTypeId);
            ViewBag.WalletId = new SelectList(db.Wallets, "Id", "Name", transaction.WalletId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetCategoryId = new SelectList(db.BudgetCategories, "Id", "Name", transaction.BudgetCategoryId);
            ViewBag.OperationTypeId = new SelectList(db.OperationTypes, "Id", "Name", transaction.OperationTypeId);
            ViewBag.WalletId = new SelectList(db.Wallets, "Id", "Name", transaction.WalletId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Amount,BudgetCategoryId,OperationTypeId,WalletId,Comment")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetCategoryId = new SelectList(db.BudgetCategories, "Id", "Name", transaction.BudgetCategoryId);
            ViewBag.OperationTypeId = new SelectList(db.OperationTypes, "Id", "Name", transaction.OperationTypeId);
            ViewBag.WalletId = new SelectList(db.Wallets, "Id", "Name", transaction.WalletId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
