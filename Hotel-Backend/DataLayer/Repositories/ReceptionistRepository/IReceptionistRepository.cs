using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.ReceptionistRepository
{
    public interface IReceptionistRepository
    {
        Task<Receptionist> GetReceptionistByUsername(string Email);    
    }
}
