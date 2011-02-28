using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToFilter,PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return new ConditionalCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values)
        {
            throw new NotImplementedException();
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            throw new NotImplementedException();
        }
    }
}