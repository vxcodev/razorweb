using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Razorweb.Models
{
    //[Table("Posts")] //* Thiết lập tên bảng. Nếu ko sẽ tự lấy tên theo lớp
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255, MinimumLength = 10,ErrorMessage ="{0} phải từ {2} đến {1} ký tự")]
        [Required(ErrorMessage ="{0} không được để trống")]
        [Column(TypeName = "nvarchar")]
        [Display(Name="Tiêu đề")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="{0} không được để trống")]
        [Display(Name="Ngày tạo")]
        public DateTime Created { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name="Nội dung")]
        public string Content { get; set; }
    }
}