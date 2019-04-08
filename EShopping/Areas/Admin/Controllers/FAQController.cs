using EShopping.Areas.Admin.Models;
using EShopping.Data.Models;
using EShopping.Service.FAQService;
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FAQViewModel model)
        {
            if (ModelState.IsValid)
            {
                FAQ faq = new FAQ();
                faq.Question= model.Question;
                faq.Answer = model.Answer;
                bool res = await _FAQService.AddFAQ(faq);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var faq = _FAQService.GetFAQById(Id);

            var faqVM= new FAQViewModel()
            {
                FAQ_Id= faq.FAQ_Id,
                Question = faq.Question,
                Answer = faq.Answer,
            };
            return View(faqVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(FAQViewModel model)
        {
            if (ModelState.IsValid)
            {
                FAQ faq= _FAQService.GetFAQById(model.FAQ_Id);
                faq.Question= model.Question;
                faq.Answer= model.Answer;
                bool res = await _FAQService.UpdateFAQ(faq);
                if (res)
                {
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var faq = _FAQService.GetFAQById(Id);
            FAQViewModel faqVM = new FAQViewModel()
            {
                FAQ_Id = faq.FAQ_Id, 
                Question = faq.Question
            };
            return View(faqVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(FAQViewModel model)
        {
            var category = _FAQService.GetFAQById(model.FAQ_Id);
            var res = await _FAQService.Remove(category);
            return RedirectToAction("Index");

        }

    }
}