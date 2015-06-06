using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DropYourCard.Data.Models.Mapping;

namespace DropYourCard.Data.Models
{
    public partial class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext()
            : base("Name=DataContext")
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<ExceptionLog1> ExceptionLogs1 { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameChatMessage> GameChatMessages { get; set; }
        public DbSet<GamesList> GamesLists { get; set; }
        public DbSet<LoginSession> LoginSessions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChatMessageMap());
            modelBuilder.Configurations.Add(new ExceptionLogMap());
            modelBuilder.Configurations.Add(new ExceptionLog1Map());
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new GameChatMessageMap());
            modelBuilder.Configurations.Add(new GamesListMap());
            modelBuilder.Configurations.Add(new LoginSessionMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new PrivateMessageMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
        }
    }
}
