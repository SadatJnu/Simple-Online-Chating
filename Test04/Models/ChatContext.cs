using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test04.Models
{
    public class ChatContext:DbContext
    {
        public ChatContext():base("MyChatConnection")
        {

        }
        public DbSet<ChatMessage> ChatMessage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

    }//class
}//ns