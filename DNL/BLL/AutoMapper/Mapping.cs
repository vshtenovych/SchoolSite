using AutoMapper;
using BLL.ViewModels;
using Core.Entities;
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

                config.CreateMap<NewsViewModel, News>();
                config.CreateMap<News, NewsViewModel>();


                config.CreateMap<PersonalViewModel, Personal>();
                config.CreateMap<Personal, PersonalViewModel>();

                config.CreateMap<AlbumViewModel, Album>();
                config.CreateMap<Album, AlbumViewModel>();

                config.CreateMap<TeacherViewModel, Teacher>();
                config.CreateMap<Teacher, TeacherViewModel>();
            });
        }
    }
}
