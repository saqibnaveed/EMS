//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace emsDALEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class table_Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public table_Event()
        {
            this.table_User = new HashSet<table_User>();
        }
    
        public int C_Event_id { get; set; }
        public string event_name { get; set; }
        public int f_destination_id { get; set; }
        public int f_picture_id { get; set; }
        public int f_guard_id { get; set; }
        public int f_bus_id { get; set; }
        public int f_manager_id { get; set; }
        public Nullable<int> event_duration { get; set; }
        public Nullable<int> event_cost { get; set; }
    
        public virtual table_Bus table_Bus { get; set; }
        public virtual table_Destination table_Destination { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<table_User> table_User { get; set; }
        public virtual table_Guard table_Guard { get; set; }
        public virtual table_Manager table_Manager { get; set; }
        public virtual table_Picture table_Picture { get; set; }
    }
}