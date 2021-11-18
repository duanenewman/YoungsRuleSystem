using System;
using System.Collections.Generic;
using System.Text;

namespace Amendment.Server.Model.Infrastructure
{
    public interface IReadOnlyTable
    {
        int Id { get; set; }
    }
}
