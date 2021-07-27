using AdvantureWork.Common.Helper;
using System;

namespace AdvantureWork.Common.Request
{
    public class RoleRequest : TransactionalInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}