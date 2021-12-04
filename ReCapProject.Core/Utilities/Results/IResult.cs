using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Results
{
    public interface IResult
    {
        bool Succes { get; }
        string Message { get; }
    }
}
