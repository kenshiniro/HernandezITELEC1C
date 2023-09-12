﻿namespace HernandezITELEC1C.Models
{
    public enum Rank
    {
       Instructor, AssistProf, Prof
    }
    public class Instructor
    {
        public int Id { get; set; }
        public string InstructorName { get; set;}

        public string InstructorEmail { get; set;}

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateHired{ get; set;}

        public Rank Rank { get; set;}

        public string IsTenured { get; set; }
    }
}
