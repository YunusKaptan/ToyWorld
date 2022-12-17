using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPurchaseService
    {
        IDataResult<List<Purchase>> GetAll();
        IDataResult<List<Purchase>> GetPurchaseById(int id);
        IDataResult<List<PurchaseDetailDto>> GetPurchaseDetails();
        IResult Add(Purchase purchase);
        IResult Update(Purchase purchase);
        IResult Delete(Purchase purchase);
        IResult IsProductAvailable(int productId);



    }
}
