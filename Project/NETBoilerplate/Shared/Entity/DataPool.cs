using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AdvancedSoftware.DataAccess.Entity;

namespace NETBoilerplate.Shared.Entity
{
    public class DataPool : EntityBase
    {
        public string PoolName { get; set; }
        public User User { get; set; }
        public IList<DataPoolStorage> DataPoolStorages { get; set; }
        [Timestamp]
        public new byte[] Timestamp { get; set; }
    }
}