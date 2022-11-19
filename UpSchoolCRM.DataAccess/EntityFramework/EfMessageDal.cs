using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.DataAccess.Abstract;
using UpSchoolCRM.DataAccess.Repository;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.DataAccess.EntityFramework
{
    public class EfMessageDal :GenericRepository<Message>, IMessageDal
    {
    }
}
