using AutoMapper;
using ECommerce_MVC.Data;
using ECommerce_MVC.ViewModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ECommerce_MVC.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile() 
        {
            CreateMap<RegisterVM, KhachHang>();/*.ForMember(kh=>kh.HoTen,option=>option.MapFrom(RegisterVM => RegisterVM.HoTen)).ReverseMap();*/
        }
    }
}