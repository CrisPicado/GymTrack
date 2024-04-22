using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Policy
{
    public class PolicyPermission
    {

        public PolicyPermission()
        {
        }

        public PolicyPermission(string controller, string action)
            :this()
        {
            Controller = controller;
            Action = action;
        }


        [Key]
        public int Id { get; private set; }

        public string Controller { get; private set; }

        public string Action { get; private set; }
    }
}
