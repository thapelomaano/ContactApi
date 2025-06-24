using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, FirstName = "Thapelo", LastName = "Smith", Email = "thapelom@smith.com", PhoneNumber = "0741200252" },
            new Contact { Id = 2, FirstName = "Motlatso", LastName = "Maano", Email = "motlatso@maano.com", PhoneNumber = "0795855252" },
            new Contact { Id = 3, FirstName = "John", LastName = "Brown", Email = "john@brown.com", PhoneNumber = "0712100120" },
            new Contact { Id = 4, FirstName = "Chris", LastName = "White", Email = "chris@white.com", PhoneNumber = "0720000452" },
            new Contact { Id = 5, FirstName = "James", LastName = "Adams", Email = "james@exaadams.com", PhoneNumber = "0645855252" }
        );

        modelBuilder.Entity<Note>().HasData(
            new Note { Id = 1, Content = "Met at conference", ContactId = 1 },
            new Note { Id = 2, Content = "In a meeting", ContactId = 1 },
            new Note { Id = 3, Content = "Works in HR" , ContactId = 2 },
            new Note { Id = 4, Content = "Follow up next week.", ContactId = 3 },
            new Note { Id = 5, Content = "Requested demo account", ContactId = 2 }
        );
    }
}
