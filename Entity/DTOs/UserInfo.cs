using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
   public class UserInfo:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
