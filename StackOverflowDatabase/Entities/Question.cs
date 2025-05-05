namespace StackOverflowDatabase.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime AskedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }

        // Tags, Comments, User
    }
}
