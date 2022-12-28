using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFlowProject.ViewModels
{
    public class LanguageViewModel
    {
        [Required]
        public int LanguageID { get; set; }

        [Required]
        public string LanguageName { get; set; }
    }
}
