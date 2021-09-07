using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product:Base
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Details
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Product Photo Path
        /// </summary>
        public string Photo { get; set; }

       
    }
}
