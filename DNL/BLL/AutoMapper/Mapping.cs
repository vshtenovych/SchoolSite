using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.AutoMapper
{
    public static class Mapping
    {
        public static TResult Map<TSource, TResult>(TSource source)
        {
            return Mapper.Map<TSource, TResult>(source);
        }
        static Mapping()
        {
            Mapper.Initialize(config => {
                
                //config.CreateMap<CompanyViewModel, Company>()
                //.ForMember(company => company.Name, conf => conf.MapFrom(companyViewModel => companyViewModel.CompanyName))
                //.ForMember(company => company.Photo, conf => conf.MapFrom(companyViewModel => companyViewModel.CompanyLogoSource))
                //.ForMember(company => company.Intro, conf => conf.MapFrom(companyViewModel => companyViewModel.WhoWeAreText))
                //.ForMember(company => company.Area, conf => conf.MapFrom(companyViewModel => companyViewModel.CompanyArea));
                //config.CreateMap<Company, CompanyViewModel>()
                //.ForMember(companyViewModel => companyViewModel.CompanyName, conf => conf.MapFrom(company => company.Name))
                //.ForMember(companyViewModel => companyViewModel.CompanyArea, conf => conf.MapFrom(company => company.Area))
                //.ForMember(companyViewModel => companyViewModel.CompanyLogoSource, conf => conf.MapFrom(company => company.Photo))
                //.ForMember(companyViewModel => companyViewModel.WhoWeAreText, conf => conf.MapFrom(company => company.Intro))
                //.ForMember(companyViewModel => companyViewModel.Vacancies, conf => conf.MapFrom(company => company.Jobs));
            
            });
        }
    }
}
