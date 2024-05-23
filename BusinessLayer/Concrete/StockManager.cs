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
    public class StockManager : IStockService
    {
        IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public void Tadd(Stock t)
        {
            _stockDal.Insert(t);
        }

        public void TDelete(Stock t)
        {
            _stockDal.Delete(t);
        }

        public Stock TGetByID(int id)
        {
            return _stockDal.GetById(id);
        }

        public List<Stock> TGetLastNItems(int count)
        {
            throw new NotImplementedException();
        }

        public List<Stock> TGetList()
        {
            return _stockDal.GetList();
        }

        public void TUpdate(Stock t)
        {
            _stockDal.Update(t);
        }
    }
}
