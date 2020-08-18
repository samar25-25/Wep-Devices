using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepDevices.Data;
using WepDevices.Models;

namespace WepDevices.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Category, CategoryModel>().
                //ForMember(dst => dst.Id, src => src.MapFrom(e => e.ID))
                //.ForMember(dst => dst.ParentId, src => src.MapFrom(e => e.Category2.Parent_Id))
                //.ForMember(dst => dst.ParentName, src => src.MapFrom(e => e.Category2.Name)).ReverseMap();

                cfg.CreateMap<Category, CategoryModel>()
                .ReverseMap();
                cfg.CreateMap<Property, PropertyModel>()
               .ReverseMap();

                cfg.CreateMap<Device, DeviceModel>().
                ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ForMember(dst => dst.Property, src => src.MapFrom(e => e.Property.DeviceNameProperty)).
               ForMember(dst => dst.Category_Name, src => src.MapFrom(e => e.Category.Name)).ReverseMap();

                //cfg.CreateMap<Trainee, TraineeModel>().ReverseMap();
                //cfg.CreateMap<Trainee_Courses, TraineeCourseModel>()
                //.ForMember(dst => dst.CourseId, src => src.MapFrom(c => c.Course_Id))
                //.ForMember(dst => dst.Registeration_Date, src => src.MapFrom(c => c.Registeration_date)).
                //ForMember(dst => dst.Trainee, src => src.MapFrom(c => c.Trainee));



            });
            Mapper = config.CreateMapper();
        }

    }
}