using Microsoft.EntityFrameworkCore;
using Movies.API.Data;
using Movies.API.GraphQL.Types.Enums;

namespace Movies.API.GraphQL.Types
{
    public class MovieType : ObjectGraphType<Movie>
    {
        public MovieType(MoviesDbContext db)
        {
            //fornecer ao GraphQL o tipo Movie
            Field(x => x.Id).Description("Id of movie");
            Field(x => x.Name).Description("Name of movie");
            Field(x => x.Description).Description("Description of movie");
            Field(x => x.LaunchDate).Description("Lauch date of movie");
            Field<MovieGenreType>("genre").Description("Genre of movie");
            Field<ListGraphType<MovieReviewType>>("reviews").Description("Reviews of movie")
                .Resolve( context =>
                {

                    if(context.Source.Reviews != null) return context.Source.Reviews;


                    var movieId = context.Source.Id;
                    return db.MovieReviews.Where(a => a.MovieId == movieId).ToList();

                });
        }
    }
}
