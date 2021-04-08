using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
   public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
       
    }
}
