namespace ODN.Package.Entity
{
    public class DataPoolStorage
    {
        public int Id { get; set; }
        public int DataPoolId { get; set; }
        public string DataHash { get; set; }
        public string Data { get; set; }
        public byte[] Timestamp { get; set; }
    }
}