namespace API.Models
{
    public class SistemasDistribuidosDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PagosCollectionName { get; set; } = null!;
    }
}
