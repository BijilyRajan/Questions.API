using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionsAPI.Models;

namespace QuestionsAPI.Controllers
{
    [ApiController]
    public class ParticipantController : ControllerBase
    {

        private readonly QuizDB _quizDB;

        public ParticipantController(QuizDB quizDB)
        {
            _quizDB = quizDB;
        }

        [HttpGet]
        [Route("api/GetParticipants")]
        public async Task<IActionResult> GetParticipants()
        {
            var participants = await _quizDB.Participants.ToListAsync();
            return Ok(participants);
        }

        [HttpGet]
        [Route("api/GetPaticipantById")]
        public async Task<IActionResult> GetPaticipantById(int participantId)
        {
            var participant = await _quizDB.Participants.FindAsync(participantId);
            return Ok(participant);
            
        }

        [HttpPost]
        [Route("api/InsertParticipants")]
        public async Task<IActionResult> InsertParticipant(Participants participants)
        {
            _quizDB.Add(participants);
            await _quizDB.SaveChangesAsync();
            return Created($"/api/GetPaticipantById?participantId={participants.ParticipantID}", participants);
        }

    }
}
