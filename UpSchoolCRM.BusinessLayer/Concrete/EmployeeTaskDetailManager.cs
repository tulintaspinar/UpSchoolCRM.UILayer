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
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        IEmployeeTaskDetailDal _employeeTaskDetail;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetail)
        {
            _employeeTaskDetail = employeeTaskDetail;
        }

        public List<EmployeeTaskDetail> TGetEmployeeTaskDetailsById(int id)
        {
            return _employeeTaskDetail.GetEmployeeTaskDetailsById(id);
        }

        public void TDelete(EmployeeTaskDetail t)
        {
            _employeeTaskDetail.Delete(t);
        }

        public EmployeeTaskDetail TGetById(int id)
        {
            return _employeeTaskDetail.GetById(id);
        }

        public List<EmployeeTaskDetail> TGetList()
        {
            return _employeeTaskDetail.GetList();
        }

        public void TInsert(EmployeeTaskDetail t)
        {
            _employeeTaskDetail.Insert(t);
        }

        public void TUpdate(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }
    }
}
