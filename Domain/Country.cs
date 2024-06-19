using System.ComponentModel.DataAnnotations;

namespace BasicWebApiFirstExam.Domain
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

    }
}
