using EnergyCompany.Models;
using System.Collections.Generic;

namespace EnergyCompany.Services
{
    public interface IEndpointService
    {
        bool AddEndpoint(Endpoint endpoint);
        Endpoint GetEndpoint(string serialNumber);
        bool UpdateEndpoint(string serialNumber, int switchState);
        void DeleteEndpoint(string serialNumber);
        IList<Endpoint> GetAllEndpoints();
    }
}
