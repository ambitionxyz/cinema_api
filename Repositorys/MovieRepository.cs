
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public class MovieRepository : IMovieRepository
  {

    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Movie> FindMoviesByIsShowingOrderByIdDesc(int isShowing)
    {
      var movies = _context.movies
          .Where(m => m.IsShowing == isShowing)
          .OrderByDescending(m => m.Id)
          .ToList();

      return movies;
    }

    public IEnumerable<Movie> FindMoviesByIsShowingAndNameContaining(int isShowing, string name)
    {
      var movies = _context.movies
          .Where(m => m.IsShowing == isShowing && m.Name.Contains(name))
          .ToList();

      return movies;
    }

    public void CreateNewMovie(Movie movieDto)
    {
      if (movieDto == null)
      {
        throw new ArgumentNullException(nameof(movieDto));
      }
      _context.Add(movieDto);
    }
    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public Movie GetById(int movieId)
    {
      return _context.movies.Find(movieId);
    }
  }
}