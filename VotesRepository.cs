using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlowProject.DomainModel;

namespace StackOverFlowProject.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }
    public class VotesRepository : IVotesRepository
    {
        StackOverFlowDatabaseDbContext db;

        public VotesRepository()
        {
            db = new StackOverFlowDatabaseDbContext();
        }

        public void UpdateVote(int aid,int uid,int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;
            else updateValue = 0;
            Vote vote = db.Votes.Where(temp => temp.AnswerID == aid).FirstOrDefault();
            if (vote != null)
            {
                vote.VoteValue = updateValue;
            }
            else
            {
                Vote newVote = new Vote()
                { AnswerID = aid, UserID = uid, VoteValue = updateValue };
                db.Votes.Add(newVote);
            
            }
            db.SaveChanges();
        }
    }
}
