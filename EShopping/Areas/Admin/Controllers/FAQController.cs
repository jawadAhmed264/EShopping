using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.FAQService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShopping.Areas.Admin.Controllers
{
    public class FAQController : Controller
    {
        private IFAQService _FAQService;
        public FAQController(IFAQService FAQService)
        {
            _FAQService = FAQService;
        }

        public ActionResult Index()
        {
            var model = _FAQService.AllFAQ().
                Select(f => new FAQViewModel{
                    FAQ_Id = f.FAQ_Id,
                    Question = f.Question,
                    Answer = f.Answer
            });
            return View(model);
        }

    }
}