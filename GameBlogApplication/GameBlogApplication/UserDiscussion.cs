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
    
    public partial class UserDiscussion
    {
        public int AccountId { get; set; }
        public int DiscussionId { get; set; }
        public int UserDiscussionID { get; set; }
    
        public virtual Discussion Discussion { get; set; }
        public virtual User User { get; set; }
    }
}
