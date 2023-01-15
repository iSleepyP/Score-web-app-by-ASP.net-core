using System.ComponentModel.DataAnnotations;

namespace test.Models // 1 model 1 table
{
    public class Student //table name
    {
        [Key] //ให้ id = primary key
        public int Id { get; set; } //col name

        [Required] //Name no null
        public string Name { get; set; }

        [Range(0,100)]
        public int Score { get; set; }

    }
}
