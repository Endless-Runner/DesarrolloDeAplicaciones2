//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DS1
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public System.Guid Id { get; set; }
        public int Seq { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public bool Enabled { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int RolId { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
