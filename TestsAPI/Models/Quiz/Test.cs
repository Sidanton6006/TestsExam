using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models.Auth;

namespace Tests.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual User Author { get; set; }
        public int AuthorId { get; set; }

        public virtual Quiz Quiz { get; set; }
        public int QuizId { get; set; }

        public int PassingScore { get; set; }
        public bool isTestCorrect { get; set; }
    }
}
