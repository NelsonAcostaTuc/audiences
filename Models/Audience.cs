using System;

namespace Audiences.Models
{
    public class Audience
    {
        public int Id { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
        public string Observations { get; set; }
        public int EntityId { get; set; }
        // public int UserId { get; set; }
    }
}