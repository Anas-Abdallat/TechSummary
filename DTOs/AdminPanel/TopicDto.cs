﻿namespace TechSummary.DTOs.AdminPanel
{
    public class TopicDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int LanguageId { get; set; }
    }
}
