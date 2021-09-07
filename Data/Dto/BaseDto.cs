using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class BaseDto<TKey>
    {
        /// <summary>
        /// Id
        /// </summary>
        public IKey Id { get; set; }

        /// <summary>
        /// Created Date of each entity
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Deleted date of each entity
        /// </summary>
        public DateTimeOffset? IsDeleted { get; set; }
    }
}
