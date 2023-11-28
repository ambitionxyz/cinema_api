using authen.Data;
using authen.Dtos;
using AutoMapper;

namespace authen.Profiles
{
  public class MovieProfile : Profile
  {
    public MovieProfile()
    {
      //Source => target
      CreateMap<Movie, MovieDTO>();

    }
  }
}