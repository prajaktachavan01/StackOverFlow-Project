using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlowProject.DomainModel;

namespace StackOverFlowProject.Repositories
{
    public interface IAnswersRepository
    {
        void InsertAnswer(Answer a);
        void UpdateAnswer(Answer a);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<Answer> GetAnswersByQuestionID(int qid);
        List<Answer> GetAnswersByAnswerID(int AnswerID);

    }
    public class AnswersRepository : IAnswersRepository
    {
        StackOverFlowDatabaseDbContext db;
        IQuestionRepository qr;
        IVotesRepository vr;

        public AnswersRepository()
        {
            db = new StackOverFlowDatabaseDbContext();
            qr = new QuestionsRepository();
            vr = new VotesRepository();
        }

        public void InsertAnswer(Answer a)
        {
            db.Answer.Add(a);
            db.SaveChanges();
            qr.UpdateQuestionAnswersCount(a.QuestionID, 1);
        }

        public void UpdateAnswer(Answer a)
        {
            Answer ans = db.Answer.Where(temp => temp.AnswerID == a.AnswerID).FirstOrDefault();
            if (ans != null)
            {
                ans.AnswerText = a.AnswerText;
                db.SaveChanges();
            }
        }

        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            Answer ans = db.Answer.Where(temp => temp.AnswerID == aid).FirstOrDefault();
            if (ans != null)
            {
                ans.VotesCount = value;
                db.SaveChanges();
                qr.UpdateQuestionVotesCount(ans.QuestionID, value);
                vr.UpdateVote(aid, uid, value);
            }
        }

        public void DeleteAnswer(int aid)
        {
            Answer ans = db.Answer.Where(temp => temp.AnswerID == aid).FirstOrDefault();
            if (ans != null)
            {
                db.Answer.Remove(ans);
                db.SaveChanges();
                qr.UpdateQuestionAnswersCount(ans.QuestionID, -1);
            }
        }

        public List<Answer> GetAnswersByQuestionID(int qid)
        {
            List<Answer> ans = db.Answer.Where(temp => temp.QuestionID == qid).OrderByDescending(temp => temp.AnswerDateAndTime).ToList();
            return ans;
        }

        public List<Answer> GetAnswersByAnswerID(int aid)
        {
            List<Answer> ans = db.Answer.Where(temp => temp.AnswerID == aid).ToList();
            return ans;
        }


    }
}
