using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public List<Ask> Asks { get; set; }
        public bool isQuizCorrect { get; set; }
        public bool isQuizComplited { get; set; }
    }
}
