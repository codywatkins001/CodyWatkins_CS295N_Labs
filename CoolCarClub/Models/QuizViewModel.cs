namespace CoolCarClub.Models
{
    public class QuizViewModel
    {
        public List<string> Questions { get; set; }
        public List<string> UserAnswers { get; set; }
        public List<bool> Results { get; set; }

        public QuizViewModel()
        {
            Questions = new List<string>();
            UserAnswers = new List<string>();
            Results = new List<bool>();
        }
    }

}
