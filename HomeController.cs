using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverFlowProject.DomainModel;
using StackOverFlowProject.ServiceLayer;
using StackOverFlowProject.ViewModels;

namespace StackOverFlowProject.Controllers
{
    public class HomeController : Controller
    {
        IQuestionsService qs;
        ICategoriesService cs;

        public HomeController(IQuestionsService qs,ICategoriesService cs)
        {
            this.qs = qs;
            this.cs = cs;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<QuestionViewModel> questions = this.qs.GetQuestions().Take(10).ToList();
            return View(questions);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Languages()
        {
            List<LanguageViewModel> Languages = this.cs.GetLanguages();
            return View(Languages);
        }

        
        public ActionResult Questions()
        {
            List<QuestionViewModel> questions = this.qs.GetQuestions();
            return View(questions);
        }

        public ActionResult Search(string str)
        {
            List<QuestionViewModel> questions = this.qs.GetQuestions().Where(temp => temp.QuestionName.ToLower().Contains(str.ToLower()) ||
            temp.Languages.LanguageName.ToLower().Contains(str.ToLower())).ToList();
            ViewBag.str = str;
            return View(questions);
        }

    }
}