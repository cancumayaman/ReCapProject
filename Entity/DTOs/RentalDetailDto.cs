using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }

        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
