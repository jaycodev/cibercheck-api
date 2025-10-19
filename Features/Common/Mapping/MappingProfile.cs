using AutoMapper;
using CiberCheck.Features.Users.Dtos;
using CiberCheck.Features.Courses.Dtos;
using CiberCheck.Features.Sections.Dtos;
using CiberCheck.Features.Sessions.Dtos;
using CiberCheck.Features.Attendance.Dtos;
using CiberCheck.Features.Users.Entities;
using CiberCheck.Features.Courses.Entities;
using CiberCheck.Features.Sections.Entities;
using CiberCheck.Features.Sessions.Entities;
using AttendanceEntity = CiberCheck.Features.Attendance.Entities.Attendance;

namespace CiberCheck.Features.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User (tabla Users)
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>()
                .ForMember(d => d.PasswordHash, o => o.Ignore()); // no gestionamos hashing aquí
            CreateMap<UpdateUserDto, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Course
            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Section
            CreateMap<Section, SectionDto>();
            CreateMap<CreateSectionDto, Section>();
            CreateMap<UpdateSectionDto, Section>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Session
            CreateMap<Session, SessionDto>();
            CreateMap<CreateSessionDto, Session>();
            CreateMap<UpdateSessionDto, Session>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Attendance
            CreateMap<AttendanceEntity, AttendanceDto>();
            CreateMap<CreateAttendanceDto, AttendanceEntity>();
            CreateMap<UpdateAttendanceDto, AttendanceEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
