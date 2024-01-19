using Home_Service.Migrations;
using Home_Service.Models;
using System.Collections.Generic;

namespace Home_Service.ServiceLayer
{
    public interface IStripeService
    {
        void BookService(int serviceId, string userId);
    }
}
