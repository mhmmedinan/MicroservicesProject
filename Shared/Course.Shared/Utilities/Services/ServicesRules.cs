using System;
using System.Collections.Generic;
using System.Text;
using Course.Core.Utilities.Results;

namespace Course.Core.Utilities.Services
{
    public class ServicesRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
