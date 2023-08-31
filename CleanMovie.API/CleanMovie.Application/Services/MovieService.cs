using CleanMovie.Domain;

namespace CleanMovie.Application.Services;

public class MovieService:IMovieService
{
    private readonly IMovieRepository _movieRepository;

    //Constroctor dependency injection
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    //Create Movie
    public Movie CreateMovie(Movie movie)
    {
        _movieRepository.CreateMovie(movie);   
        return movie;   
    }

    public Movie DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    //Get All Movies
    public List<Movie> GetAllMovies()
    {
        var movies= _movieRepository.GetAllMovies();
        return movies;
    }

    public Movie GetMovie(int id)
    {
        var movie = _movieRepository.GetMovie(id);
        return movie;
    }

    public Movie UpdateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }
}