using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static DefaultCriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType>
                property_accessor) 
        {
            return new DefaultCriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }

        public static ComparableCriteriaFactory<ItemToFilter,PropertyType> has_an<PropertyType>(PropertyAccessor<ItemToFilter, PropertyType> accessor) 
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(accessor,
                has_a(accessor));
        }
    }
}