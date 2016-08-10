using CustomersMVC.Customers;
using CustomersMVC.CustomersAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomersMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomersAPIService _customersService;

        public HomeController(CustomersAPIService customersService)
        {
            _customersService = customersService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> CustomersList()
        {
            var customersList = await _customersService.GetCustomersListAsync();
            return View(customersList);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerEntity customer)
        {
            if (ModelState.IsValid)
            {
                await _customersService.AddCustomerAsync(customer);
                return RedirectToAction("CustomersList");
            }

            return View(customer);
        }

        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            await _customersService.DeleteCustomerAsync(customerId);

            return RedirectToAction("CustomersList");
        }
    }
}
