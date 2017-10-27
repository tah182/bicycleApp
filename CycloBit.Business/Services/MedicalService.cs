using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<MedicalDetail>> GetAsync() {
            return await db.MedicalDetails.ToListAsync();
        }

        public async Task<MedicalDetail> GetAsync(string userId) {
            return await db.MedicalDetails.Where(md => md.IdentityUserId == userId).SingleOrDefaultAsync();
        }
        
        public async Task AddAsync(MedicalDetail medicalDetail) {
            await db.MedicalDetails.AddAsync(medicalDetail);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicalDetail newDetail) {
            var oldDetail = await GetAsync(newDetail.IdentityUserId);
            oldDetail.HeightCm      = newDetail.HeightCm;
            oldDetail.WeightKg      = newDetail.WeightKg;
            
            await db.SaveChangesAsync();
        }

        public void Dispose() {
            if (this.db != null) {
                this.db.Dispose();
                this.db = null;
            }
        }
    }
}