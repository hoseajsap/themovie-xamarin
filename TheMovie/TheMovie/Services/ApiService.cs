using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using TheMovie.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TheMovie.Services
{
    public class ApiService : IApiService
    {
        private static string Base_Url = "https://api.themoviedb.org/3";
        private static string apiKey = "16da92e0118d5cf9fdbfc79bb135cebf";

        private static string Base_Url_With_Api(string path, List<String> parameter = null)
        {
            string parameterUri = "";
            if (parameter != null && parameter.Count > 0)
            {
                parameterUri = String.Join("&", parameter.ToArray());
            }
            return $"{Base_Url}{path}?api_key={apiKey}&language=en-US&{parameterUri}";
        }

        public async Task<AllGenre> getAllGenre ()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            HttpResponseMessage responseMessage = await client.GetAsync(Base_Url_With_Api("/genre/movie/list"));

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<AllGenre>(result);

                return json;
            }

            return null;
        }

        public async Task<ResultDiscoverMovie> getDiscoverByGenre(int id, int page)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            List<String> parameter = new List<string>
            {
                $"page={page.ToString()}", "sort_by=popularity.desc", $"with_genres={id.ToString()}"
            };

            string url = Base_Url_With_Api("/discover/movie", parameter);

            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ResultDiscoverMovie>(result);

                return json;
            }

            return null;
        }

        public async Task<ResultDiscoverMovie> getDetailsMovie(int id, int page)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            List<String> parameter = new List<string>
            {
                $"page={page.ToString()}", "sort_by=popularity.desc", $"with_genres={id.ToString()}"
            };

            string url = Base_Url_With_Api("/discover/movie", parameter);

            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ResultDiscoverMovie>(result);

                return json;
            }

            return null;
        }

        public async Task<MovieDetail> GetMovieDetail(int movieId)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            List<String> parameter = new List<string>
            {
                $"append_to_response=videos"
            };

            string url = Base_Url_With_Api($"/movie/{movieId}", parameter);

            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<MovieDetail>(result);

                return json;
            }

            return null;
        }

        public async Task<AllReview> GetMovieReview(int movieId, int page)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            HttpClient client = new HttpClient(httpClientHandler);
            List<String> parameter = new List<string>
            {
                $"page={page.ToString()}"
            };

            string url = Base_Url_With_Api($"/movie/{movieId}/reviews", parameter);

            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<AllReview>(result);

                return json;
            }

            return null;
        }
    }
}

