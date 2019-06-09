﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using Client.Server.Models;

namespace Client.Server.Services
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IUserService")]
    public interface IUserService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/GetAll", ReplyAction = "http://tempuri.org/IUserService/GetAllResponse")]
        User[] GetAll();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/GetAll", ReplyAction = "http://tempuri.org/IUserService/GetAllResponse")]
        System.Threading.Tasks.Task<User[]> GetAllAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Add", ReplyAction = "http://tempuri.org/IUserService/AddResponse")]
        bool Add(User user);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Add", ReplyAction = "http://tempuri.org/IUserService/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(User user);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateUsername", ReplyAction = "http://tempuri.org/IUserService/UpdateUsernameResponse")]
        bool UpdateUsername(int userId, string username);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateUsername", ReplyAction = "http://tempuri.org/IUserService/UpdateUsernameResponse")]
        System.Threading.Tasks.Task<bool> UpdateUsernameAsync(int userId, string username);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateFirstname", ReplyAction = "http://tempuri.org/IUserService/UpdateFirstnameResponse")]
        bool UpdateFirstname(int userId, string firstname);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateFirstname", ReplyAction = "http://tempuri.org/IUserService/UpdateFirstnameResponse")]
        System.Threading.Tasks.Task<bool> UpdateFirstnameAsync(int userId, string firstname);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateLastname", ReplyAction = "http://tempuri.org/IUserService/UpdateLastnameResponse")]
        bool UpdateLastname(int userId, string lastname);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateLastname", ReplyAction = "http://tempuri.org/IUserService/UpdateLastnameResponse")]
        System.Threading.Tasks.Task<bool> UpdateLastnameAsync(int userId, string lastname);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdatePassword", ReplyAction = "http://tempuri.org/IUserService/UpdatePasswordResponse")]
        bool UpdatePassword(int userId, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdatePassword", ReplyAction = "http://tempuri.org/IUserService/UpdatePasswordResponse")]
        System.Threading.Tasks.Task<bool> UpdatePasswordAsync(int userId, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateAdmin", ReplyAction = "http://tempuri.org/IUserService/UpdateAdminResponse")]
        bool UpdateAdmin(int userId, bool isAdmin);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateAdmin", ReplyAction = "http://tempuri.org/IUserService/UpdateAdminResponse")]
        System.Threading.Tasks.Task<bool> UpdateAdminAsync(int userId, bool isAdmin);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Delete", ReplyAction = "http://tempuri.org/IUserService/DeleteResponse")]
        bool Delete(int userId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Delete", ReplyAction = "http://tempuri.org/IUserService/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int userId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Login", ReplyAction = "http://tempuri.org/IUserService/LoginResponse")]
        System.ValueTuple<bool, bool> Login(string userName, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Login", ReplyAction = "http://tempuri.org/IUserService/LoginResponse")]
        System.Threading.Tasks.Task<System.ValueTuple<bool, bool>> LoginAsync(string userName, string password);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : IUserService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<IUserService>, IUserService
    {

        public UserServiceClient()
        {
        }

        public UserServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public UserServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public User[] GetAll()
        {
            return base.Channel.GetAll();
        }

        public System.Threading.Tasks.Task<User[]> GetAllAsync()
        {
            return base.Channel.GetAllAsync();
        }

        public bool Add(User user)
        {
            return base.Channel.Add(user);
        }

        public System.Threading.Tasks.Task<bool> AddAsync(User user)
        {
            return base.Channel.AddAsync(user);
        }

        public bool UpdateUsername(int userId, string username)
        {
            return base.Channel.UpdateUsername(userId, username);
        }

        public System.Threading.Tasks.Task<bool> UpdateUsernameAsync(int userId, string username)
        {
            return base.Channel.UpdateUsernameAsync(userId, username);
        }

        public bool UpdateFirstname(int userId, string firstname)
        {
            return base.Channel.UpdateFirstname(userId, firstname);
        }

        public System.Threading.Tasks.Task<bool> UpdateFirstnameAsync(int userId, string firstname)
        {
            return base.Channel.UpdateFirstnameAsync(userId, firstname);
        }

        public bool UpdateLastname(int userId, string lastname)
        {
            return base.Channel.UpdateLastname(userId, lastname);
        }

        public System.Threading.Tasks.Task<bool> UpdateLastnameAsync(int userId, string lastname)
        {
            return base.Channel.UpdateLastnameAsync(userId, lastname);
        }

        public bool UpdatePassword(int userId, string password)
        {
            return base.Channel.UpdatePassword(userId, password);
        }

        public System.Threading.Tasks.Task<bool> UpdatePasswordAsync(int userId, string password)
        {
            return base.Channel.UpdatePasswordAsync(userId, password);
        }

        public bool UpdateAdmin(int userId, bool isAdmin)
        {
            return base.Channel.UpdateAdmin(userId, isAdmin);
        }

        public System.Threading.Tasks.Task<bool> UpdateAdminAsync(int userId, bool isAdmin)
        {
            return base.Channel.UpdateAdminAsync(userId, isAdmin);
        }

        public bool Delete(int userId)
        {
            return base.Channel.Delete(userId);
        }

        public System.Threading.Tasks.Task<bool> DeleteAsync(int userId)
        {
            return base.Channel.DeleteAsync(userId);
        }

        public System.ValueTuple<bool, bool> Login(string userName, string password)
        {
            return base.Channel.Login(userName, password);
        }

        public System.Threading.Tasks.Task<System.ValueTuple<bool, bool>> LoginAsync(string userName, string password)
        {
            return base.Channel.LoginAsync(userName, password);
        }
    }
}
