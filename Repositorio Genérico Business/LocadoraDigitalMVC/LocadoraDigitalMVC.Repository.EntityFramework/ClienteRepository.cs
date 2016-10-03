using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using LocadoraDigitalMVC.Repository.EntityFramework.RepositorioGenerico;

namespace LocadoraDigitalMVC.Repository.EntityFramework
{
    public class ClienteRepository : RepositorioGenerico<Cliente>, IClientRepository
    {
        public ClienteRepository(LocadoraDigitalMVCContext _context) : base(_context)
        {

        }
    }
}
