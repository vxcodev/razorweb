using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS13v01RazorEntity.Models
{
    //[Table("Posts")] //* Thiết lập tên bảng. Nếu ko sẽ tự lấy tên theo lớp
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255, MinimumLength = 10)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Created { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}