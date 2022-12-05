using AutoMapper;
using UpSchoolCRM.DTOLayer.DTOs.ContactDTOs;
using UpSchoolCRM.DTOLayer.DTOs.CustomerDTOs;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.UILayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ContactAddDTO, Contact>();
            CreateMap<Contact,ContactAddDTO>();

            CreateMap<ContactListDTO, Contact>();
            CreateMap<Contact, ContactListDTO>();

            CreateMap<ContactUpdateDTO, Contact>();
            CreateMap<Contact, ContactUpdateDTO>();

            CreateMap<CustomerAddDTO, Customer>();
            CreateMap<Customer, CustomerAddDTO>();
        }
    }
}
