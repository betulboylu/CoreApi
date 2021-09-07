using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order:Base
    {
        /// <summary>
        /// Customer Id of the Order
        /// </summary>
        public int Customer { get; set; }

        /// <summary>
        /// Product Id 
        /// </summary>
        public int Product { get; set; }

        /// <summary>
        /// Amount of the product bought
        /// </summary>
        public int Amount { get; set; }
    }
}
