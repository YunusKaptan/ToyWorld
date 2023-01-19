using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PurchaseDetailDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string CategoryName { get; set; }
        public string Email { get; set; }
        public string PostAddress { get; set; }

        public string LastName { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
