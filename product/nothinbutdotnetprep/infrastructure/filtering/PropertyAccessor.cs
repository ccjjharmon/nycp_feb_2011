namespace nothinbutdotnetprep.infrastructure.filtering
{
    public delegate ReturnType PropertyAccessor<Item,
                                                ReturnType>(Item item);
}