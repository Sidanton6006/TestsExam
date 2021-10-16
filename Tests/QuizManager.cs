using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests
{
    public static class QuizManager
    {
        static List<string> iterators = new List<string>() { "1) ", "2) ", "3) ", "4) " };
        public static void StartQuiz(Quiz quiz)
        {
            foreach (var ask in quiz.Asks)
            {
                Console.WriteLine(ask.AskText);
                foreach (var answer in ask.Answers)
                {
                    Console.WriteLine(answer.Id + answer.AnswerText);
                }
            }
        }
    }
}
