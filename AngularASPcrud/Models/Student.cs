using System.ComponentModel.DataAnnotations;

namespace AngularASPcrud.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string firstname { get; set; }
        
        public string lastname { get; set; }
        
        public string course { get; set; }

        }
}
    

