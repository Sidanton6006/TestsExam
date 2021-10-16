﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.DBContext;
using Tests.Models;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TasksDbContext _ctx = new TasksDbContext();
            QuizManager.StartQuiz(_ctx.Quizs.Where(q => q.Id == 1).FirstOrDefault());
            //Console.WriteLine(_ctx.Answers.Count());
            //Console.WriteLine(_ctx.Asks.Count());
            //Console.WriteLine(_ctx.Quizs.Count());
            //Console.WriteLine(_ctx.Tests.Count());
        }
    }
}
