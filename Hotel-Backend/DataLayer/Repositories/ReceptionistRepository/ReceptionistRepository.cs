using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.ReceptionistRepository
{
    public class ReceptionistRepository:IReceptionistRepository
    {
        private readonly DatabaseContext DbContext;

        public ReceptionistRepository(DatabaseContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<Receptionist> GetReceptionistByUsername(string Email)
        {
            return await DbContext.Receptionists.FirstOrDefaultAsync(receptionist => receptionist.Email == Email);
        }
    }
}
