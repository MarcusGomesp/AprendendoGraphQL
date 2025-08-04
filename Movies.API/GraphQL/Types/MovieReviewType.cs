namespace Movies.API.GraphQL.Types
{
    public class MovieReviewType : ObjectGraphType<MovieReview>
    {
        public MovieReviewType()
        {
            //fornecer ao GraphQL o tipo MovieReview
            Field(x => x.Id).Description("Id of review");
            Field(x => x.Rate).Description("Rate of review");
            Field(x => x.Comment).Description("Comment of review");
            Field(x => x.CreatedAt).Description("Date of Create of review");
            Field(x => x.MovieId).Description("Movie Id of review");
        }
    }

}
