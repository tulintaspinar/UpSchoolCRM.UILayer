using UpSchoolCRM.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.DataAccess.Abstract;

namespace UpSchoolCRM.DataAccess.EntityFramework
{
    public class EfCustomerDal: GenericRepository<Customer>,ICustomerDal
    {
    }
}
