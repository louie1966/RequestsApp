using Aanvragen.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Aanvragen.Web.DAL {
    public class RequestDb : DbContext {
        public RequestDb() : base("DefaultConnection") {
        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestAttachment> RequestAttachments { get; set; }
        public DbSet<PersonAttachment> PersonAttachments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("request");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}