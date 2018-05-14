using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Question
    {
        [Key]
        public int? QuestionId { get; set; }
        public string Title { get; set; }
        public double VersionNumber { get; set; }
        public User User { get; set; }
        public string Answer { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("yyyy/MM/dd");
    }
}
