using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.DataAccess.Repository;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.DataAccess.Abstract;

namespace UpSchoolCRM.DataAccess.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
    }
}
