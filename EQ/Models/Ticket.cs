//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EQ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string AspNetUserId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public Nullable<System.DateTime> TimeServed { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> TicketNumber { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Service Service { get; set; }
        public virtual State State { get; set; }
    }
}
