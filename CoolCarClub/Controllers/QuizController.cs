using CoolCarClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class QuizController : Controller
    {
        public Dictionary<int, string> Questions { get; set; }

        public Dictionary<int, string> Answers { get; set; }

        public QuizController() 
        {
            //Temp set of hard coded q's
            //in future will use a file
            Questions = new Dictionary<int, string>();
            Answers = new Dictionary<int, string>();
            Questions[1] = "What device in a car is used to steer the vehicle?";
            Answers[1] = "Steering wheel";
            Questions[2] = "What pedal do you press to make the car slow down or stop?";
            Answers[2] = "Steering wheel";
            Questions[3] = "What part of the car provides power to move it forward?";
            Answers[3] = "Engine";
        }

        public IActionResult Index()
        {
            var model = LoadQuestions(new QuizQuestions());
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string answer1,  string answer2,  string answer3)
        {
            var model = LoadQuestions(new QuizQuestions());
            model.UserAnswers[1] = answer1;
            model.UserAnswers[2] = answer2;
            model.UserAnswers[3] = answer3;
            //Check
            var checkedModel = CheckQuizAnswers(model);
            return View(checkedModel);
        }

        public QuizQuestions LoadQuestions(QuizQuestions model)
        {
            // load questions and answers into the model
            model.Questions = Questions;
            model.Answers = Answers;
            // TODO: Should these objects be created in the model?
            model.UserAnswers = new Dictionary<int, string>();
            model.Results = new Dictionary<int, bool>();
            // create empty entries for each question
            foreach (var question in Questions)
            {
                int key = question.Key;
                model.UserAnswers[key] = "";
            }

            return model;
        }
        public QuizQuestions CheckQuizAnswers(QuizQuestions model)
        {
            foreach (var question in model.Questions)
            {
                int key = question.Key;
                model.Results[key] = model.Answers[key] == model.UserAnswers[key];
            }
            return model;
        }
    }
}
