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
    public class DrugManager : IDrugService
    {
        IDrugDal _drugDal;

        public DrugManager(IDrugDal drugDal)
        {
            _drugDal = drugDal;
        }

        public void Tadd(Drug t)
        {
            _drugDal.Insert(t);
        }

        public void TDelete(Drug t)
        {
            _drugDal.Delete(t);
        }

        public Drug TGetByID(int id)
        {
            return _drugDal.GetById(id);
        }

        public List<Drug> TGetList()
        {
            return _drugDal.GetList();
        }

        public void TUpdate(Drug t)
        {
            _drugDal.Update(t);
        }
    }
}
