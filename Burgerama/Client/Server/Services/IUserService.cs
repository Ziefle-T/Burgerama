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
        Server.Models.User[] GetAll();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/GetAll", ReplyAction = "http://tempuri.org/IUserService/GetAllResponse")]
        System.Threading.Tasks.Task<Server.Models.User[]> GetAllAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Add", ReplyAction = "http://tempuri.org/IUserService/AddResponse")]
        bool Add(Server.Models.User user);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Add", ReplyAction = "http://tempuri.org/IUserService/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(Server.Models.User user);

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
        bool UpdatePassword(int userId, string oldPassword, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdatePassword", ReplyAction = "http://tempuri.org/IUserService/UpdatePasswordResponse")]
        System.Threading.Tasks.Task<bool> UpdatePasswordAsync(int userId, string oldPassword, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateAdmin", ReplyAction = "http://tempuri.org/IUserService/UpdateAdminResponse")]
        bool UpdateAdmin(int userId, bool isAdmin);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/UpdateAdmin", ReplyAction = "http://tempuri.org/IUserService/UpdateAdminResponse")]
        System.Threading.Tasks.Task<bool> UpdateAdminAsync(int userId, bool isAdmin);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Delete", ReplyAction = "http://tempuri.org/IUserService/DeleteResponse")]
        bool Delete(int userId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Delete", ReplyAction = "http://tempuri.org/IUserService/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int userId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Login", ReplyAction = "http://tempuri.org/IUserService/LoginResponse")]
        (bool success, Server.Models.User user) Login(string userName, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IUserService/Login", ReplyAction = "http://tempuri.org/IUserService/LoginResponse")]
        System.Threading.Tasks.Task<(bool success, Server.Models.User user)> LoginAsync(string userName, string password);
    }
}