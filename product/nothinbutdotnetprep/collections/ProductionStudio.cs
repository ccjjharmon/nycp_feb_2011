using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ProductionStudio : IComparable<ProductionStudio>
    {
        public static readonly ProductionStudio MGM = new ProductionStudio();
        public static readonly ProductionStudio Paramount = new ProductionStudio();
        public static readonly ProductionStudio Universal = new ProductionStudio();
        public static readonly ProductionStudio Pixar = new ProductionStudio();
        public static readonly ProductionStudio Disney = new ProductionStudio();
        public static readonly ProductionStudio Dreamworks = new ProductionStudio();

        #region IComparable<Movie> Members

        public int CompareTo(ProductionStudio other)
        {
            Dictionary<ProductionStudio,int> studioSortOrder = new Dictionary<ProductionStudio,int>();

            studioSortOrder[Disney] = 0;
            studioSortOrder[ Dreamworks] = 1;
            studioSortOrder[ MGM] = 2;
            studioSortOrder[ Paramount] = 3;
            studioSortOrder[ Pixar] = 4;
            studioSortOrder[ Universal] = 5;

            if (studioSortOrder[this] == studioSortOrder[other])
                return 0;

            if (studioSortOrder[this] < studioSortOrder[other])
                return -1;
            else
                return 1;
        #endregion
    }
}