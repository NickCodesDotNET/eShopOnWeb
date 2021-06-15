using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public sealed class BasketWithItemsSpecification : Specification<Basket>
    {
        public BasketWithItemsSpecification(int basketId) 
        {
            // BasketWithItemsSpecification uses Specification<T>  as base type and using it exposes a Query which is using a "BUILDER" design pattern which is useful for building up arbitrary sets of properties, constraints as opposed to the "FACTORY" paatern where we have to know everything upfront and pass it all in one method call. 

            // "BUILDER" works here becauase we want to build a query that includes not just filters like "where clauses" but also might have "includes", "ordering", "paging"... 

            Query
                .Where(b => b.Id == basketId)
                .Include(b => b.Items); // include will tell ET to "eager" load and if you do not use include and do not have lazy loading turned on you will get a null list becuase it does not inlcude related children. Ardalis does not recommend turning on lazy loading because this is a web application and we wnat every request to return in as little  amount of time of as possible. 
        }

        public BasketWithItemsSpecification(string buyerId)
        {
            Query
                .Where(b => b.BuyerId == buyerId)
                .Include(b => b.Items);
        }
    }
}
