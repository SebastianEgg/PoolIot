//@GeneratedCode
namespace SnQPoolIot.AspMvc.Models.Business.Account
{
    using System;
    public partial class AppAccess
    {
        public System.String Guid
        {
            get => OneModel.Guid;
        }
        public System.String Name
        {
            get => OneModel.Name;
            set => OneModel.Name = value;
        }
        public System.String Email
        {
            get => OneModel.Email;
            set => OneModel.Email = value;
        }
        public System.String Password
        {
            get => OneModel.Password;
            set => OneModel.Password = value;
        }
        public System.Int32 TimeOutInMinutes
        {
            get => OneModel.TimeOutInMinutes;
            set => OneModel.TimeOutInMinutes = value;
        }
        public System.Boolean EnableJwtAuth
        {
            get => OneModel.EnableJwtAuth;
            set => OneModel.EnableJwtAuth = value;
        }
        public System.Int32 AccessFailedCount
        {
            get => OneModel.AccessFailedCount;
            set => OneModel.AccessFailedCount = value;
        }
        public SnQPoolIot.Contracts.Modules.Common.State State
        {
            get => OneModel.State;
            set => OneModel.State = value;
        }
    }
}
