using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BrewerService
    {
        private readonly IBrewerRepository _brewerRepository;

        public BrewerService(IBrewerRepository brewerRepository)
        {
            _brewerRepository = brewerRepository;
        }
    }
}
