using AutoMapper;
using BLL.ViewModels;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                config.CreateMap<Teacher, TeacherViewModel>()
                .ForMember(teacherViewModel => teacherViewModel.Photo, conf => conf.MapFrom(user => user.AppUser.Photo))
                .ForMember(teacherViewModel => teacherViewModel.Email, conf => conf.MapFrom(user => user.AppUser.Email))
                .ForMember(teacherViewModel => teacherViewModel.MethodicalAssociation, conf => conf.MapFrom(user => user.MethodicalAssociation))
                .ForMember(teacherViewModel => teacherViewModel.FirstName, conf => conf.MapFrom(user => user.AppUser.FirstName))
                .ForMember(teacherViewModel => teacherViewModel.LastName, conf => conf.MapFrom(user => user.AppUser.LastName))
                .ForMember(teacherViewModel => teacherViewModel.Subjects, conf => conf.MapFrom(subject => subject.TeacherSubjects.Select(s => s.Subject.Name)));

                config.CreateMap<MethodicalAssociationViewModel, MethodicalAssociation>();
                config.CreateMap<MethodicalAssociation, MethodicalAssociationViewModel>();

                config.CreateMap<SubjectViewModel, Subject>();
                config.CreateMap<Subject, SubjectViewModel>();

                config.CreateMap<TeacherSubjectViewModel, TeacherSubject>();
                config.CreateMap<TeacherSubject, TeacherSubjectViewModel>();
            });
        }
    }
}
