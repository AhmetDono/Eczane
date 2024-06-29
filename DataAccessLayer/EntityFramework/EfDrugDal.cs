using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDrugDal : GenericRepository<Drug>, IDrugDal
    {
        public List<Drug> GetListWithSupplier()
        {
            using (var context = new Context())
            {
                return context.Drugs.Include(d => d.Supplier).ToList();
            }
        }
    }
}
