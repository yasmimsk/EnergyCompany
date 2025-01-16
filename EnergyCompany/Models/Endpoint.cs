using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyCompany.Models
{
    public class Endpoint
    {
        public Endpoint(string serialNumber, int meterModelId, int meterNumber, string meterFirmwareVersion, int switchState)
        {
            SerialNumber = serialNumber;
            MeterModelId = meterModelId;
            MeterNumber = meterNumber;
            MeterFirmwareVersion = meterFirmwareVersion;
            SwitchState = switchState;
        }

        public string SerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public int SwitchState { get; set; }

        public string MeterModel
        {
            get
            {
                switch(MeterModelId)
                {
                    case 16:
                        return "NSX1P2W";
                    case 17:
                        return "NSX1P3W";
                    case 18:
                        return "NSX2P3W";
                    case 19:
                        return "NSX3P4W";
                }

                return "Not registered";
            }
        }

        public string State
        {
            get
            {
                switch (SwitchState)
                {
                    case 0:
                        return "Disconnected";
                    case 1:
                        return "Connected";
                    case 2:
                        return "Armed";
                }

                return string.Empty;
            }
        }
    }
}
