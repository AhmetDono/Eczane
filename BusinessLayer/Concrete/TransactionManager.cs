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
    public class TransactionManager : ITransactionService
    {
        ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public void Tadd(Transaction t)
        {
            _transactionDal.Insert(t);
        }

        public void TDelete(Transaction t)
        {
            _transactionDal.Delete(t);
        }

        public Transaction TGetByID(int id)
        {
            return _transactionDal.GetById(id);
        }

        public List<Transaction> TGetList()
        {
            return  _transactionDal.GetList();
        }

        public void TUpdate(Transaction t)
        {
            _transactionDal.Update(t);
        }
    }
}
