using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsAPI.Models
{
    public class Questions
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[System.Text.Json.Serialization.JsonIgnore]
		public int QuestionID { get; set; }
		public string Question { get; set; }
		public string? ImageName { get; set; }
		public string Option1 { get; set; }
		public string Option2 { get; set; }
		public string Option3 { get; set; }
		public string Option4 { get; set; }
		public int Answer { get; set; }
	}

    public class QuizDB : DbContext
    {
        public QuizDB(DbContextOptions<QuizDB> options) : base(options)
        {
        }

		public DbSet<Questions> Questions { get; set; }
		public DbSet<Participants> Participants { get; set; }

		public DbSet<Answers> Answers { get; set; }
	}

}
