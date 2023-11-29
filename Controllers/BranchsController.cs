using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BranchsController : ControllerBase
  {
    private readonly IBranchRepository _repository;
    private readonly IMapper _mapper;

    public BranchsController(IBranchRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBranchesThatShowTheMovie([FromQuery] int movieId)
    {
      var branches = _repository.getBranchesThatShowTheMovie(movieId);

      if (branches == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<IEnumerable<BranchDTO>>(branches));
    }
  }
}