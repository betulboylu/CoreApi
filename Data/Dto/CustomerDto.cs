using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Dto
{
    public class CustomerDto : BaseDto<int>
    {
        /// <summary>
        /// Customer Name and Surname
        /// </summary>
        [Display(Name="CustomerName", ResourceType =typeof(ViewStrings))]
        public string Name { get; set; }

        /// <summary>
        /// Customer Phone Number
        /// </summary>
        [Display(Name="PhoneNumber", ResourceType = typeof(ViewStrings))]
        public string Phone { get; set; }

        /// <summary>
        /// Customer Email
        /// </summary>
        [Display(Name="CustomerEmail", ResourceType = typeof(ViewStrings))]
        public string Email { get; set; }
    }
}
