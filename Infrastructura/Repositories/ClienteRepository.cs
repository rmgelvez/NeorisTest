using Core.Entities;
using Core.Interfaces;
using Infrastructura.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Repositories
{
    public class ClienteRepository: GenericRepository<Cliente>, IClientesRepository
    {
        public ClienteRepository(BancoContext context) : base(context) { }
    }
}
