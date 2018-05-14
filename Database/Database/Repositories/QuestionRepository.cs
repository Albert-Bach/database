using Database.Entities;
using Database.Models;
using Database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class QuestionRepository
    {
        public QuestionRepository(QuestionContext questionContext, QuestionViewModel questionViewModel)
        {
            QuestionContext = questionContext;
            QuestionViewModel = questionViewModel;
        }

        public QuestionContext QuestionContext { get; set; }
        public QuestionViewModel QuestionViewModel { get; set; }


        public List<Question> GetAll()
        {
            return QuestionContext.Questions.ToList();
        }

        public void Create(Question question)
        {
            QuestionContext.Questions.Add(question);
            QuestionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = QuestionContext.Questions.FirstOrDefault(x => x.QuestionId == id);
            if (question != null)
            {
                QuestionContext.Questions.Remove(question);
            }
            QuestionContext.SaveChanges();
        }

        public User GetUser(string name)
        {
            return QuestionContext.Users.FirstOrDefault(x => x.Name == name);
        }

        public QuestionViewModel GetViewModel()
        {
            QuestionViewModel.Questions = QuestionContext.Questions.ToList();
            QuestionViewModel.Users = QuestionContext.Users.ToList();
            return QuestionViewModel;
        }

        public void SaveEdit(Question question, int id)
        {
            var questionToUpdate = QuestionContext.Questions.FirstOrDefault(x => x.QuestionId == id);
            questionToUpdate.Title = question.Title;
            questionToUpdate.Answer = question.Answer;
            QuestionContext.SaveChanges();
        }

        public void CreateUser(User user)
        {
            QuestionContext.Users.Add(user);
            QuestionContext.SaveChanges();
        }

        public void DeleteUser(string name)
        {
            User usertoDelete = QuestionContext.Users.First(x => x.Name.Equals(name));
            QuestionContext.Users.Remove(usertoDelete);
            QuestionContext.SaveChanges();
        }
    }
}