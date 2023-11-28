using authen.Data;
using authen.Dtos;
using AutoMapper;

namespace authen.Profiles
{
  public class TicketProfile : Profile
  {
    public TicketProfile()
    {
      //Source => target
      CreateMap<Ticket, TicketDTO>();

    }
  }
}