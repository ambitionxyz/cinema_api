using authen.Data;
using authen.Dtos;
using AutoMapper;

namespace authen.Profiles
{
  public class RoomProfile : Profile
  {
    public RoomProfile()
    {
      //Source => target
      CreateMap<Room, RoomDTO>();

    }
  }
}