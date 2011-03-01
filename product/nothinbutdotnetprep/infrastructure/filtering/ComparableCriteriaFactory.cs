using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType>  : CriteriaFactory<ItemToFilter,PropertyType>
        where PropertyType
                                                                           : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return original.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values)
        {
            return original.equal_to_any(possible_values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return original.not_equal_to(value);
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new ConditionalCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType start,
                                              PropertyType end)
        {
            return new ConditionalCriteria<ItemToFilter>(
                x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }
    }
}