using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrelec.SCO.Core.Helpers
{
    public static class POSItemExtensions
    {
        public static string GetShortCode(this string input)
        {
            return input.Substring(0, Math.Min(3, input.Length));
        }
    }
}
