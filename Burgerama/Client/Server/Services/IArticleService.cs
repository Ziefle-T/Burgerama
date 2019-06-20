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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IArticleService")]
    public interface IArticleService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/GetAll", ReplyAction = "http://tempuri.org/IArticleService/GetAllResponse")]
        Article[] GetAll();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/GetAll", ReplyAction = "http://tempuri.org/IArticleService/GetAllResponse")]
        System.Threading.Tasks.Task<Article[]> GetAllAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/Add", ReplyAction = "http://tempuri.org/IArticleService/AddResponse")]
        bool Add(Article article);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/Add", ReplyAction = "http://tempuri.org/IArticleService/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(Article article);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/Delete", ReplyAction = "http://tempuri.org/IArticleService/DeleteResponse")]
        bool Delete(int articleId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/Delete", ReplyAction = "http://tempuri.org/IArticleService/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int articleId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateArticleNumber", ReplyAction = "http://tempuri.org/IArticleService/UpdateArticleNumberResponse")]
        bool UpdateArticleNumber(int articleId, string articleNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateArticleNumber", ReplyAction = "http://tempuri.org/IArticleService/UpdateArticleNumberResponse")]
        System.Threading.Tasks.Task<bool> UpdateArticleNumberAsync(int articleId, string articleNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateName", ReplyAction = "http://tempuri.org/IArticleService/UpdateNameResponse")]
        bool UpdateName(int articleId, string name);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateName", ReplyAction = "http://tempuri.org/IArticleService/UpdateNameResponse")]
        System.Threading.Tasks.Task<bool> UpdateNameAsync(int articleId, string name);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateDescription", ReplyAction = "http://tempuri.org/IArticleService/UpdateDescriptionResponse")]
        bool UpdateDescription(int articleId, string description);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateDescription", ReplyAction = "http://tempuri.org/IArticleService/UpdateDescriptionResponse")]
        System.Threading.Tasks.Task<bool> UpdateDescriptionAsync(int articleId, string description);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdatePrice", ReplyAction = "http://tempuri.org/IArticleService/UpdatePriceResponse")]
        bool UpdatePrice(int articleId, decimal price);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdatePrice", ReplyAction = "http://tempuri.org/IArticleService/UpdatePriceResponse")]
        System.Threading.Tasks.Task<bool> UpdatePriceAsync(int articleId, decimal price);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateArticle", ReplyAction = "http://tempuri.org/IArticleService/UpdateArticleResponse")]
        int UpdateArticle(int articleId, Article article);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IArticleService/UpdateArticle", ReplyAction = "http://tempuri.org/IArticleService/UpdateArticleResponse")]
        System.Threading.Tasks.Task<int> UpdateArticleAsync(int articleId, Article article);
    }
}
