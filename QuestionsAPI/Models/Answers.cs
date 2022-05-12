using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsAPI.Models
{
    public class Answers
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

}
