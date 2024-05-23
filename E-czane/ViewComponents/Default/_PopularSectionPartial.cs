using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.ViewComponents.Default
{
    public class _PopularSectionPartial : ViewComponent
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());
        public IViewComponentResult Invoke()
        {
            var popularDrugs = _drugManager.TGetLastNItems(6);
            return View(popularDrugs);
        }
    }
}
