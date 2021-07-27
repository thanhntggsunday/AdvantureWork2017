using System.Collections.Generic;

namespace AdvantureWork.Model.Entities
{
    public partial class AppAction
    {
        public AppAction()
        {
            Function_Action = new HashSet<AppFunction_Action>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AppFunction_Action> Function_Action { get; set; }
    }
}