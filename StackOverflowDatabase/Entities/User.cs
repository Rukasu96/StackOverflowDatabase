namespace StackOverflowDatabase.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserNick { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
