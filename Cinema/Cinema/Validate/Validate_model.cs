using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Table_MovieV
    {
        [Display(Name = "รหัสหนัง")] public int M_MovieID { get; set; }

        [Display(Name = "ชือหนัง")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string M_NameMovie { get; set; }

        [Display(Name = "วันที่หนังเข้า")]
        [Required(ErrorMessage = "กรุณาเลือกสถานะ")]
        public string M_DateInMovie { get; set; }

        [Display(Name = "วันที่หนังออก")]
        [Required(ErrorMessage = "กรุณาเลือกสถานะ")]
        public string M_DateOutMovie { get; set; }

        [Display(Name = "รูปหนัง")] public byte[] M_PicMovie { get; set; }

        [Display(Name = "สถานะหนัง")]
        [Required(ErrorMessage = "กรุณาเลือกสถานะ")]
        public int? M_MovieStatus { get; set; }
    }

    [MetadataType(typeof(Table_MovieV))]
    public partial class Table_Movie
    {
    }

    public class Table_ScreenV
    {
        [Display(Name = "รหัสการฉาย")] public int S_ScreenID { get; set; }

        [Display(Name = "หนังที่ฉาย")] public int? S_MovieID { get; set; }

        [Display(Name = "โรงที่ฉาย")] public int? S_CinemaID { get; set; }

        [Display(Name = "วันที่ฉาย")] public string S_DateSN { get; set; }

        [Display(Name = "เวลาที่ฉาย")] public string S_TimeSN { get; set; }

        public int? S_StatusSN { get; set; }
    }

    [MetadataType(typeof(Table_ScreenV))]
    public partial class Table_Screen
    {
    }

    public class Table_ChairV
    {
        [Display(Name = "รหัสเก้าอี้")] public int C_ChairID { get; set; }

        [Display(Name = "ชื่อเก้าอี้")] public string C_NameChair { get; set; }

        [Display(Name = "สถานะ")] public int? C_SatatusID { get; set; }

        [Display(Name = "การฉาย")] public int? C_ScreenID { get; set; }

        [Display(Name = "ราคา")] public int? C_Price { get; set; }
    }

    [MetadataType(typeof(Table_ChairV))]
    public partial class Table_Chair
    {
    }


    public class Table_UserV
    {
        [Display(Name = "อีเมล์")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [DataType(DataType.EmailAddress)]
        public string U_EmailID { get; set; }

        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]

        public string U_Password { get; set; }

        [Display(Name = "ชื่อ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]


        public string U_Name { get; set; }

        [Display(Name = "นามสกุล")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]



        public string U_LastName { get; set; }

        [Display(Name = "บัตรประชาชน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]    
        [StringLength(13, MinimumLength = 13, ErrorMessage = "กรุณากรอกให้ครบ 13 ตัว")]
        public string U_CardID { get; set; }

        [Display(Name = "เบอร์โทร์")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "กรุณากรอกให้ครบ 10 ตัว")]

        public string U_Phone { get; set; }

        [Display(Name = "ประเภทผู้ใช้")] public int? U_TypeID { get; set; }
    }

    [MetadataType(typeof(Table_UserV))]
    public partial class Table_User
    {
    }

    public class Table_CinemaV
    {
        [Display(Name = "รหัสโรงหนัง")]
        public int C_CinemaID { get; set; }

        [Display(Name = "ชื่อโรงหนัง")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string C_Name { get; set; }

        [Display(Name = "จำนวนเก้าอี้")]
        public Nullable<int> C_AmoutHire { get; set; }

    }
    [MetadataType(typeof(Table_CinemaV))]
    public partial class Table_Cinema
    {
        
    }
}