using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.ViewComponents.Default
{
    public class _NewProductsPartial : ViewComponent
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());
        public IViewComponentResult Invoke()
        {
            var newDrugs = _drugManager.TGetLastNItems(4);
            return View(newDrugs);
        }
    }
}
