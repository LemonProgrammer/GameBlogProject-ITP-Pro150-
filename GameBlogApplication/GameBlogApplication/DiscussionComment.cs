//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameBlogApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class DiscussionComment
    {
        public int DiscussionCommentID { get; set; }
        public int DiscussionID { get; set; }
        public int CommentID { get; set; }
    
        public virtual Comment Comment { get; set; }
        public virtual Discussion Discussion { get; set; }
    }
}
