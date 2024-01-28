using AutoMapper;
using NationalExamReporter.Models;

namespace NationalExamReporter.Mappers;

public static class ValedictoriansDetailsMap
{
    public static MapperConfiguration GetA00MapperConfig()
    {
        return new MapperConfiguration(config =>
            config.CreateMap<CsvStudent, ValedictoriansDetails>()
                .ForMember(destination => destination.ExamCode,
                    option
                        => option.MapFrom(source => source.StudentId))
                .ForMember(destination => destination.Province,
                    option
                        => option.MapFrom(source => source.Province))
                .ForMember(destination => destination.Subject1,
                    option
                        => option.MapFrom(source => source.Mathematics))
                .ForMember(destination => destination.Subject2,
                    option
                        => option.MapFrom(source => source.Physics))
                .ForMember(destination => destination.Subject3,
                    option
                        => option.MapFrom(source => source.Chemistry))
        );
    }

    public static MapperConfiguration GetB00MapperConfig()
    {
        return new MapperConfiguration(config =>
            config.CreateMap<CsvStudent, ValedictoriansDetails>()
                .ForMember(destination => destination.ExamCode,
                    option
                        => option.MapFrom(source => source.StudentId))
                .ForMember(destination => destination.Province,
                    option
                        => option.MapFrom(source => source.Province))
                .ForMember(destination => destination.Subject1,
                    option
                        => option.MapFrom(source => source.Mathematics))
                .ForMember(destination => destination.Subject2,
                    option
                        => option.MapFrom(source => source.Chemistry))
                .ForMember(destination => destination.Subject3,
                    option
                        => option.MapFrom(source => source.Biology))
        );
    }

    public static MapperConfiguration GetC00MapperConfig()
    {
        return new MapperConfiguration(config =>
            config.CreateMap<CsvStudent, ValedictoriansDetails>()
                .ForMember(destination => destination.ExamCode,
                    option
                        => option.MapFrom(source => source.StudentId))
                .ForMember(destination => destination.Province,
                    option
                        => option.MapFrom(source => source.Province))
                .ForMember(destination => destination.Subject1,
                    option
                        => option.MapFrom(source => source.Literature))
                .ForMember(destination => destination.Subject2,
                    option
                        => option.MapFrom(source => source.History))
                .ForMember(destination => destination.Subject3,
                    option
                        => option.MapFrom(source => source.Geography))
        );
    }

    public static MapperConfiguration GetD00MapperConfig()
    {
        return new MapperConfiguration(config =>
            config.CreateMap<CsvStudent, ValedictoriansDetails>()
                .ForMember(destination => destination.ExamCode,
                    option
                        => option.MapFrom(source => source.StudentId))
                .ForMember(destination => destination.Province,
                    option
                        => option.MapFrom(source => source.Province))
                .ForMember(destination => destination.Subject1,
                    option
                        => option.MapFrom(source => source.Mathematics))
                .ForMember(destination => destination.Subject2,
                    option
                        => option.MapFrom(source => source.Literature))
                .ForMember(destination => destination.Subject3,
                    option
                        => option.MapFrom(source => source.English))
        );
    }

    public static MapperConfiguration GetA01MapperConfig()
    {
        return new MapperConfiguration(config =>
            config.CreateMap<CsvStudent, ValedictoriansDetails>()
                .ForMember(destination => destination.ExamCode,
                    option
                        => option.MapFrom(source => source.StudentId))
                .ForMember(destination => destination.Province,
                    option
                        => option.MapFrom(source => source.Province))
                .ForMember(destination => destination.Subject1,
                    option
                        => option.MapFrom(source => source.Mathematics))
                .ForMember(destination => destination.Subject2,
                    option
                        => option.MapFrom(source => source.Physics))
                .ForMember(destination => destination.Subject3,
                    option
                        => option.MapFrom(source => source.English))
        );
    }
}