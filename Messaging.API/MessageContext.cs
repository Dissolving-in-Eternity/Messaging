using Messaging.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Messaging.API
{
    public class MessageContext : DbContext
    {
	    public MessageContext(DbContextOptions<MessageContext> options) 
		    : base(options)
	    {
	    }

	    public DbSet<Message> Messages { get; set; }
	    public DbSet<Recipient> Recipients { get; set; }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Message>()
			    .HasMany(s => s.Recipients)
			    .WithOne(s => s.Message);

			// Workaround for the case when EF doesn't return data even with eager loading
		    modelBuilder.Entity<Recipient>().Ignore(x => x.Message);
	    }
    }
}
