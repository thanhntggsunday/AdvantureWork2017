using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantureWork.Common.Request
{
    public class CountryListRequest
    {
        public int PageNo { get; set; }
        public string CountryName { get; set; }

    }
}