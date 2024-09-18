using System.ComponentModel.DataAnnotations ;
using System.ComponentModel.DataAnnotations.Schema ;


namespace todoAPI.Models
{
    public class TodoModel
    {
        [Key]
        public Guid TodoId { get; set; }

        public string Title  { get; set; }
        public string Description { get; set; }
        public bool   Completed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}