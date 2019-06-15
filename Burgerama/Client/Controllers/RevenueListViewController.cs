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
    class RevenueListViewController : ActionAreaController<RevenueListViewModel>
    {
        private IOrderLinesService mOrderLinesService;

        public RevenueListViewController(IOrderLinesService orderLinesService) : base()
        {
            mOrderLinesService = orderLinesService;
        }

        public override RevenueListViewModel Initialize()
        {
            var retVal = base.Initialize();

            var list = mOrderLinesService.GetAll();

            var dict = new Dictionary<int, AreaBestseller>();

            foreach (var orderLine in list)
            {
                foreach (var area in orderLine.Order.Driver.Areas)
                {
                    if (!dict.ContainsKey(area.Id))
                    {
                        dict.Add(area.Id, new AreaBestseller()
                        {
                            Area = area,
                            Revenue = orderLine.Amount * orderLine.Article.Price
                        });
                        continue;
                    }

                    dict[area.Id].Revenue += orderLine.Amount * orderLine.Article.Price;
                }
            }

            var bestsellers =
                from areaBestseller in dict
                orderby areaBestseller.Value.Revenue
                select areaBestseller.Value;

            var topTen = bestsellers.Take(10);

            int i = 1;
            foreach (var areaBestseller in topTen)
            {
                areaBestseller.Rank = 1;
                i++;
            }

            retVal.AreaBestsellers = new ObservableCollection<AreaBestseller>(topTen);

            return retVal;
        }
    }
}
