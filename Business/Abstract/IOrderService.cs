﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    { 
        IDataResult<List<Order>> GetAll();
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);
        IDataResult<Order> GetById(int orderId);
        IDataResult<List<OrderDetailDto>> GetOrdersDetails();


    }
}
