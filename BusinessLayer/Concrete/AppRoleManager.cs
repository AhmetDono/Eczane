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
    public class AppRoleManager : IAppRoleService
    {
        IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }

        public void Tadd(AppRole t)
        {
            _appRoleDal.Insert(t);
        }

        public void TDelete(AppRole t)
        {
            _appRoleDal.Delete(t);
        }

        public AppRole TGetByID(int id)
        {
           return _appRoleDal.GetById(id);
        }

        public List<AppRole> TGetList()
        {
            return _appRoleDal.GetList();
        }

        public void TUpdate(AppRole t)
        {
            _appRoleDal.Update(t);
        }
    }
}
