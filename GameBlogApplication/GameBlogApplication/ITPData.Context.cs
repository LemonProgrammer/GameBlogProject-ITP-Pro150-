﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITPEntities : DbContext
    {
        public ITPEntities()
            : base("name=ITPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<DiscussionComment> DiscussionComments { get; set; }
        public virtual DbSet<Discussion> Discussions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
        public virtual DbSet<UserDiscussion> UserDiscussions { get; set; }
    }
}