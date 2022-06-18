using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HealthCareProducts.Models
{
    public partial class HealthCareProduct
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        [DisplayName("Trademark Name")]
        public string? TrademarkName { get; set; }
        public string? Composition { get; set; }
        public string? Segment { get; set; }
        public string? Indication { get; set; }
        public string? Dosage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
