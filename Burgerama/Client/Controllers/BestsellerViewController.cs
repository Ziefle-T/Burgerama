using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Server.Services;
using Client.ViewModels;

namespace Client.Controllers
{
    class BestsellerViewController : ActionAreaController<BestsellerViewModel>
    {
        private IOrderLinesService mOrderLinesService;

        public BestsellerViewController(IOrderLinesService orderLinesService) : base()
        {
            mOrderLinesService = orderLinesService;
        }

        public override BestsellerViewModel Initialize()
        {
            var retVal = base.Initialize();

            var orderLines = mOrderLinesService.GetAll();

            var dict = new Dictionary<int, Bestseller>();

            foreach (var orderLine in orderLines)
            {
                if (dict.ContainsKey(orderLine.Article.Id))
                {
                    var article = dict[orderLine.Article.Id];
                    article.Amount += orderLine.Amount;
                    continue;
                }

                dict.Add(orderLine.Article.Id, new Bestseller()
                {
                    Amount = orderLine.Amount,
                    Article = orderLine.Article
                });
            }

            var bestsellers =
                from seller in dict
                orderby seller.Value.Revenue descending
                select seller.Value;

            var bestsellerList = bestsellers.Take(10).ToList();

            int i = 1;
            foreach (var bestseller in bestsellerList)
            {
                bestseller.Rank = i;
                i++;
            }

            retVal.Bestsellers = new ObservableCollection<Bestseller>(bestsellerList);

            return retVal;
        }
    }
}
