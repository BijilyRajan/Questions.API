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

    }
}
