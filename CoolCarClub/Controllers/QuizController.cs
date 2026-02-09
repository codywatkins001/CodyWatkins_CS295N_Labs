using CoolCarClub.Models;
using Microsoft.AspNetCore.Mvc;

public class QuizController : Controller
{
    private Quiz BuildQuiz()
    {
        var quiz = new Quiz();
        quiz.Questions.Add(new QuizQuestion
        {
            Question = "What device in a car is used to steer the vehicle?",
            CorrectAnswer = "Steering wheel"
        });

        quiz.Questions.Add(new QuizQuestion
        {
            Question = "What pedal do you press to make the car slow down or stop?",
            CorrectAnswer = "Brake"
        });

        quiz.Questions.Add(new QuizQuestion
        {
            Question = "What fuel do most cars use?",
            CorrectAnswer = "Gasoline"
        });

        return quiz;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var quiz = BuildQuiz();

        var vm = new QuizViewModel();
        vm.Questions = quiz.Questions.Select(q => q.Question).ToList();

        return View(vm);
    }

    [HttpPost]
    public IActionResult Index(QuizViewModel vm)
    {
        var quiz = BuildQuiz();
        vm.Results = quiz.CheckAnswers(vm.UserAnswers);

        vm.Questions = quiz.Questions.Select(q => q.Question).ToList();

        return View(vm);
    }
}
