using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ViewDemo
{
    public class Product
    {
        [DisplayName("編號")]
        public int Id { get; set; }

        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "產品名稱為必填項目")]
        public string Name { get; set; }

        [DisplayName("價格")]
        [Required(ErrorMessage = "產品價格為必填項目")]
        public decimal Price { get; set; }
    }
}