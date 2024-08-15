using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    
    public class ErrorController : Controller
    {
      
         [Route("Error/{statusCode}")]
         public IActionResult Error(int? statusCode)
         {

            if (statusCode.HasValue)
            {
                if (statusCode == 404)
                {
                    return RedirectToAction("Error404");
                }
                else
                {
                    return RedirectToAction("GenError",statusCode);
                }

            }
            else
            {
                //return View(new ErrorViewModel { StatusCode = statusCode, ShowRequestId = false });
                return RedirectToAction("GenError",0);
            }

        }

        [Route("/[Controller]/[Action]")]     //Doesnt find RedirectAction without this
        public IActionResult Error404()
         {
            return View();
         }


        [Route("/[Controller]/[Action]")]     //Doesnt find RedirectAction without this
        public IActionResult GenError(int status)
         {
               return View(status);

         }
    }
}
