namespace StackOverflowDatabase.Entities
{
    public class QuestionTag
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
