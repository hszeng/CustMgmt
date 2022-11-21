using AutoMapper;
using CustMgmt.Entities;
using CustMgmt.Extentions;
using CustMgmt.Models;

namespace CustMgmt.Models
{
    public class CustMgmtMappingProfile : Profile
    {
        public CustMgmtMappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerForCreationDto, Customer>().ReverseMap();
            CreateMap<CustomerForUpdateDto, Customer>().ReverseMap();
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<NoteForCreationDto, Note>().ReverseMap();
            CreateMap<NoteForUpdateDto, Note>().ReverseMap();
        }
    }
}