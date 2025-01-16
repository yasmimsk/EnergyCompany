using EnergyCompany.Models;
using System.Collections.Generic;

namespace EnergyCompany.Services
{
    public interface IEndpointService
    {
        void AddEndpoint(Endpoint endpoint);
        Endpoint GetEndpoint(string serialNumber);
        void UpdateEndpoint(string serialNumber, int switchState);
        void DeleteEndpoint(string serialNumber);
        IList<Endpoint> GetAllEndpoints();
    }
}
