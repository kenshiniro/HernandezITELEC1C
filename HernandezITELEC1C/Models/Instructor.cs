namespace HernandezITELEC1C.Models
{
     public enum Rank
    {
        Instructor, AssistProf, AssociateProf, Prof
    }

    public enum IsTenured
    {
        Yes, No
    }
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IsTenured IsTenured { get; set; }
        public Rank Rank { get; set; }
        public DateTime DateHired { get; set; }
    }

}