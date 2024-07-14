using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void Tadd(Supplier t)
        {
            _supplierDal.Insert(t);
        }

        public void TDelete(Supplier t)
        {
            _supplierDal.Delete(t);
        }

        public Supplier TGetByID(int id)
        {
            return _supplierDal.GetById(id);
        }

        public List<Supplier> TGetLastNItems(int count)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> TGetList()
        {
            return _supplierDal.GetList();
        }

        public List<Supplier> TGetListByFilter(Expression<Func<Supplier, bool>> filter)
        {
            return _supplierDal.GetListByFilter(filter);
        }

        public void TUpdate(Supplier t)
        {
            _supplierDal.Update(t);
        }
    }
}
