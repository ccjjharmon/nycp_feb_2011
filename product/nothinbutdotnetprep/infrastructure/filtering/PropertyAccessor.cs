namespace nothinbutdotnetprep.infrastructure.filtering
{
    public delegate ReturnTypeOfPropertyToPointAt PropertyAccessor<ItemWithProperty,
                                                                   ReturnTypeOfPropertyToPointAt>(ItemWithProperty item);
}