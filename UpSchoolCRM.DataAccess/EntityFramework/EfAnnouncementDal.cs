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
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public List<Announcement> ContainA()
        {
            using(var context = new Context())
            {
                return context.Announcements.Where(c => EF.Functions.Like(c.Title,"A")).ToList();
                //return context.Announcements.Where(x => x.Title.Contains("a")).ToList();
            }
        }
    }
}
