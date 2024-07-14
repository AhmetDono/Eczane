using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.ViewComponents.Default
{
    public class _PopularSectionPartial : ViewComponent
    {
        StockManager _stockManager = new StockManager(new EfStockDal());
        public IViewComponentResult Invoke()
        {
            var popularDrugs = _stockManager.TGetLastNItems(6);
            return View(popularDrugs);
        }
    }
}
