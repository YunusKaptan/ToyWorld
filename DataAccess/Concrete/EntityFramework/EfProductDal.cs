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
                        UnitsInStock = p.UnitsInStock,
                        ImagePath = (from m in context.ProductImages 
                            where m.ProductId==p.ProductId select m.ImagePath).FirstOrDefault()  
                    };
                return result.ToList();
            }
        }
        public List<ProductDetailDto> GetProductDetailsByProductId(int productId)
        {
            using (ToyWorldContext context = new ToyWorldContext())
            {
                var result = from p in context.Products
                    join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                             where p.ProductId == productId
                    select new ProductDetailDto()
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName,
                        UnitsInStock = p.UnitsInStock,
                        ImagePath = (from m in context.ProductImages
                            where m.ProductId == p.ProductId select m.ImagePath).FirstOrDefault()

                    };
                return result.ToList();
            }
        }
        public List<ProductDetailDto> GetProductDetailsByCategoryId(int categoryId)
        {
            using (ToyWorldContext context = new ToyWorldContext())
            {
                var result = from p in context.Products
                    join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                             where c.CategoryId == categoryId
                    select new ProductDetailDto()
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName,
                        UnitsInStock = p.UnitsInStock,
                        ImagePath = (from m in context.ProductImages
                            where m.ProductId == p.ProductId
                            select m.ImagePath).FirstOrDefault()

                    };
                return result.ToList();
            }
        }

    }
}
