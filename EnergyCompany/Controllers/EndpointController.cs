using EnergyCompany.Models;
using EnergyCompany.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnergyCompany.Controllers
{
    public class EndpointController
    {
        private int[] ModelIds = new int[4] { 16, 17, 18, 19 };
        private int[] SwitchStates = new int[3] { 0, 1, 2 };

        private readonly IEndpointService _service;

        public EndpointController(IEndpointService service)
        {
            _service = service;
        }

        public void InsertEndpoint()
        {
            try
            {
                Console.WriteLine("Serial Number:");
                string serialNumber = Console.ReadLine();

                Endpoint endpoint = _service.GetEndpoint(serialNumber);
                if (endpoint != null)
                    throw new Exception("ERROR: Endpoint already exists.\n");

                Console.WriteLine("Meter Model Id (16- NSX1P2W, 17- NSX1P3W, 18- NSX2P3W, 19- NSX3P4W):");
                int meterModelId = ReadMeterModelId();

                Console.WriteLine("Meter Number:");
                int meterNumber = 0;
                while (!int.TryParse(Console.ReadLine(), out meterNumber))
                    Console.WriteLine("Meter Number must be an integer.");

                Console.WriteLine("Meter Firmware Version:");
                string meterFramewareVersion = Console.ReadLine();

                Console.WriteLine("Switch State (0- Disconnected, 1- Connected, 2- Armed):");
                int switchState = ReadSwitchState();

                endpoint = new Endpoint(serialNumber, meterModelId, meterNumber, meterFramewareVersion, switchState);
                _service.AddEndpoint(endpoint);

                Console.WriteLine("Endpoint added successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EditEndpoint()
        {
            try
            {
                Console.WriteLine("Serial Number:");
                string serialNumber = Console.ReadLine();

                Endpoint endpoint = _service.GetEndpoint(serialNumber);
                if (endpoint == null)
                    throw new Exception("ERROR: Endpoint not found.\n");

                Console.WriteLine("Enter new Switch State (0- Disconnected, 1- Connected, 2- Armed):");
                int newSwitchState = ReadSwitchState();

                _service.UpdateEndpoint(serialNumber, newSwitchState);
                Console.WriteLine("Endpoint updated successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteEndpoint()
        {
            try
            {
                Console.WriteLine("Serial Number:");
                string serialNumber = Console.ReadLine();

                Endpoint endpoint = _service.GetEndpoint(serialNumber);
                if (endpoint == null)
                    throw new Exception("ERROR: Endpoint not found.\n");

                Console.WriteLine("Are you sure you want to delete this endpoint? (y/n)");
                string confirm = Console.ReadLine();

                if (confirm.ToLower().First() == 'y')
                {
                    _service.DeleteEndpoint(serialNumber);
                    Console.WriteLine("Endpoint deleted successfully!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListAllEndpoints()
        {
            IList<Endpoint> endpoints = _service.GetAllEndpoints();
            if (!endpoints.Any())
                Console.WriteLine("No endpoints found.\n");
            else
                foreach (Endpoint endpoint in endpoints)
                    PrintEndpoint(endpoint);
        }

        public void FindEndpoint()
        {
            try
            {
                Console.WriteLine("Serial Number:");
                string serialNumber = Console.ReadLine();

                Endpoint endpoint = _service.GetEndpoint(serialNumber);
                if (endpoint == null)
                    throw new Exception("ERROR: Endpoint not found.\n");

                PrintEndpoint(endpoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int ReadMeterModelId()
        {
            int meterModelId = 0;
            while (!int.TryParse(Console.ReadLine(), out meterModelId) || !ModelIds.Contains(meterModelId))
                Console.WriteLine("Meter Model Id must be one of the following: 16- NSX1P2W, 17- NSX1P3W, 18- NSX2P3W, 19- NSX3P4W");

            return meterModelId;
        }

        private int ReadSwitchState()
        {
            int switchState = 0;
            while (!int.TryParse(Console.ReadLine(), out switchState) || !SwitchStates.Contains(switchState))
                Console.WriteLine("Meter Model Id must be one of the following: 0- Disconnected, 1- Connected, 2- Armed");

            return switchState;
        }

        private void PrintEndpoint(Endpoint endpoint)
        {
            Console.WriteLine(string.Format("Endpoint {0}:\n   Model: {1}\n   Number: {2}\n   Firmware: {3}\n   Switch state: {4}\n",
                endpoint.SerialNumber, endpoint.MeterModel, endpoint.MeterNumber, endpoint.MeterFirmwareVersion, endpoint.State));
        }
    }
}
