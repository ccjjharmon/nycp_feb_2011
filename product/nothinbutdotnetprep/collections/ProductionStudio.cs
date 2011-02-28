using System;

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


        public int CompareTo(ProductionStudio other)
        {
            throw new NotImplementedException();
        }
    }
}