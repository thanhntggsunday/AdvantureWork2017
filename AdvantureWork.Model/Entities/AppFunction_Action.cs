using System.Collections.Generic;

namespace AdvantureWork.Model.Entities
{
    public partial class AppFunction_Action
    {
        public AppFunction_Action()
        {
            Role_Permission = new HashSet<AppRole_Permission>();
        }

        public int ID { get; set; }
        public string ActionId { get; set; }
        public string FunctionId { get; set; }

        public virtual AppAction Action { get; set; }

        public virtual AppFunction Functions { get; set; }

        public virtual ICollection<AppRole_Permission> Role_Permission { get; set; }
    }
}