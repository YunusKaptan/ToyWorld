using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int categoryId);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);

    }
}
