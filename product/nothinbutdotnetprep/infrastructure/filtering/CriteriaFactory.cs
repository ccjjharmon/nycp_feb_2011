using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values)
        {
            return new ConditionalCriteria<ItemToFilter>(x =>
                                                             new List<PropertyType>(possible_values).Contains(
                                                                 property_accessor(x)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to_any(value).not();
        }
    }
}