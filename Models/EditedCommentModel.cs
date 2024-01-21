using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ForumSystem.Models
{
    public class EditedCommentModel
    {
        public int PostId { get; set; }
        public int CommentID { get; set; }
        public string?  Content { get; set; }
    }
}
