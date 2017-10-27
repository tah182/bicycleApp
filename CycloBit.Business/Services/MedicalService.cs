using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Business.Services {
    public class MedicalService : IDisposable {
        private CycloBitContext db;
        public MedicalService (CycloBitContext db) {
            this.db = db;
        }

        public IQueryable<MedicalDetail> Get() {
            return db.MedicalDetails;
        }

        public async Task<IEnumerable<MedicalDetail> GetAsync() {
            return await db.MedicalDetails.AsEnumerableAsync();
        }

        public async Task<MedicalDetail> GetAsync(string userId) {
            return await db.MedicalDetails.Where(md => md.IdentityUserId == userId).SingleAsync();
        }

        public void Dispose() {
            if (this.db != null) {
                this.db.Dispose();
                this.db = null;
            }
        }
    }
}