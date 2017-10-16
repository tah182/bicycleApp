using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CycloBit.Common.Enums;

namespace CycloBit.Model.Entities {
    public class ApplicationUser : IdentityUser {
        private DateTime defaultCreateDate = DateTime.Today;

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string ContactPhone { get; set; }

        public string ProfilePhotoUrl { get; set; }
        
        [DataType(dataType: DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [DataType(dataType: DataType.Date)]
        public DateTime CreateDate { 
            get { return defaultCreateDate; }
            set { this.defaultCreateDate = value; }
        }

        public virtual ICollection<Location> SavedLocations { get; } = new List<Location>();

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();

        /// <summary>
        /// Navigation property for this users login accounts.
        /// </summary>
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; } = new List<IdentityUserLogin<string>>();
    }
}