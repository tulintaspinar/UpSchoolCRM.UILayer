using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.DataAccess.Abstract;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.DataAccess.Abstract
{
    public interface IEmployeeTaskDal : IGenericDal<EmployeeTask>
    {
        List<EmployeeTask> GetEmployeeTaskByEmployee();
        List<EmployeeTask> GetEmployeeTaskById(int id);
    }
}
