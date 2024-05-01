using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MenuManager : IMenuService
    {
        IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public void Tadd(Menu t)
        {
            _menuDal.Insert(t);
        }

        public void TDelete(Menu t)
        {
            _menuDal.Delete(t);
        }

        public Menu TGetByID(int id)
        {
            return _menuDal.GetById(id);
        }

        public List<Menu> TGetList()
        {
            return _menuDal.GetList();
        }

        public void TUpdate(Menu t)
        {
            _menuDal.Update(t);
        }
    }
}
