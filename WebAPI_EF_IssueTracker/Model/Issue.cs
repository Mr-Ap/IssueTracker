using System.ComponentModel.DataAnnotations;

namespace WebAPI_EF_IssueTracker.Model
{
    public class Issue
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Title{ get; set; }
        [Required]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime IssueCreateTime { get; set; }
        public DateTime? IssueResolveTime { get; set; }

    }
    public enum Priority
    {
        Low, Medium, High
    }
    public enum IssueType
    {
        Feature, Bug, Documentation
    }
}
