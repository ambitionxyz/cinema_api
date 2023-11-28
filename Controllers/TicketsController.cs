using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TicketsController : ControllerBase
  {
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public TicketsController(ITicketRepository repository,
  IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBranchesThatShowTheMovie([FromQuery] string userId)
    {
      var tickets = _repository.findTicketsByUserId(userId);

      if (tickets == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<IEnumerable<TicketDTO>>(tickets));
    }
  }
}