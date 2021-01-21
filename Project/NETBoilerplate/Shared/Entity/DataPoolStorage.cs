using System.ComponentModel.DataAnnotations;
using AdvancedSoftware.DataAccess.Entity;

namespace NETBoilerplate.Shared.Entity
{
    public class DataPoolStorage : EntityBase
    {
        public int DataPoolId { get; set; }
        public DataPool DataPool { get; set; }
        public string DataHash { get; set; }
        public string Data { get; set; }
        [Timestamp]
        public new byte[] Timestamp { get; set; }
    }
}