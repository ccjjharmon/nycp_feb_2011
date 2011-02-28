namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class CriteriaExtensions
    {
        public static Criteria<ItemToMatch> not<ItemToMatch>(this Criteria<ItemToMatch> to_negate)
        {
            return new NotCriteria<ItemToMatch>(to_negate);
        }

        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left, Criteria<ItemToMatch> right)
        {
            return new OrCriteria<ItemToMatch>(left, right);
        }
    }
}