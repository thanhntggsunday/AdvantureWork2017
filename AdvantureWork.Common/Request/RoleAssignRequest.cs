using AdvantureWork.ViewModels.Common;

using System;
using System.Collections.Generic;

namespace AdvantureWork.Common.Request
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}