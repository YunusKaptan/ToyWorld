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
                    //join cus in context.Customers
                    //    on 
                    from u in context.Users
                    join cu in context.Customers
                        on u.Id equals cu.UserId
                    select new OrderDetailDto()
                    {

                        ProductId = p.ProductId,
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        OrderId = or.OrderId,
                        OrderDate = or.OrderDate,
                        CustomerName = u.FirstName,
                        CustomerLastname = u.LastName,
                        Email=cu.Email,
                        PostAddress = cu.PostAddress
                    };
                return result.ToList();
            }
        }
    }
}
