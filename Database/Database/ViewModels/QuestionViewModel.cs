using Database.Models;
using System.Collections.Generic;

namespace Database.ViewModels
{
    public class QuestionViewModel
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
