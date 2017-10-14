using System;
using System.Security.Claims;
using CycloBit.Model;

namespace CycloBit.Business.Services {
    public class MedicalService : IDisposable {
        private readonly ClaimsPrincipal User;
        private CycloBitContext db;
        public MedicalService (ClaimsPrincipal user, CycloBitContext db) {
            this.User = user;
            this.db = db;
        }

        public void Dispose() {
            if (this.db != null) {
                this.db.Dispose();
                this.db = null;
            }
        }
    }
}