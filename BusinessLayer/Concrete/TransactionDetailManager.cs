﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TransactionDetailManager : ITransactionDetailService
    {
        ITransactionDetailDal _transactionDetailDal;

        public TransactionDetailManager(ITransactionDetailDal transactionDetailDal)
        {
            _transactionDetailDal = transactionDetailDal;
        }

        public void Tadd(TransactionDetail t)
        {
            _transactionDetailDal.Insert(t);
        }

        public void TDelete(TransactionDetail t)
        {
            _transactionDetailDal.Delete(t);
        }

        public TransactionDetail TGetByID(int id)
        {
            return _transactionDetailDal.GetById(id);
        }

        public List<TransactionDetail> TGetLastNItems(int count)
        {
            throw new NotImplementedException();
        }

        public List<TransactionDetail> TGetList()
        {
            return _transactionDetailDal.GetList();
        }

        public void TUpdate(TransactionDetail t)
        {
            _transactionDetailDal.Update(t);
        }
    }
}
