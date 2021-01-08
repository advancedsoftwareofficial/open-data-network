using AdvancedSoftware.DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace NETBoilerplate.Shared.Entity
{
    public class Content : EntityBase
    {
        public string Title { get; set; }
        public string Body { get; set; }
        [Timestamp]
        public new byte[] Timestamp { get; set; }
    }
}
