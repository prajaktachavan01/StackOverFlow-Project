using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFlowProject.ViewModels
{
    public class EditQuestionViewModel
    {
        public int QuestionID { get; set; }

        [Required]
        public string QuestionName { get; set; }
        [Required]
        public DateTime QuestionDateAndTime { get; set; }

        [Required]
        public int LanguageID { get; set; }
    }
}
