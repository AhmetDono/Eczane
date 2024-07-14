using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StockC : Controller
    {
        StockManager _stockManager = new StockManager(new EfStockDal());

        //create stock
        [HttpPost]
        public IActionResult CreateStock(int NDC, int amount, double buyPrice, double salePrice)
        {
            var existingStock = _stockManager.TGetListByFilter(x => x.DrugFK == NDC).FirstOrDefault();
            if (existingStock != null)
            {
                existingStock.amount += amount;
                _stockManager.TUpdate(existingStock);
            }
            else
            {
                var newStock = new Stock
                {
                    DrugFK = NDC,
                    amount = amount,
                    buyPrice = buyPrice,
                    salePrice = salePrice,
                    created_at = DateTime.Now
                };
                _stockManager.Tadd(newStock);
            }
            return RedirectToAction("Index","ListStock");
        }


        [HttpPost]
        public IActionResult UpdateSalePrice(int id, double salePrice)
        {
            var stock = _stockManager.TGetByID(id);
            stock.salePrice = salePrice;
            _stockManager.TUpdate(stock);

            return RedirectToAction("Index", "ListStock");
        }
    }
}
