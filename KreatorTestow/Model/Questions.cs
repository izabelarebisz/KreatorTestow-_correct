using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreatorTestow.Model
{
    class Questions
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public int? Correct { get; set; }

        public Questions(string question, string[] answers)
        {
            Question = question;
            Answers = answers;
        }
        public Questions(string question, string[] answers, int correct)
        {
            Question = question;
            Answers = answers;
        }

        public override string ToString()
        {
            return $"{Question}{Environment.NewLine}{Answers[0]}{Environment.NewLine}{Answers[1]}{Environment.NewLine}{Answers[2]}{Environment.NewLine}{Answers[3]}";
        }

        public void CheckAnswer(int? index)
        {
            Correct = index;
        }

    }
    }

