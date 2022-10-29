using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud_BankTransactions.Models;
using System.Transactions;

namespace Crud_BankTransactions.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionDBContext _context;

        public TransactionsController(TransactionDBContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Transactions.ToListAsync());
        }

  

        // GET: Transactions/AddOrEditorUpdate
        public IActionResult AddOrEdit(int id=0)
        {
            if(id== 0)
                /*thus by adding id as a paramater, 
 we declare that default page id is 0, then comes default new transaction view..
                but if not 0 thant means its not a new transaction but an update of older one..
                that why below, else expression calls from context 
                and corresponding id which is edited earlier*/
                return View(new TransactionsModel());
            else
                return View(_context.Transactions.Find(id));
        }

        // POST: Transactions/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind
            ("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTcode,Amount,Date")] 
        TransactionsModel transactionsModel)
        {
            if (ModelState.IsValid)
            {
                if (transactionsModel.TransactionId == 0)
                /*if id =0 then it is an insert/add operation*/
                {
                    transactionsModel.Date = DateTime.Now;
                    _context.Add(transactionsModel);
                }
                else
                {
                    /*if id !=0 the it is an update operation*/
                    _context.Update(transactionsModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(transactionsModel);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'TransactionDBContext.Transactions'  is null.");
            }
            var transactionsModel = await _context.Transactions.FindAsync(id);
            if (transactionsModel != null)
            {
                _context.Transactions.Remove(transactionsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
