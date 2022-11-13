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

namespace CRMUpSchool.DataAccess.EntityFramework
{
    public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public void ChangeEmployeeStatusToFalse(int id)
        {
            using (var context = new Context())
            {
                var employee = context.Employees.Find(id);
                employee.EmployeeStatus = false;
                context.SaveChanges();
            }
        }

        public void ChangeEmployeeStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var employee = context.Employees.Find(id);
                employee.EmployeeStatus = true;
                context.SaveChanges();
            }
        }

        public List<Employee> GetEmployeesByCategory()
        {
            using(var context=new Context())
            {
                return context.Employees.Include(x=>x.Category).ToList();
            }
        }
    }
}
