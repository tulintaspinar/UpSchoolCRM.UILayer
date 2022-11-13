using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.DataAccess.Abstract;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.BusinessLayer.Concrete
{
    public class EmployeeTaskManager : IEmployeeTaskService
    {
        IEmployeeTaskDal _employeeTaskDal;

        public EmployeeTaskManager(IEmployeeTaskDal employeeTaskDal)
        {
           _employeeTaskDal = employeeTaskDal;
        }

        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
           return _employeeTaskDal.GetEmployeeTaskByEmployee();
        }

        public void TDelete(EmployeeTask t)
        {
            _employeeTaskDal.Delete(t);
        }

        public EmployeeTask TGetById(int id)
        {
            return _employeeTaskDal.GetById(id);
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDal.GetList();
        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDal.Insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            _employeeTaskDal.Update(t);
        }
    }
}
