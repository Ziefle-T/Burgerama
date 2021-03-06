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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ICustomerService")]
    public interface ICustomerService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/GetAll", ReplyAction = "http://tempuri.org/ICustomerService/GetAllResponse")]
        Server.Models.Customer[] GetAll();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/GetAll", ReplyAction = "http://tempuri.org/ICustomerService/GetAllResponse")]
        System.Threading.Tasks.Task<Server.Models.Customer[]> GetAllAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/Add", ReplyAction = "http://tempuri.org/ICustomerService/AddResponse")]
        bool Add(Server.Models.Customer customer);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/Add", ReplyAction = "http://tempuri.org/ICustomerService/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(Server.Models.Customer customer);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/Delete", ReplyAction = "http://tempuri.org/ICustomerService/DeleteResponse")]
        bool Delete(int customerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/Delete", ReplyAction = "http://tempuri.org/ICustomerService/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int customerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateCustomer", ReplyAction = "http://tempuri.org/ICustomerService/UpdateCustomerResponse")]
        int UpdateCustomer(Server.Models.Customer customer);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateCustomer", ReplyAction = "http://tempuri.org/ICustomerService/UpdateCustomerResponse")]
        System.Threading.Tasks.Task<int> UpdateCustomerAsync(Server.Models.Customer customer);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateFirstName", ReplyAction = "http://tempuri.org/ICustomerService/UpdateFirstNameResponse")]
        bool UpdateFirstName(int customerId, string firstName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateFirstName", ReplyAction = "http://tempuri.org/ICustomerService/UpdateFirstNameResponse")]
        System.Threading.Tasks.Task<bool> UpdateFirstNameAsync(int customerId, string firstName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateLastName", ReplyAction = "http://tempuri.org/ICustomerService/UpdateLastNameResponse")]
        bool UpdateLastName(int customerId, string lastName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateLastName", ReplyAction = "http://tempuri.org/ICustomerService/UpdateLastNameResponse")]
        System.Threading.Tasks.Task<bool> UpdateLastNameAsync(int customerId, string lastName);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdatePhone", ReplyAction = "http://tempuri.org/ICustomerService/UpdatePhoneResponse")]
        bool UpdatePhone(int customerId, string phone);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdatePhone", ReplyAction = "http://tempuri.org/ICustomerService/UpdatePhoneResponse")]
        System.Threading.Tasks.Task<bool> UpdatePhoneAsync(int customerId, string phone);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateStreet", ReplyAction = "http://tempuri.org/ICustomerService/UpdateStreetResponse")]
        bool UpdateStreet(int customerId, string street);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateStreet", ReplyAction = "http://tempuri.org/ICustomerService/UpdateStreetResponse")]
        System.Threading.Tasks.Task<bool> UpdateStreetAsync(int customerId, string street);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateStreetNumber", ReplyAction = "http://tempuri.org/ICustomerService/UpdateStreetNumberResponse")]
        bool UpdateStreetNumber(int customerId, string streetNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateStreetNumber", ReplyAction = "http://tempuri.org/ICustomerService/UpdateStreetNumberResponse")]
        System.Threading.Tasks.Task<bool> UpdateStreetNumberAsync(int customerId, string streetNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdatePlz", ReplyAction = "http://tempuri.org/ICustomerService/UpdatePlzResponse")]
        bool UpdatePlz(int customerId, int plz);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdatePlz", ReplyAction = "http://tempuri.org/ICustomerService/UpdatePlzResponse")]
        System.Threading.Tasks.Task<bool> UpdatePlzAsync(int customerId, int plz);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateCity", ReplyAction = "http://tempuri.org/ICustomerService/UpdateCityResponse")]
        bool UpdateCity(int customerId, string city);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICustomerService/UpdateCity", ReplyAction = "http://tempuri.org/ICustomerService/UpdateCityResponse")]
        System.Threading.Tasks.Task<bool> UpdateCityAsync(int customerId, string city);
    }
}
