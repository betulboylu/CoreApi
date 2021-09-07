using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Dto
{
    public class ProductDto:BaseDto<int>
    {
        /// <summary>
        /// Product Name
        /// </summary>
        [Display(Name="ProductName",ResourceType = typeof(ViewStrings))]
        public string Name { get; set; }

        /// <summary>
        /// Product Details
        /// </summary>
        [Display(Name="Details",ResourceType =typeof(ViewStrings))]
        public string Details { get; set; }

        /// <summary>
        /// Product Photo Path
        /// </summary>
        [Display(Name="Photo",ResourceType =typeof(ViewStrings))]
        public string Photo { get; set; }

    }
}
