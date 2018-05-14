using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Database.Controllers
{
    public class QuestionController : Controller
    {

        public QuestionRepository QuestionRepository { get; set; }

        public QuestionController(QuestionRepository questionRepository)
        {
            QuestionRepository = questionRepository;
        }

        [Route("")]
        [Route("list")]
        public IActionResult Index([FromQuery] bool isActive)
        {
            return View(QuestionRepository.GetViewModel());
        }

        [HttpGet("create")]
        public IActionResult CreateQuestion()
        {
            return View(QuestionRepository.GetViewModel());
        }

        [HttpPost("create")]
        public IActionResult SubmitQuestion(Question question, string User)
        {
            question.User = QuestionRepository.GetUser(User);
            QuestionRepository.Create(question);
            return RedirectToAction("index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            QuestionRepository.Delete(id);
            return RedirectToAction("index");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var currentQuestion = QuestionRepository.QuestionContext.Questions.FirstOrDefault(x => x.QuestionId == id);
            return View(currentQuestion);
        }

        [HttpPost("edit/{id}")]
        public IActionResult SaveEdit(Question question, int id)
        {
            QuestionRepository.SaveEdit(question, id);
            return RedirectToAction("index");
        }

        [HttpGet("user")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost("user")]
        public IActionResult SaveUser(User user)
        {
            QuestionRepository.CreateUser(user);
            return RedirectToAction("index");
        }

        [HttpGet("deleteuser")]
        public IActionResult DeleteUser()
        {
            return View(QuestionRepository.GetViewModel());
        }

        [HttpPost("deleteuser")]
        public IActionResult Delete(string name)
        {
            QuestionRepository.DeleteUser(name);
            return RedirectToAction("index");
        }
    }
}