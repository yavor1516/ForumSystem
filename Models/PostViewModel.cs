using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
    }
}
