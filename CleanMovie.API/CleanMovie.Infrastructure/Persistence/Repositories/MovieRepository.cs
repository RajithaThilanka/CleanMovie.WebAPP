using CleanMovie.Application.Services;
using CleanMovie.Domain;

namespace CleanMovie.Infrastructure.Persistence.Repositories;

public class MovieRepository:IMovieRepository
{
    private readonly MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
    public Movie CreateMovie(Movie movie)
    {
        _movieDbContext.Movies.Add(movie);
        _movieDbContext.SaveChanges();
        return movie;   
    }

    public Movie DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public List <Movie> GetAllMovies()
    {
        return _movieDbContext.Movies.ToList();   
    }
    public Movie GetMovie(int id)
    {
        return _movieDbContext.Movies.Find(id);
    }

    public Movie UpdateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }
}