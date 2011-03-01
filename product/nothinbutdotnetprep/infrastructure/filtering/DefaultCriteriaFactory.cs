using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> execute(Condition<ItemToFilter> condition)
        {
            return new ConditionalCriteria<ItemToFilter>(condition);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to_any(value).not();
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values)
        {
            return execute(x =>
                        new List<PropertyType>(possible_values).Contains(
                            property_accessor(x)));
            //return new ConditionalCriteria<ItemToFilter>(x =>
            //                                                 new List<PropertyType>(possible_values).Contains(
            //                                                     property_accessor(x)));
        }
    }
}