using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static void has_a<PropertyType>(PropertyAccessor<ItemToFilter,PropertyType> 
            property_accessor)
        {
            throw new NotImplementedException();
        }
    }
}