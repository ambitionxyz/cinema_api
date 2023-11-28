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
    public IActionResult UpdateMovie([FromBody] Movie movie)
    {
      var movieUpdate = _repository.GetById(movie.Id);

      if (movieUpdate == null)
      {
        return NotFound();
      }

      movieUpdate.SmallImageURL = movie.SmallImageURL;
      movieUpdate.LargeImageURL = movie.LargeImageURL;
      movie.Director = movie.Director;
      movie.Actors = movie.Actors;
      movie.Name = movie.Name;
      movie.ShortDescription = movie.ShortDescription;
      movie.LongDescription = movie.LongDescription;
      movie.Categories = movie.Categories;
      movie.ReleaseDate = movie.ReleaseDate;
      movie.Duration = movie.Duration;
      movie.TrailerURL = movie.TrailerURL;
      movie.Language = movie.Language;
      movie.Rated = movie.Rated;
      movie.IsShowing = movie.IsShowing;

      _repository.SaveChanges();
      return Ok();
    }
  }
}