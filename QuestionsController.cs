using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverFlowProject.CustomFilters;
using StackOverFlowProject.ServiceLayer;
using StackOverFlowProject.ViewModels;
namespace StackOverFlowProject.Controllers
{
    public class QuestionsController : Controller
    {
        IQuestionsService qs;
        IAnswersService asw;
        ICategoriesService cs;

        public QuestionsController(IQuestionsService qs, IAnswersService asw, ICategoriesService cs)
        {
            this.qs = qs;
            this.asw = asw;
            this.cs = cs;
        }

        public ActionResult View(int id)
        {
            this.qs.UpdateQuestionViewsCount(id, 1);
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            QuestionViewModel qvm = this.qs.GetQuestionByQuestionID(id,uid);
            return View(qvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttribute]
        public ActionResult AddAnswer(NewAnswerViewModel navm)
        {
          
            navm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
            navm.AnswerDateAndTime = DateTime.Now;
            navm.VotesCount = 0;
            if( ModelState.IsValid )
            {
                this.asw.InsertAnswer(navm);
                return RedirectToAction("View","Questions", new { id = navm.QuestionID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                QuestionViewModel qvm = this.qs.GetQuestionByQuestionID(navm.QuestionID,navm.UserID);
                return View("View",qvm);
            }
        }

        [HttpPost]
        public ActionResult EditAnswer(EditAnswerViewModel avm)
        {
            if (ModelState.IsValid)
            {
                avm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.asw.UpdateAnswer(avm);
                return RedirectToAction("View", new {id = avm.QuestionID});
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return RedirectToAction("View", new { id = avm.QuestionID });
            }
        }

        public ActionResult Create()
        {
            List<LanguageViewModel> Languages = this.cs.GetLanguages();
            ViewBag.Languages = Languages;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Create(NewQuestionViewModel qvm)
        {
            if(ModelState.IsValid)
            {
                qvm.AnswersCount= 0;
                qvm.ViewsCount= 0;
                qvm.VotesCount= 0;
                qvm.QuestionDateAndTime= DateTime.Now;
                qvm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.qs.InsertQuestion(qvm);
                return RedirectToAction("Questions", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
    }
}