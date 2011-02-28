using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{

    public class DatePublishedAscComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }
    public class DatePublishedDescComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return y.date_published.CompareTo(x.date_published);
        }
    }
    public class MovieStudioYrPublishedComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }
    public class TitleAscendingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }
    }
    public class TitleDescendingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return y.title.CompareTo(x.title);
        }
    }    
    public class DatePublishedComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }


    public class MovieLibrary
    {
        IList<Movie> movies;

        private IEnumerable<Movie> SortMoviesBy(IComparer<Movie> comparer)
        {
            List<Movie> results = (List<Movie>)movies;
            results.Sort(comparer);

            return results;
        }

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
            //untested
            if(!movies.Contains(movie))
            {
                foreach(Movie imovie in movies)
                {
                    if (imovie.title == movie.title && imovie.date_published.Equals(movie.date_published)) return;
                }
                //if couldn't be found, go ahead and add
                movies.Add(movie);
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {        
            get { return SortMoviesBy(new TitleDescendingComparer()); }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach(Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney) yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { return SortMoviesBy(new TitleAscendingComparer()); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            return SortMoviesBy(new MovieStudioYrPublishedComparer()); 
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year > year) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear) yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.kids ) yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.action ) yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            return SortMoviesBy(new DatePublishedDescComparer());
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            return SortMoviesBy(new DatePublishedAscComparer());
        }
    }
}