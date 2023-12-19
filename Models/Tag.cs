namespace ForumSystem.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
