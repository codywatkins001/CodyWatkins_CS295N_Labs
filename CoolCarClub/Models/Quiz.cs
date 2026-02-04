namespace CoolCarClub.Models
{
    public class Quiz
    {
        public List<QuizQuestion> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<QuizQuestion>();
        }

        public List<bool> CheckAnswers(List<string> userAnswers)
        {
            var results = new List<bool>();

            for (int i = 0; i < Questions.Count; i++)
            {
                bool isCorrect =
                    string.Equals(
                        Questions[i].CorrectAnswer,
                        userAnswers[i],
                        StringComparison.OrdinalIgnoreCase);

                results.Add(isCorrect);
            }

            return results;
        }

    }
}
