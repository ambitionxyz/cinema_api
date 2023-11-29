using authen.Data;
using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;

    public MoviesController(IMovieRepository repository,
  IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    [HttpGet("showing")]
    public IActionResult FindAllShowingMovies()
    {
      var showingMovies = _repository.FindMoviesByIsShowingOrderByIdDesc(1);
      return Ok(_mapper.Map<IEnumerable<MovieDTO>>(showingMovies));
    }

    [HttpGet("details")]
    public ActionResult<MovieDTO> GetMovieById([FromQuery] int movieId)
    {
      var movie = _repository.GetById(movieId);
      if (movie == null)
      {
        return NotFound();
      }
      return Ok(movie);
    }

    [HttpGet("showing/search")]
    public ActionResult<IEnumerable<MovieDTO>> FindAllShowingMoviesByName([FromQuery] string name)
    {
      var showingMoviesByName = _repository.FindMoviesByIsShowingAndNameContaining(1, name);
      return Ok(_mapper.Map<IEnumerable<MovieDTO>>(showingMoviesByName));
    }

    [HttpPost]
    public IActionResult UpdateMovie([FromBody] MovieCreateDTO movie)
    {

      var movieModel = _mapper.Map<Movie>(movie);
      _repository.CreateNewMovie(movieModel);
      _repository.SaveChanges();
      return Ok();
    }
  }
}