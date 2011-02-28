namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface Criteria<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}