using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicWebApiFirstExam.Domain
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public  int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
