namespace ODN.Package.Entity
{
    public class DataPool
    {
        public int Id { get; set; }
        public string PoolName { get; set; }
        public int UserId { get; set; }
        public byte[] Timestamp { get; set; }
    }
}