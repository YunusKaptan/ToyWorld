using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class PurchaseManager:IPurchaseService
    {
        private IPurchaseDal _purchaseDal;


        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }

        public IDataResult<List<Purchase>> GetAll()
        {
            return new SuccessDataResult<List<Purchase>>(_purchaseDal.GetAll(), Messages.PurchaseListed);
        }

        public IDataResult<List<Purchase>> GetPurchaseById(int id)
        {
            return new SuccessDataResult<List<Purchase>>(_purchaseDal.GetAll(r => r.ProductId == id));
        }

        public IDataResult<List<PurchaseDetailDto>> GetPurchaseDetails()
        {
            return new SuccessDataResult<List<PurchaseDetailDto>>(_purchaseDal.GetPurchaseDetails());
        }

        public IResult Add(Purchase purchase)
        {
            _purchaseDal.Add(purchase);
            return new SuccessResult(Messages.PurchaseAdded);
        }

        public IResult Update(Purchase purchase)
        {
            _purchaseDal.Update(purchase);
            return new SuccessResult(Messages.PurchaseUpdated);
        }

        public IResult Delete(Purchase purchase)
        {
            _purchaseDal.Delete(purchase);
            return new SuccessResult(Messages.PurchaseDeleted);
        }

        public IResult IsProductAvailable(int productId)
        {
            var result = _purchaseDal.GetAll(r => r.ProductId == productId).Any();
            if (result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
