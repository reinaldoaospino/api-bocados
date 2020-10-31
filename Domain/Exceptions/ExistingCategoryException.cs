using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ExistingCategoryException : ApplicationException
    {
        public ExistingCategoryException()
            : base("Existing category")
        { }
    }
}
