using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.DataAccess.Abstract
{
    public interface IEmployeeTaskDetailDal:IGenericDal<EmployeeTaskDetail>
    {
        List<EmployeeTaskDetail> GetEmployeeTaskDetailsById(int id);
    }
}
