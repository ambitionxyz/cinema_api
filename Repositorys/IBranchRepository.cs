
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface IBranchRepository
  {
    bool SaveChanges();

    IEnumerable<Branch> getBranchesThatShowTheMovie(int movieId);

  }
}