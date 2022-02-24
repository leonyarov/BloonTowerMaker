using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonTowerMaker.Data
{
    internal interface IExtractModel
    {
        Dictionary<string,string> extractModelAsDictionary ();
    }
}
