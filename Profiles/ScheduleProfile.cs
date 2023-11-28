using authen.Data;
using authen.Dtos;
using AutoMapper;

namespace authen.Profiles
{
  public class ScheduleProfile : Profile
  {
    public ScheduleProfile()
    {
      //Source => target
      CreateMap<Schedule, ScheduleDTO>();

    }
  }
}