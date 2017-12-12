using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models.Extended
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {

    }
    public class ProductMetadata
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Provide Product Name ")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Price")]
        public float Price { get; set; }
    }
}