using Mail.DAL.Entities;
using Mail.DAL.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Mail.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Коллекция писем.
        /// </summary>
        public DbSet<Letter> Letters { get; init; }

        /// <summary>
        /// Коллекция статусов писем.
        /// </summary>
        public DbSet<LetterStatus> LetterStatuses { get; init; }
    }
}