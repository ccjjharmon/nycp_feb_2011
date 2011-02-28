using System;

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
            return new ConditionalCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values)
        {
            Criteria<ItemToFilter> criteria = null;
            for (int i = 0; i < possible_values.Length; i++)
            {
                if (i == 0)
                {
                    criteria = equal_to(possible_values[i]);
                }
                else
                {
                    criteria = criteria.or<ItemToFilter>(equal_to(possible_values[i]));
                }
            }
            return criteria;
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }
    }
}