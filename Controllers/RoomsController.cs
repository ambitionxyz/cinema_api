using authen.Data;
using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoomsController : ControllerBase
  {
    private readonly IRoomRepository _repository;
    private readonly IMapper _mapper;

    public RoomsController(IRoomRepository repository,
  IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

  }
}