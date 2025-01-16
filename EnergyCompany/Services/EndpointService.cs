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

        public bool AddEndpoint(Endpoint endpoint)
        {
            if (GetEndpoint(endpoint.SerialNumber) != null)
                return false;

            Endpoints.Add(endpoint);
            return true;
        }

        public Endpoint GetEndpoint(string serialNumber)
        {
            return Endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);
        }

        public bool UpdateEndpoint(string serialNumber, int switchState)
        {
            if (GetEndpoint(serialNumber) == null)
                return false;

            Endpoint endpoint = GetEndpoint(serialNumber);
            endpoint.SwitchState = switchState;
            return true;
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
