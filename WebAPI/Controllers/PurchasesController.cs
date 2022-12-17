using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _purchaseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpurchasedetails")]
        public IActionResult GetPurchaseDetails()
        {
            var result = _purchaseService.GetPurchaseDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpurchasebyid")]
        public IActionResult GetPurchaseById(int id)
        {
            var result = _purchaseService.GetPurchaseById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Purchase purchase)
        {
            var result = _purchaseService.Add(purchase);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Purchase purchase)
        {
            var result = _purchaseService.Delete(purchase);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Purchase purchase)
        {
            var result = _purchaseService.Update(purchase);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("isproductavaible")]
        public IActionResult IsProductAvailable(int productId)
        {
            var result = _purchaseService.IsProductAvailable(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
