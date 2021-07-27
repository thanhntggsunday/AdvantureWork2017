namespace AdvantureWork.Model.Entities
{
    public partial class AppRole_Permission
    {
        public int ID { get; set; }
        public int Function_ActionID { get; set; }
        public string RoleID { get; set; }
        public virtual AppRole AppRoles { get; set; }
        public virtual AppFunction_Action Function_Action { get; set; }
    }
}