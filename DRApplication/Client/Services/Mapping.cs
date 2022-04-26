﻿using AutoMapper;
using DRApplication.Client.ViewModels.ConfigurationViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Services
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HardwareConfigVm, HardwareConfig>().ReverseMap();

            //CreateMap<EditTrackingVm, Tracking>().ReverseMap();
            

            //CreateMap<Tracking, TrackingVm>()
            //    .ForMember(dest => dest.Status,
            //        opts => opts.MapFrom(src => src.Status!.Name))
            //    .ForMember(dest => dest.ToFrom,
            //        opts => opts.MapFrom(src => src.ToFrom!.Name))
            //    .ForMember(dest => dest.CorrespondenceType,
            //        opts => opts.MapFrom(src => src.CorrespondenceType!.Name))
            //    .ForMember(dest => dest.Topic,
            //        opts => opts.MapFrom(src => src.Thread!.Name))
            //    .ForMember(dest => dest.Poc,
            //        opts => opts.MapFrom(src => src.Poc!.Name));
        }
    }
}
