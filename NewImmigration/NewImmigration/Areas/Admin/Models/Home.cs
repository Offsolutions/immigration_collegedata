using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewImmigration.Areas.Admin.Models
{
    public class Home
    {
    }
    public class Country
    {
        [Key]
        public int Countryid { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<College> College { get; set; }
        //public virtual ICollection<Courses> Courses { get; set; }
    }
    public class College
    {
        [Key]
        public int CollegeId { get; set; }
        [DisplayName("College")]
        public int Countryid { get; set; }
        public virtual Country Country { get; set; }
        public string CollegeName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Campus> Campus { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }
        [DisplayName("Campus")]
        public int CollegeId { get; set; }
        public virtual College College { get; set; }
        public string CampusName { get; set; }
        public string Distance { get; set; }


    }
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
    public class Courses
    {
        [Key]
        public int CoursesId { get; set; }
        [DisplayName("Courses")]
        public int CollegeId { get; set; }
        public virtual College College { get; set; }
        public int Categoryid { get; set; }
        public virtual Category Category { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public string Fee { get; set; }
        public string Type { get; set; }
    }

}