using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
        public string Email { get; set; }
        public string PostAddress { get; set; }

        public string UserLastname { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
