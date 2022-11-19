using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ToyWorldContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (ToyWorldContext context = new ToyWorldContext())
            {
                var result = from p in context.Products
                    join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                    select new ProductDetailDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName,
                        UnitsInStock = p.UnitsInStock
                    };
                return result.ToList();
            }
        }
        public List<ProductDetailDto> GetProductDetailsByProductId(int productId)
        {
            using (ToyWorldContext context = new ToyWorldContext())
            {
                var result = from c in context.Products
                    join b in context.Categories
                        on c.CategoryId equals b.CategoryId
                    where c.ProductId == productId
                    select new ProductDetailDto()
                    {
                        ProductId = c.ProductId,
                        CategoryName = b.CategoryName
                    };
                return result.ToList();
            }
        }
    }
}
