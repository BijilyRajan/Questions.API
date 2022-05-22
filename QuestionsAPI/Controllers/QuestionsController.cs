using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionsAPI.Models;

namespace QuestionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizDB _quizDB;

        public QuestionsController(QuizDB quizDB)
        {
            _quizDB = quizDB;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var questions = await _quizDB.Questions.ToListAsync();
                
            var updated = questions.AsEnumerable()
                            .Select(x => new
                            {
                                QnID = x.QuestionID,
                                Qn = x.Question,
                                ImageName = x.ImageName,
                                Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                            }).ToList();

            return Ok(updated);

        }

        [HttpGet]
        [Route("api/GetQuestionById")]
        public async Task<IActionResult> GetQuestionById(int questionID)
        {
            var question = await _quizDB.Questions.FindAsync(questionID);
            return Ok(question);
        }

        [HttpPost]
        [Route("api/GetAnswersById")]
        public async Task<IActionResult> GetAnswers([FromBody] int[] qIDs)
        {

            var questions = await _quizDB.Questions.ToListAsync();

            var answers = questions.AsEnumerable()
                .Where(q => qIDs.Contains(q.QuestionID))
                .OrderBy(x => { return Array.IndexOf(qIDs, x.QuestionID); })
                .Select(z => z.Answer)
                .ToArray();

            return Ok(answers);
        }



    }
}
