using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class Ask
    {
        public int Id { get; set; }

        public string AskText { get; set; }
        public List<Answer> Answers { get; set; }
        public bool isAnswerCorrect { get; set; }
    }
}
