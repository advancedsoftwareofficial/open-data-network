using AdvancedSoftware.DataAccess.Entity;

namespace NETBoilerplate.Shared.Entity
{
    public class DataPoolStorage : EntityBase
    {
        public DataPool DataPool { get; set; }
        public string DataHash { get; set; }
        public string Data { get; set; }
    }
}