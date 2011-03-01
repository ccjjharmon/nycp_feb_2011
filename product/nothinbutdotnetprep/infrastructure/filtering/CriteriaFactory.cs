﻿namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values);
        Criteria<ItemToFilter> not_equal_to(PropertyType value);
    }
}