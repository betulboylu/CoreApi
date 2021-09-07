using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Dto
{
    public class OrderDto: BaseDto<int>
    {
        /// <summary>
        /// Customer Id of the Order
        /// </summary>
        [Display(Name="CustomerId", ResourceType = typeof(ViewStrings))]
        public int Customer { get; set; }

        /// <summary>
        /// Product Id 
        /// </summary>
        [Display(Name ="ProductId", ResourceType = typeof(ViewStrings))]
        public int Product { get; set; }

        /// <summary>
        /// Amount of the product bought
        /// </summary>
        [Display(Name ="ProductAmount", ResourceType =typeof(ViewStrings))]
        public int Amount { get; set; }
    }
}
