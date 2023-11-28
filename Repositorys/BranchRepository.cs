
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public class BranchRepository : IBranchRepository
  {

    private readonly ApplicationDbContext _context;

    public BranchRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Branch> getBranchesThatShowTheMovie(int movieId)
    {
      var branches = _context.branches
          .Where(b => _context.schedules.Any(s => s.Branch.Id == b.Id && s.Movie.Id == movieId))
          .ToList();

      return branches;
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}