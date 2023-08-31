using CleanMovie.Domain;

namespace CleanMovie.Application.Services;

public interface IMovieService
{
    Movie CreateMovie(Movie movie);
    List<Movie> GetAllMovies();
    Movie GetMovie(int id);
    Movie UpdateMovie(Movie movie);
    Movie DeleteMovie(int id);
}