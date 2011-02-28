using System;
using System.Collections.Generic;

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
            return movies;
        }

        public void add(Movie movie)
        {
            if(!movies.Contains(movie))
                movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                List<Movie> lm = (List<Movie>)movies;
                lm.Sort(new SortMoviesByDescendingTitle());
                return lm;
        
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            List<Movie> lm = (List<Movie>) movies;
            return lm.FindAll(m => m.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            List<Movie> lm = (List<Movie>)movies;
            return lm.FindAll(m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
        
            get
            {
                
                List<Movie> lm =(List<Movie>) movies;
                lm.Sort(new SortMoviesByAscendingTitle());
                return lm;
                
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> lm = (List<Movie>)movies;
            lm.Sort(new SortMoviesByStudioAndYear());
            return lm;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            List<Movie> lm = (List<Movie>)movies;
            return lm.FindAll(m => m.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            List<Movie> lm = (List<Movie>)movies;
            return lm.FindAll(m => m.date_published.Year > year);

        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            List<Movie> lm = (List<Movie>)movies;
            return lm.FindAll(m => m.date_published.Year > startingYear && m.date_published.Year < endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            List<Movie> lm = (List<Movie>)movies;
            return lm.FindAll(m => m.genre==Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            List<Movie> lm = (List<Movie>)movies;
            return lm.FindAll(m => m.genre == Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> lm = (List<Movie>)movies;
             lm.Sort(new SortMoviesByDescendingPublishedDate());
            return lm;
        }

 

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> lm = (List<Movie>)movies;
            lm.Sort(new SortMoviesByAscendingPublishedDate());
            return lm;
        }

        private class SortMoviesByDescendingPublishedDate:IComparer<Movie>
        {

            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                return y.date_published.CompareTo(x.date_published);
            }

            #endregion
        }
                private class SortMoviesByAscendingPublishedDate:IComparer<Movie>
        {

            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                return x.date_published.CompareTo(y.date_published);
            }

            #endregion
        }
 
        private class SortMoviesByAscendingTitle:IComparer<Movie>
        {

            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                //return x.date_published.CompareTo(y.date_published);
                return x.title.CompareTo((y.title));
            }

            #endregion
        }

        private class SortMoviesByDescendingTitle : IComparer<Movie>
        {

            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {
                return y.title.CompareTo((x.title));
            }

            #endregion
        }

        //SortMoviesByStudioAndYear
        private class SortMoviesByStudioAndYear : IComparer<Movie>
        {

            #region IComparer<Movie> Members

            public int Compare(Movie x, Movie y)
            {

                return x.production_studio.CompareTo(y.production_studio) +
                       x.date_published.Year.CompareTo(y.date_published.Year);

            }

            #endregion
        }

    }


}