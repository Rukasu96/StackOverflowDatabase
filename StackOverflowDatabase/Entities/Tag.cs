﻿namespace StackOverflowDatabase.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
