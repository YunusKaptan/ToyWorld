using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Purchase : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }


    }
}
