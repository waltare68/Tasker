//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class NotificationLog
    {
        public int LogID { get; set; }
        public Nullable<int> NotificationID { get; set; }
        public Nullable<System.DateTime> SentAt { get; set; }
        public string DeliveryStatus { get; set; }
        public string DeliveryStatusDescription { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual Notification Notification { get; set; }
    }
}
