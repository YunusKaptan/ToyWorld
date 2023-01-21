using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ToyWorldContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrdersDetails()
        {
            using (ToyWorldContext context = new ToyWorldContext())
            {
                var result = from p in context.Products
                    join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                    join or in context.Orders
                        on p.ProductId equals or.ProductId
                    from u in context.Users
                    join cu in context.Users
                        on u.Id equals cu.Id
                    select new OrderDetailDto()
                    {

                        ProductId = p.ProductId,
                        CategoryName = c.CategoryName,
                        OrderId = or.OrderId,
                        OrderDate = or.OrderDate,
                        UserName = u.FirstName,
                        UserLastname = u.LastName,
                        Email=cu.EMail
                    };
                return result.ToList();
            }
        }
    }
}
