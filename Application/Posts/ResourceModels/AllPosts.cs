using System;

namespace Application.Posts.ResourceModels
{
    public class AllPosts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public string Image { get; set; }
        public string DisplayName { get; set; }  
    }
}