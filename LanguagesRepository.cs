using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlowProject.DomainModel;

namespace StackOverFlowProject.Repositories
{
    public interface ILanguagesRepository
    {
        void insertLanguage(Languages c);
        void UpdateLanguage(Languages c);
        void DeleteLanguage(int cid);
        List<Languages> GetLanguages();
        List<Languages> GetLanguagesByLanguageID(int LanguageID);
    }
    public class LanguagesRepository  : ILanguagesRepository
    {
        StackOverFlowDatabaseDbContext dbo;

        public LanguagesRepository()
        {
            dbo = new StackOverFlowDatabaseDbContext();
        }

        public void insertLanguage(Languages c)
        {
            dbo.Languages.Add(c);
            dbo.SaveChanges();
        }

        public void UpdateLanguage(Languages c)
        {
            Languages ct = dbo.Languages.Where(temp => temp.LanguageID == c.LanguageID).FirstOrDefault();
            if (ct != null)
            {
                ct.LanguageName = c.LanguageName;
                dbo.SaveChanges();
            }
        }

        public void DeleteLanguage(int cid)
        {
            Languages ct = dbo.Languages.Where(temp => temp.LanguageID == cid).FirstOrDefault();
            if (ct != null)
            {
                dbo.Languages.Remove(ct);
                dbo.SaveChanges();
            }
        }

        public List<Languages> GetLanguages()
        {
            List<Languages> ct = dbo.Languages.ToList();
            return ct;
        }

        public List<Languages> GetLanguagesByLanguageID(int LanguageID)
        {
            List<Languages> ct = dbo.Languages.Where(temp => temp.LanguageID == LanguageID).ToList();
            return ct;
        }
    } 
    
}
