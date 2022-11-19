using Microsoft.EntityFrameworkCore;
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
    public class EfEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
    {
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            using(var context = new Context())
            {
                return context.EmployeeTasks.Include(x => x.AppUser).ToList();
            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
            using(var context = new Context())
            {
                return context.EmployeeTasks.Where(x => x.AppUserID == id).ToList();
            }
        }
    }
}
