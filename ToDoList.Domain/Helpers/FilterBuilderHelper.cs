using System.Linq.Expressions;
using ToDoList.Domain.Objects;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Helpers
{
    public class FilterBuilderHelper
    {
        public static Expression<Func<ToDoListItem,bool>>? BuildCondition(Filter filter)
        {


            if (filter?.FiltersList?.Count == 0)
                return null;
            var predicate = PredicateBuilder.True<ToDoListItem>();

            foreach (var item in filter.FiltersList)
            {
                if (item.Key.ToLower() == "title")
                    predicate = predicate.And(listItem => listItem.ItemTitle.Contains(item.Value));
                else if(item.Key.ToLower() == "description")
                    predicate = predicate.And(listItem => listItem.ItemDescription.Contains(item.Value));
                else if(item.Key.ToLower() == "completionDate")
                    predicate = predicate.And(listItem => listItem.CompletionDate <= Convert.ToDateTime(item.Value));
            }
            return predicate;
        }

        public static Predicate<T> And<T>(params Predicate<T>[] predicates)
        {
            return delegate (T item)
            {
                foreach (Predicate<T> predicate in predicates)
                {
                    if (!predicate(item))
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
