using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class User
    {
        [Key]
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Question> AskedQuestions { get; set; } = new List<Question>();
        public IList<Question> Questions { get; set; } = new List<Question>();
    }
}