namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ConditionalCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        Condition<ItemToMatch> condition;

        public ConditionalCriteria(Condition<ItemToMatch> condition)
        {
            this.condition = condition;
        }

        public bool matches(ItemToMatch item)
        {
            return condition(item);
        }
    }
}