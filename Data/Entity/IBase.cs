using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Entity interface
    /// </summary>
    public interface IBase
    {
        int Id { get; set; }

        DateTimeOffset CreatedDate { get; set; }

        DateTimeOffset? IsDeleted { get; set; }
    }
}
