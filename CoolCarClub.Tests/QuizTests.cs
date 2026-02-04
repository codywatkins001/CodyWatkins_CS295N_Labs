using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolCarClub.Models;
using System.Collections.Generic;

namespace CoolCarClub.Tests
{
    [TestClass]
    public class QuizTests
    {
        [TestMethod]
        public void CheckAnswers_WrongAnswer_ReturnsFalse()
        {
            var quiz = new Quiz();
            quiz.Questions.Add(new QuizQuestion
            {
                Question = "What does MVC stand for?",
                CorrectAnswer = "Model View Controller"
            });

            var userAnswers = new List<string> { "Most Valuable Car" };

            var results = quiz.CheckAnswers(userAnswers);

            Assert.IsFalse(results[0]);
        }

        [TestMethod]
        public void CheckAnswers_RightAnswer_ReturnsTrue()
        {
            var quiz = new Quiz();
            quiz.Questions.Add(new QuizQuestion
            {
                Question = "What does MVC stand for?",
                CorrectAnswer = "Model View Controller"
            });

            var userAnswers = new List<string> { "Model View Controller" };

            var results = quiz.CheckAnswers(userAnswers);

            Assert.IsTrue(results[0]);
        }
    }
}
