using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolManagement.Models //Must be the same namespace as "original" classes.
{
    public class CoursesMetadata
    {
        [StringLength(50)]
        [Required]
        [DisplayName("Course Title")]
        public string Title { get; set; }
        [Range(0,8)]
        public Nullable<int> Credits { get; set; }
    }

    public class StudentMetadata
    {
        public int StudentID { get; set; }
      
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
      
        [DisplayName("Date Enrolled")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
    }

    [MetadataType(typeof(CoursesMetadata))]
    public partial class Course
    {}

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    { }
}