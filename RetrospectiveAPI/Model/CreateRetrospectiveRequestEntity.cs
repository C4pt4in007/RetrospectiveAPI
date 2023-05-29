using System.ComponentModel.DataAnnotations;

namespace RetrospectiveAPI.Model
{
    public class CreateRetrospectiveRequestEntity
    {
        
        public string? Name { get; set;}

        public string? Summary { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public List<string> ?Participants { get; set; }        

    }
}
