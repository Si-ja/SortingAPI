using System.Collections.Generic;

namespace SortingAPI.Models
{
    public class AnswersCollector
    {
        public List<SortingAnswers> AnswersCollection { get; set; }

        public AnswersCollector()
        {
            this.AnswersCollection = new List<SortingAnswers>();
        }
    }
}