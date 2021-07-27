using System.Collections.Generic;

namespace AdvantureWork.Model.Entities
{
    public partial class AppFunction
    {
        public AppFunction()
        {
            Function_Action = new HashSet<AppFunction_Action>();
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }
        public int DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public bool Status { get; set; }
        public string IconCss { get; set; }

        public virtual ICollection<AppFunction_Action> Function_Action { get; set; }
    }
}