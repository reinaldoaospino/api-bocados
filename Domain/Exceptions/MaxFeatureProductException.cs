using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class MaxFeatureProductException : ApplicationException
    {
        public MaxFeatureProductException()
            :base("There are more than 6 feature product")
        {}
    }
}
