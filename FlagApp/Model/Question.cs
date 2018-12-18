using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagApp.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public enum Mode
    {
        EASY,
        MEDIUM,
        EXTREME,
        CUSTOM
    }
}
