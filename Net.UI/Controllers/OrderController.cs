using Microsoft.AspNetCore.Mvc;
using Net.UI.Data;
using Net.UI.Repository;

namespace Net.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly NetDbContext netDbContext;
        private readonly IOrderRepository orderRepository;

        public OrderController(NetDbContext netDbContext, IOrderRepository orderRepository)
        {
            this.netDbContext = netDbContext;
            this.orderRepository = orderRepository;
        }


        public IActionResult Index()
        {
            return View();
        }



        





    }
}
