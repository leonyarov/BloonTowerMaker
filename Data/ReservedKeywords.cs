using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace BloonTowerMaker.Data
{
    public static class ReservedKeywords
    {
        static CSharpCodeProvider cs = new CSharpCodeProvider();

        public static bool IsValidKeyword(this string keyword)
        {
            return cs.IsValidIdentifier(keyword);
        }

    }
}
