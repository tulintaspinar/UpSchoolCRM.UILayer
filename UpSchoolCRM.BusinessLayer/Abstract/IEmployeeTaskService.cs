using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.BusinessLayer.Abstract
{
    public interface IEmployeeTaskService : IGenericService<EmployeeTask>
    {
        List<EmployeeTask> GetEmployeeTaskByEmployee();
        List<EmployeeTask> TGetEmployeeTaskById(int id);
    }
}
