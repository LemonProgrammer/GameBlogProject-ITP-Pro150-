using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlogService.Models
{
    public class DiscussionModel
    {
        public int DiscussionID { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string OwnerUsername { get; set; }
        public string OnwerProfileImage { get; set; }
        public bool Status { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
