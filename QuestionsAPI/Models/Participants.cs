using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsAPI.Models
{
    public class Participants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.Text.Json.Serialization.JsonIgnore]
        public int ParticipantID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Timespend { get; set; }
    }




}
