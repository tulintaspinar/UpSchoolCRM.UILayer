using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.DataAccess.Abstract;
using UpSchoolCRM.DataAccess.Concrete;
using UpSchoolCRM.DataAccess.Repository;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.DataAccess.EntityFramework
{
    public class EfEmployeeTaskDetailDal : GenericRepository<EmployeeTaskDetail>, IEmployeeTaskDetailDal
    {
        public List<EmployeeTaskDetail> GetEmployeeTaskDetailsById(int id)
        {
          using(var context = new Context())
            {
                return context.EmployeeTaskDetails.Where(x => x.EmployeeTaskID == id).ToList();
            }
        }
    }
}
