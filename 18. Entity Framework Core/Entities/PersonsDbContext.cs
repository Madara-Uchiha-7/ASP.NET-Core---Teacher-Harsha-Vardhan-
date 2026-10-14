using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class PersonsDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> Persons { get; set; }

        public PersonsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable(nameof(Countries));
            modelBuilder.Entity<Person>().ToTable(nameof(Persons));

            // Seed:
            // Approach 1:
            // modelBuilder.Entity<Country>().HasData(
            //    new Country()
            //    {
            //        CountryID = Guid.NewGuid(),
            //        CountryName = "Bharat"
            //    }    
            //);

            // Approach 2:
            string countriesJson = System.IO.File.ReadAllText("countries.json");
            List<Country> countries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesJson);

            foreach (var country in countries)
            {
                modelBuilder.Entity<Country>().HasData(country);
            }

            string personsJson = System.IO.File.ReadAllText("persons.json");
            List<Person> persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personsJson);

            foreach (var person in persons)
            {
                modelBuilder.Entity<Person>().HasData(person);
            }

            modelBuilder.Entity<Person>().Property(temp => temp.TIN)
                .HasColumnName("TaxIdentificationNumber")
                .HasColumnType("varchar(8)")
                .HasDefaultValue("ABC12345");

            // modelBuilder.Entity<Person>().HasIndex(person => person.TaxIdentificationNumber).IsUnique();

            // modelBuilder.Entity<Person>().HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8");

            modelBuilder.Entity<Person>().
                ToTable(
                    "Persons", 
                    t => t.HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8")
                );


            // From lecture 231. Table relations with EF:
            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.HasOne<Country>(c => c.Country) // this Country property is from PersonModel class.
            //    .WithMany(p => p.persons) // Here, we are trying to say that every Country has a set of persons.
            //    .HasForeignKey(P => P.CountryID);
            //});
            // Above line has beed added in "231. Table Relations with EF"
            // as a demonstration, we do not need it so commented it.
        }

        public List<Person> sp_GetAllPersons()
        {
            return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
        }

        public int sp_InsertPerson(Person person)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", person.ID),
                new SqlParameter("@Name", person.Name),
                new SqlParameter("@Email", person.Email),
                new SqlParameter("@DateOfBirth", person.DateOfBirth),
                new SqlParameter("@Gender", person.Gender),
                new SqlParameter("@CountryID", person.CountryID),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@ReceiveNewsLetters", person.ReceiveNewsLetters)
            };

            return Database.ExecuteSqlRaw(@"EXECUTE [dbo].[InsertPerson] 
                @ID, @Name, @Email, @DateOfBirth, @Gender, @CountryID, @Address, @ReceiveNewsLetters", parameters);
        }
    }
}
