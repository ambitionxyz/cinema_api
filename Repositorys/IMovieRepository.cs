
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface IMovieRepository
  {
    bool SaveChanges();
    public IEnumerable<Movie> FindMoviesByIsShowingAndNameContaining(int isShowing, string name);

    public IEnumerable<Movie> FindMoviesByIsShowingOrderByIdDesc(int isShowing);

    public Movie GetById(int movieId);

  }
}