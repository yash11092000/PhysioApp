namespace PhysioApp.Repository
{
    public class BaseRepository
    {
        protected readonly string _connectionString;

        protected BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }

}
