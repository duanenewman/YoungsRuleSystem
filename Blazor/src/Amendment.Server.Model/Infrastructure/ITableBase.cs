using System;
using System.Collections.Generic;
using System.Text;

namespace Amendment.Server.Model.Infrastructure
{
    public interface ITableBase : IReadOnlyTable
    {
        int EnteredBy { get; set; }
        DateTime EnteredDate { get; set; }
        int LastUpdatedBy { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
