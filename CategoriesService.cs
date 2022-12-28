using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlowProject.DomainModel;
using StackOverFlowProject.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
using StackOverFlowProject.ViewModels;

namespace StackOverFlowProject.ServiceLayer
{

    public interface ICategoriesService
    {
        void InsertLanguage(LanguageViewModel cvm);
        void UpdateLanguage(LanguageViewModel cdm);
        void DeleteLanguage(int cid);
        List<LanguageViewModel> GetLanguages();
        LanguageViewModel GetLanguageByLanguageID(int LanguageID);
    }

    public class CategoriesService : ICategoriesService
    {
        ILanguagesRepository cr;

        public CategoriesService()
        {
            cr = new LanguagesRepository();
        }

        public void InsertLanguage(LanguageViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LanguageViewModel, Languages>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Languages c = mapper.Map<LanguageViewModel, Languages>(cvm);
            cr.insertLanguage(c);
        }

        public void UpdateLanguage(LanguageViewModel cdm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LanguageViewModel, Languages>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Languages c = mapper.Map<LanguageViewModel, Languages>(cdm);
            cr.UpdateLanguage(c);
        }

        public void DeleteLanguage(int cid)
        {
            cr.DeleteLanguage(cid);
        }

        public List<LanguageViewModel> GetLanguages()
        {
            List<Languages> c = cr.GetLanguages();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Languages, LanguageViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<LanguageViewModel> cvm = mapper.Map<List<Languages>,List<LanguageViewModel>>(c);
            return cvm;
        }

        public LanguageViewModel GetLanguageByLanguageID(int LanguageID)
        {
            Languages c = cr.GetLanguagesByLanguageID(LanguageID).FirstOrDefault();
            LanguageViewModel cvm = null;
            if (c != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<LanguageViewModel, Languages>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<Languages, LanguageViewModel>(c);
            }
            return cvm;
        }
    }
}






        
 