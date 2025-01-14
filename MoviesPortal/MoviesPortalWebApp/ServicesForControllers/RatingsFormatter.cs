﻿using BusinessLogic.ApiHandler;

namespace MoviesPortalWebApp.ServicesForControllers
{
    public class RatingsFormatter
    {
        private readonly ApiClient _client;

        public RatingsFormatter(ApiClient client)
        {
            _client = client;
        }
        public RatingsFormatter()
        {

        }
        public async Task<List<string>> GetFormattedRatingsForMovieAsync(int id, string imdbRating)
        {
            var root = await _client.GetRatingForMovie(id);
            var ratingsFromApi = root.Ratings;
            List<string> ratings = new();


            if (imdbRating.Length >= 3)
            {
                var ratio = imdbRating.Substring(0, 3);
                ratings.Add(ratio);
            }
            else
            {
                ratings.Add("N/A");
            }

            if (ratingsFromApi != null)
            {
                if (ratingsFromApi.Any(r => r.Source.Contains("Metacritic")))
                {
                    ratings.Add(ratingsFromApi.FirstOrDefault(r => r.Source.Contains("Metacritic")).Value);
                }
                else
                {
                    ratings.Add("N/A");
                }

                if (ratingsFromApi.Any(r => r.Source.Contains("Rotten")))
                {
                    ratings.Add(ratingsFromApi.FirstOrDefault(r => r.Source.Contains("Rotten")).Value);
                }
                else
                {
                    ratings.Add("N/A");
                }
            }
            else
            {
                ratings.Add("N/A");
                ratings.Add("N/A");
            }


            return ratings;
        }
    }
}
