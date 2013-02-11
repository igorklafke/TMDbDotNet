using System;
using System.Collections.Specialized;

namespace TMDbDotNet.TmdbApi
{
    public class TMDb
    {
        string _apikey;
        string _baseurl = "http://api.themoviedb.org/3/{0}?api_key={1}";
        string _sessionID;
        string _language;

        public TMDb(string apikey)
        {
            _apikey = apikey;
            _language = "";
        }

        public TMDb(string apikey, string language)
        {
            _apikey = apikey;
            _language = language;
        }

        public void SetLanguage(string language)
        {
            _language = language;
        }
        public string GetLanguage()
        {
            return _language;
        }

        public bool SessionExists()
        {
            return !string.IsNullOrEmpty(_sessionID);
        }

        #region Configuration
        /// <summary>
        /// Get the system wide configuration information for images.
        /// </summary>
        /// <returns></returns>
        public Configuration GetConfiguration()
        {
            return Utils.HttpGet<Configuration>(BuildUrl("configuration"));
        }
        /// <summary>
        /// Get the system wide configuration information for images asynchronously.
        /// </summary>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetConfigurationAsync(Action<Configuration> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("configuration"), onCompleted, onError);
        }
        #endregion

        #region Authentication
        /// <summary>
        /// This method is used to generate a valid request token for user based authentication. A request token is required in order to request a session id.
        /// </summary>
        /// <returns></returns>
        public AuthenticationToken GetAuthenticationToken()
        {
            return Utils.HttpGet<AuthenticationToken>(BuildUrl("authentication/token/new"));
        }
        /// <summary>
        /// This method is used to generate a valid request token for user based authentication asynchronously. A request token is required in order to request a session id.
        /// </summary>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetAuthenticationTokenAsync(Action<AuthenticationToken> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("authentication/token/new"), onCompleted, onError);
        }


        /// <summary>
        /// This method is used to generate a session id for user based authentication. A session id is required in order to use any of the write methods.
        /// </summary>
        /// <param name="request_token"></param>
        /// <returns></returns>
        public UserSession GetUserSession(string request_token)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("request_token", request_token);
            UserSession userSession = Utils.HttpGet<UserSession>(BuildUrl("authentication/session/new", parameters));

            SetUserSession(userSession.session_id);
            return userSession;
        }
        /// <summary>
        /// This method is used to generate a session id for user based authentication asynchronously. A session id is required in order to use any of the write methods.
        /// </summary>
        /// <param name="request_token"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetUserSessionAsync(string request_token, Action<UserSession> onCompleted = null, Action<Exception> onError = null)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("request_token", request_token);
            Utils.HttpGetAsync(BuildUrl("authentication/session/new", parameters),
                delegate(UserSession userSession)
                {
                    SetUserSession(userSession.session_id);
                    if (onCompleted != null)
                        onCompleted(userSession);
                }, onError);
        }


        public void SetUserSession(string session_id)
        {
            _sessionID = session_id;
        }
        #endregion

        #region Account
        /// <summary>
        /// Get the basic information for an account.
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public Account GetAccount()
        {
            return Utils.HttpGet<Account>(BuildUrl("account", null, null, true));   
        }
        /// <summary>
        /// Get the list of favorite movies for an account.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieSearch GetFavoriteMovies(int id, int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("account/{0}/favorite_movies", id, MovieListParameters(page), true));
        }
        /// <summary>
        /// Add or remove a movie to an accounts favorite list.
        /// </summary>
        public void AddRemoveFavoriteMovie(int account_id, int movie_id, bool remove = false)
        {
            Utils.HttpPost<Account>(
                BuildUrl("account/{0}/favorite", account_id, null, true), 
                new { movie_id = movie_id, favorite = !remove });
            
        }
        /// <summary>
        /// Get the list of rated movies for an account.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieSearch GetRatedMovies(int id, int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("account/{0}/rated_movies", id, MovieListParameters(page), true));
        }
        /// <summary>
        /// Get the list of movies on an accounts watchlist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieSearch GetMovieWatchlist(int id, int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("account/{0}/movie_watchlist", id, MovieListParameters(page), true));
        }
        /// <summary>
        /// Add or remove a movie to an accounts watch list.
        /// </summary>
        public void AddRemoveMovieWatchlist(int account_id, int movie_id, bool remove = false)
        {
            Utils.HttpPost<Status>(
                BuildUrl("account/{0}/movie_watchlist", account_id, null, true),
                new { movie_id = movie_id, movie_watchlist = !remove });
        }
        #endregion

        #region Movie
        /// <summary>
        /// Get the basic movie information for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie GetMovie(int id)
        {
            return Utils.HttpGet<Movie>(BuildUrl("movie/{0}", id, LanguageParameter()));
        }
        /// <summary>
        /// Get the basic movie information for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="onCompleted"></param>
        public void GetMovieAsync(int id, Action<Movie> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}", id, LanguageParameter()), onCompleted, onError);
        }


        /// <summary>
        /// Get the alternative titles for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieAlternativeTitles GetMovieAlternativeTitles(int id)
        {
            return Utils.HttpGet<MovieAlternativeTitles>(BuildUrl("movie/{0}/alternative_titles", id));
        }
        /// <summary>
        /// Get the alternative titles for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="onCompleted"></param>
        public void GetMovieAlternativeTitlesAsync(int id, Action<MovieAlternativeTitles> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/alternative_titles", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the cast information for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieCasts GetMovieCasts(int id)
        {
            return Utils.HttpGet<MovieCasts>(BuildUrl("movie/{0}/casts", id));
        }
        /// <summary>
        /// Get the cast information for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void GetMovieCastsAsync(int id, Action<MovieCasts> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/casts", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the images (posters and backdrops) for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieImages GetMovieImages(int id)
        {
            return Utils.HttpGet<MovieImages>(BuildUrl("movie/{0}/images", id, LanguageParameter()));
        }
        /// <summary>
        /// Get the images (posters and backdrops) for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void GetMovieImagesAsync(int id, Action<MovieImages> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/images", id, LanguageParameter()), onCompleted, onError);
        }


        /// <summary>
        /// Get the plot keywords for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieKeywords GetMovieKeyWords(int id)
        {
            return Utils.HttpGet<MovieKeywords>(BuildUrl("movie/{0}/keywords", id));
        }
        /// <summary>
        /// Get the plot keywords for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void GetMovieKeyWordsAsync(int id, Action<MovieKeywords> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/keywords", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the release date by country for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieReleases GetMovieReleases(int id)
        {
            return Utils.HttpGet<MovieReleases>(BuildUrl("movie/{0}/releases", id));
        }
        /// <summary>
        /// Get the release date by country for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void GetMovieReleasesAsync(int id, Action<MovieReleases> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/releases", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the trailers for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieTrailers GetMovieTrailers(int id)
        {
            return Utils.HttpGet<MovieTrailers>(BuildUrl("movie/{0}/trailers", id));
        }
        /// <summary>
        /// Get the trailers for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetMovieTrailersAsync(int id, Action<MovieTrailers> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/trailers", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the translations for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieTranslations GetMovieTranslations(int id)
        {
            return Utils.HttpGet<MovieTranslations>(BuildUrl("movie/{0}/translations", id));
        }
        /// <summary>
        /// Get the translations for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetMovieTranslationsAsync(int id, Action<MovieTranslations> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/translations", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the similar movies for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public MovieSearch GetSimilarMovies(int id, int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("movie/{0}/similar_movies", id, MovieListParameters(page)));
        }
        /// <summary>
        /// Get the similar movies for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetSimilarMoviesAsync(int id, int? page = null, Action<MovieSearch> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/similar_movies", id, MovieListParameters(page)), onCompleted, onError);
        }


        /// <summary>
        /// Get the changes for a specific movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Changes GetMovieChanges(int id)
        {
            return Utils.HttpGet<Changes>(BuildUrl("movie/{0}/changes", id));
        }
        /// <summary>
        /// Get the changes for a specific movie id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetMovieChangesAsync(int id, Action<Changes> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/{0}/changes", id), onCompleted, onError);
        }


        /// <summary>
        /// Get the latest movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie GetLatestMovie()
        {
            return Utils.HttpGet<Movie>(BuildUrl("movie/latest"));
        }
        /// <summary>
        /// Get the latest movie asynchronously.
        /// </summary>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetLatestMovieAsync(Action<Movie> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/latest"), onCompleted, onError);
        }


        /// <summary>
        /// Get the list of upcoming movies. This list refreshes every day. The maximum number of items this list will include is 100.
        /// </summary>
        /// <returns></returns>
        public MovieSearch GetUpcomingMovies(int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("movie/upcoming", MovieListParameters(page)));
        }
        /// <summary>
        /// Get the list of upcoming movies asynchronously. This list refreshes every day. The maximum number of items this list will include is 100.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetUpcomingMoviesAsync(int? page = null, Action<MovieSearch> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/upcoming", MovieListParameters(page)), onCompleted, onError);
        }


        /// <summary>
        /// Get the list of movies playing in theatres. This list refreshes every day. The maximum number of items this list will include is 100.
        /// </summary>
        /// <returns></returns>
        public MovieSearch GetNowPlayingMovies(int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("movie/now_playing", MovieListParameters(page)));
        }
        /// <summary>
        /// Get the list of movies playing in theatres asynchronously. This list refreshes every day. The maximum number of items this list will include is 100.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetNowPlayingMoviesAsync(int? page = null, Action<MovieSearch> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/now_playing", MovieListParameters(page)), onCompleted, onError);
        }


        /// <summary>
        /// Get the list of popular movies on The Movie Database. This list refreshes every day.
        /// </summary>
        /// <returns></returns>
        public MovieSearch GetPopularMovies(int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("movie/popular", MovieListParameters(page)));
        }
        /// <summary>
        /// Get the list of popular movies on The Movie Database asynchronously. This list refreshes every day.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="onCompleted"></param>
        /// <param name="onError"></param>
        public void GetPopularMoviesAsync(int? page = null, Action<MovieSearch> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/popular", MovieListParameters(page)), onCompleted, onError);
        }


        /// <summary>
        /// Get the list of top rated movies. By default, this list will only include movies that have 10 or more votes. This list refreshes every day.
        /// </summary>
        /// <returns></returns>
        public MovieSearch GetTopRatedMovies(int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("movie/top_rated", MovieListParameters(page)));
        }
        public void GetTopRatedMoviesAsync(int? page = null, Action<MovieSearch> onCompleted = null, Action<Exception> onError = null)
        {
            Utils.HttpGetAsync(BuildUrl("movie/top_rated", MovieListParameters(page)), onCompleted, onError);
        }


        /// <summary>
        /// This method lets users rate a movie. A valid session id is required.
        /// </summary>
        /// <param name="value"></param>
        public void AddMovieRating(int id, double value)
        {
            Utils.HttpPost<Status>(BuildUrl("movie/{0}/rating", id, null, true), new { value = value });
        }
        #endregion

        #region Collections
        /// <summary>
        /// Get the basic collection information for a specific collection id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Collection GetCollection(int id)
        {
            return Utils.HttpGet<Collection>(BuildUrl("collection/{0}", id, LanguageParameter()));
        }
        /// <summary>
        /// Get all of the images for a particular collection by collection id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieImages GetCollectionImages(int id)
        {
            return Utils.HttpGet<MovieImages>(BuildUrl("collection/{0}/images", id, LanguageParameter()));
        }
        #endregion

        #region People
        /// <summary>
        /// Get the general person information for a specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetPerson(int id)
        {
            return Utils.HttpGet<Person>(BuildUrl("person/{0}", id));
        }
        /// <summary>
        /// Get the credits for a specific person id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonCredits GetPersonCredits(int id)
        {
            return Utils.HttpGet<PersonCredits>(BuildUrl("person/{0}/credits", id, LanguageParameter()));
        }
        /// <summary>
        /// Get the images for a specific person id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonImages GetPersonImages(int id)
        {
            return Utils.HttpGet<PersonImages>(BuildUrl("person/{0}/images", id));
        }
        /// <summary>
        /// Get the changes for a specific person id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Changes GetPersonChanges(int id)
        {
            return Utils.HttpGet<Changes>(BuildUrl("person/{0}/changes", id));
        }
        #endregion

        #region Companies
        /// <summary>
        /// This method is used to retrieve all of the basic information about a company.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company GetCompany(int id)
        {
            return Utils.HttpGet<Company>(BuildUrl("company/{0}", id));
        }
        /// <summary>
        /// Get the list of movies associated with a particular company.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieSearch GetCompanyMovies(int id, int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("company/{0}/movies", id, MovieListParameters(page)));
        }
        #endregion

        #region Genres
        /// <summary>
        /// Get the list of genres.
        /// </summary>
        /// <returns></returns>
        public GenreList GetGenresList()
        {
            return Utils.HttpGet<GenreList>(BuildUrl("genre/list", LanguageParameter()));
        }
        /// <summary>
        /// Get the list of movies for a particular genre by id. Only movies with 10 or more votes are included.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieSearch GetMoviesByGenre(int id, int? page = null)
        {
            return Utils.HttpGet<MovieSearch>(BuildUrl("genre/{0}/movies", id, MovieListParameters(page)));
        }
        #endregion

        #region Search
        /// <summary>
        /// Search for movies by title.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public MovieSearch SearchMovies(string query, int? page = null, bool? include_adult = null, int? year = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new Exception("Invalid search string");
            
            return Utils.HttpGet<MovieSearch>(BuildUrl("search/movie", SearchMoviesParameters(query, page, include_adult, year)));
        }
        /// <summary>
        /// Search for people by name.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PersonSearch SearchPerson(string query, int? page = null, bool? include_adult = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new Exception("Invalid search string");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("query", query);
            if (page.HasValue)
                parameters.Add("page", page.Value.ToString());
            if (include_adult.HasValue)
                parameters.Add("include_adult", include_adult.Value ? "true" : "false");

            return Utils.HttpGet<PersonSearch>(BuildUrl("search/person", parameters));
        }
        /// <summary>
        /// Search for companies by name.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public CompanySearch SearchCompany(string query, int? page = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new Exception("Invalid search string");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("query", query);
            if (page.HasValue)
                parameters.Add("page", page.Value.ToString());

            return Utils.HttpGet<CompanySearch>(BuildUrl("search/company", parameters));
        }
        #endregion

        #region Changes
        /// <summary>
        /// Get a list of movie ids that have been edited.
        /// </summary>
        /// <returns></returns>
        public ChangeList GetChangedMovies(int page = 1, DateTime? start_date = null, DateTime? end_date = null)
        {
            return GetChangedList("movie/changes", page, start_date, end_date);
        }
        /// <summary>
        /// Get a list of people ids that have been edited. 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <returns></returns>
        public ChangeList GetChangedPeople(int page = 1, DateTime? start_date = null, DateTime? end_date = null)
        {
            return GetChangedList("person/changes", page, start_date, end_date);
        }
        private ChangeList GetChangedList(string operation, int page = 1, DateTime? start_date = null, DateTime? end_date = null)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("page", page.ToString());

            if (start_date.HasValue)
                parameters.Add("start_date",start_date.Value.ToString("yyyy-MM-dd"));

            if (end_date.HasValue)
                parameters.Add("end_date", end_date.Value.ToString("yyyy-MM-dd"));

            return Utils.HttpGet<ChangeList>(BuildUrl(operation, parameters));
        }
        #endregion

        private string BuildUrl(string base_method, int? param_id = null, NameValueCollection additional_parameters = null, bool sessionRequired = false)
        {
            
            if (param_id.HasValue)
                base_method = string.Format(base_method, param_id);

            string uri = string.Format(_baseurl, base_method, _apikey);
            if (additional_parameters != null)
                uri += ToQueryString((NameValueCollection)additional_parameters);

            if (sessionRequired)
            {
                if (string.IsNullOrEmpty(_sessionID))
                    throw new Exception("Session ID not set.");

                uri += string.Format("&session_id={0}", _sessionID);
            }

            return uri;

        }

        private string BuildUrl(string base_method, NameValueCollection additional_parameters)
        {
            return BuildUrl(base_method, null, additional_parameters);
        }
        
        private string ToQueryString(NameValueCollection values)
        {
            return "&" + string.Join("&", Array.ConvertAll(values.AllKeys, key => string.Format("{0}={1}", key, values[key])));
        }

        private NameValueCollection MovieListParameters(int? page = null)
        {
            NameValueCollection parameters = new NameValueCollection();
            if (page.HasValue)
                parameters.Add("page", page.Value.ToString());
            if (_language.Length > 0)
                parameters.Add("language", _language);

            return parameters;
        }
        private NameValueCollection LanguageParameter()
        {
            NameValueCollection parameters = new NameValueCollection();
            if (_language.Length > 0)
                parameters.Add("language", _language);

            return parameters;
        }
        private NameValueCollection SearchMoviesParameters(string query, int? page = null, bool? include_adult = null, int? year = null)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("query", query);
            if (page.HasValue)
                parameters.Add("page", page.Value.ToString());
            if (_language.Length > 0)
                parameters.Add("language", _language);
            if (include_adult.HasValue)
                parameters.Add("include_adult", include_adult.Value ? "true" : "false");
            if (year.HasValue)
                parameters.Add("year", year.Value.ToString());

            return parameters;
        }

    }
}
