using authen.Data;
using authen.Dtos;
using AutoMapper;

namespace authen.Profiles
{
  public class BranchProfile : Profile
  {
    public BranchProfile()
    {
      //Source => target
      CreateMap<Branch, BranchDTO>();

    }
  }
}