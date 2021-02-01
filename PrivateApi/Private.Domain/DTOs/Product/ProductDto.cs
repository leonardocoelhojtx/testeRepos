using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Product
{
    public class ProductDto
    {
        public Int64 Id { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }
        public string NCM { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
        public string EAN { get; set; }
    }
}
