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
    public class EfPurchaseDal:EfEntityRepositoryBase<Purchase, ToyWorldContext>, IPurchaseDal
    {
        public List<PurchaseDetailDto> GetPurchaseDetails()
        {
            using (ToyWorldContext context = new ToyWorldContext())
            {
                var result = from p in context.Products
                    join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                    join or in context.Purchase
                        on p.ProductId equals or.ProductId
                    from u in context.Users
                    join cu in context.Customers
                        on u.Id equals cu.UserId
                    select new PurchaseDetailDto()
                    {

                        ProductId = p.ProductId,
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        Id = or.Id,
                        PurchaseDate = or.PurchaseDate,
                        CustomerName = u.FirstName,
                        CustomerLastname = u.LastName,
                        Email = cu.Email,
                        PostAddress = cu.PostAddress
                    };
                return result.ToList();
            }
        }
    }
}
