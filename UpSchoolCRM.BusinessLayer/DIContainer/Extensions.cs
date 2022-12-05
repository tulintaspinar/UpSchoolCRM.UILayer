using CRMUpSchool.DataAccess.EntityFramework;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.BusinessLayer.Concrete;
using UpSchoolCRM.BusinessLayer.ValidationRules.ContactValidation;
using UpSchoolCRM.DataAccess.Abstract;
using UpSchoolCRM.DataAccess.EntityFramework;
using UpSchoolCRM.DTOLayer.DTOs.ContactDTOs;

namespace UpSchoolCRM.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EfEmployeeDal>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDal, EfEmployeeTaskDal>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EfEmployeeTaskDetailDal>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();
        }

        public static void CustomizeValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ContactAddDTO>, ContactAddValidator>(); //bağımlılıkları minimize eden metot
            services.AddTransient<IValidator<ContactUpdateDTO>, ContactUpdateValidator>();
        }
    }
}
