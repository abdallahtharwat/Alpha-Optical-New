using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alpha.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
       
        public string Title { get; set; }
        [Required]
     
        public string Description { get; set; }
        [Required]
  
        public string Color { get; set; }
        [Required]
        
        public string ISBN { get; set; }
     

        [Required]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-5")]
        public double Price { get; set; }


        [Required]
        [Display(Name = "Price for 5+")]
        public double Price5 { get; set; }

        [Required]
        [Display(Name = "Price for 10+")]
        public double Price10 { get; set; }


        public int CategoryId { get; set; }  //( step 1 for forienKEY) -- STEP 2 in dbcontext class   -- step 3 in product controller -- step 4 in upsert view -- create viewmodel
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category  { get; set; }


        [ValidateNever]
     public List<ProductImage> productImages { get; set; }

        public int BrandId { get; set; }  //( step 1 for forienKEY) -- STEP 2 in dbcontext class   -- step 3 in product controller -- step 4 in upsert view  -- create viewmodel
        [ForeignKey("BrandId")]
        [ValidateNever]
        public Brand  Brand { get; set; }

        public int LenstypeId { get; set; }  //( step 1 for forienKEY) -- STEP 2 in dbcontext class   -- step 3 in product controller -- step 4 in upsert view  -- create viewmodel
        [ForeignKey("LenstypeId")]
        [ValidateNever]
        public Lenstype  Lenstype { get; set; }


      






    }

}
