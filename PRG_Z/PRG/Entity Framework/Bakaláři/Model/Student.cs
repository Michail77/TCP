using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp2.Model
{
    class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }
        [Required]
        public string Jmeno { get; set; }
        [Required]
        public string Prijmeni { get; set; }
        public ulong ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom Classroom { get; set; }
    }
}
