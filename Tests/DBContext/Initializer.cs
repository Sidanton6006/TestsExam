using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.DBContext
{
    public class Initializer : DropCreateDatabaseAlways<TasksDbContext>
    {
        protected override void Seed(TasksDbContext _ctx)
        {
            base.Seed(_ctx);

            Answer answer1 = new Answer() { AnswerText = "World!", isCorrect = true };
            Answer answer2 = new Answer() { AnswerText = "2", isCorrect = false };
            Answer answer3 = new Answer() { AnswerText = "3", isCorrect = false };
            Answer answer4 = new Answer() { AnswerText = "4", isCorrect = false };

            _ctx.Answers.Add(answer1);
            _ctx.Answers.Add(answer2);
            _ctx.Answers.Add(answer3);
            _ctx.Answers.Add(answer4);
            _ctx.SaveChanges();

            Ask ask1 = new Ask() { AskText = "Hello, ... ?", Answers = new List<Answer>() { answer1, answer2, answer3, answer4 }, isAnswerCorrect = false };

            _ctx.Asks.Add(ask1);
            _ctx.SaveChanges();

            Quiz quiz1 = new Quiz() { Asks = new List<Ask>() { ask1 }, isQuizComplited = false, isQuizCorrect = false };

            _ctx.Quizs.Add(quiz1);
            _ctx.SaveChanges();
        }
    }
}
