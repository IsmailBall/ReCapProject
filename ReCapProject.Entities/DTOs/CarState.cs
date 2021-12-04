using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities.DTOs
{
    public class CarState:IDto
    {
        public int Id { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
