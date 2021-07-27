using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantureWork.Common.Constant
{
    public class SystemConstants
    {
        public const string ConnectionStringName = "eShopSolutionDb";
        public static string ConnectionString = string.Empty;

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }
    }
}