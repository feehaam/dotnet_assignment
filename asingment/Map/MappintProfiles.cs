using asingment.Dto;
using AutoMapper;
using DataAccessLayer.Model;

namespace asingment.Helper
{
    public class MappintProfiles: Profile
    {
        public MappintProfiles()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<TasksDto, Task>();
        }
    }
}
