using EnergyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnergyCompany.Services
{
    public class EndpointService : IEndpointService
    {
        private IList<Endpoint> Endpoints = new List<Endpoint>();

        public void AddEndpoint(Endpoint endpoint)
        {
            Endpoints.Add(endpoint);
        }

        public Endpoint GetEndpoint(string serialNumber)
        {
            return Endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);
        }

        public void UpdateEndpoint(string serialNumber, int switchState)
        {
            Endpoint endpoint = GetEndpoint(serialNumber);
            endpoint.SwitchState = switchState;
        }

        public void DeleteEndpoint(string serialNumber)
        {
            Endpoint endpoint = GetEndpoint(serialNumber);
            Endpoints.Remove(endpoint);
        }

        public IList<Endpoint> GetAllEndpoints()
        {
            return Endpoints;
        }
    }
}
