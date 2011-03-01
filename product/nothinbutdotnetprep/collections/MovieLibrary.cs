using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> all_movies_matching(Condition<Movie> condition)
        {
            return movies.all_items_matching(new ConditionalCriteria<Movie>(condition));
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_matching(movie => movie.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_matching(m => m.date_published.Year > year);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_matching(m => m.genre == Genre.action);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_matching(m => m.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies_matching(m => m.date_published.Year > startingYear && m.date_published.Year < endingYear);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_matching(m => m.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_matching(
                m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var lm = (List<Movie>) movies;
                lm.Sort(new SortMoviesByDescendingTitle());
                return lm;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var lm = (List<Movie>) movies;
                lm.Sort(new SortMoviesByAscendingTitle());
                return lm;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var lm = (List<Movie>) movies;
            lm.Sort((x,y) => 0);
            return lm;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var lm = (List<Movie>) movies;
            lm.Sort(new SortMoviesByDescendingPublishedDate());
            return lm;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var lm = (List<Movie>) movies;
            lm.Sort(new SortMoviesByAscendingPublishedDate());
            return lm;
        }

        class SortMoviesByDescendingPublishedDate : IComparer<Movie>
        {
            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                return y.date_published.CompareTo(x.date_published);
            }

            #endregion
        }

        class SortMoviesByAscendingPublishedDate : IComparer<Movie>
        {
            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                return x.date_published.CompareTo(y.date_published);
            }

            #endregion
        }

        class SortMoviesByAscendingTitle : IComparer<Movie>
        {
            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                //return x.date_published.CompareTo(y.date_published);
                return x.title.CompareTo((y.title));
            }

            #endregion
        }

        class SortMoviesByDescendingTitle : IComparer<Movie>
        {
            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                return y.title.CompareTo((x.title));
            }

            #endregion
        }

        //SortMoviesByStudioAndYear
    }
}