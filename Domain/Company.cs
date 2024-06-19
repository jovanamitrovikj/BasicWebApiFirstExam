using System.ComponentModel.DataAnnotations;

namespace BasicWebApiFirstExam.Domain
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
}
