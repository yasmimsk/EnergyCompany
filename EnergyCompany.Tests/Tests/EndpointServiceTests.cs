using EnergyCompany.Models;
using EnergyCompany.Services;

namespace EnergyCompany.Tests.Tests
{
    public class EndpointServiceTests
    {
        private readonly EndpointService _service;

        public EndpointServiceTests()
        {
            _service = new EndpointService();
        }

        [Fact]
        public void AddEndpoint_AddNewEndpoint_SerialNumberIsUnique()
        {
            Endpoint endpoint = new Endpoint("12345", 16, 333, "2.0.0", 1);
            bool success = _service.AddEndpoint(endpoint);

            Assert.True(success);  //Verifica se a operação foi realizada com sucesso
            Assert.Single(_service.GetAllEndpoints());  //Verifica se tem 1 endpoint cadastrado
        }

        [Fact]
        public void AddEndpoint_SerialNumberIsDuplicate_ShouldNotAdd()
        {
            Endpoint endpoint1 = new Endpoint("12345", 16, 333, "2.0.0", 1);
            _service.AddEndpoint(endpoint1);

            Endpoint endpoint2 = new Endpoint("12345", 17, 222, "2.1.0", 0);
            bool success = _service.AddEndpoint(endpoint2);

            Assert.False(success);  //Verifica que a segunda operação falhou
            Assert.Single(_service.GetAllEndpoints());  //Apenas o primeiro endpoint foi cadastrado
        }

        [Fact]
        public void GetEndpoint_ValidSerialNumber_ShouldReturnCorrectEndpoint()
        {
            Endpoint endpoint = new Endpoint("12345", 16, 333, "2.0.0", 1);
            _service.AddEndpoint(endpoint);

            Endpoint result = _service.GetEndpoint("12345");

            Assert.NotNull(result);  //Verifica o endpoint foi encontrado
            Assert.Equal("12345", result.SerialNumber);  //Verifica que o serial é correto
        }

        [Fact]
        public void UpdateEndpoint_ValidSerialNumber_ShouldUpdateEndpoint()
        {
            Endpoint endpoint = new Endpoint("12345", 16, 333, "2.0.0", 1);
            bool success = _service.AddEndpoint(endpoint);

            success = _service.UpdateEndpoint("12345", 0);

            Assert.True(success);  //Verifica se a operação foi realizada com sucesso
            Assert.Equal(0, _service.GetEndpoint("12345").SwitchState);  //O Switch State foi alterado
        }

        [Fact]
        public void DeleteEndpoint_ValidSerialNumber_ShouldDeleteEndpoint()
        {
            Endpoint endpoint = new Endpoint("12345", 16, 333, "2.0.0", 1);
            _service.AddEndpoint(endpoint);
            _service.DeleteEndpoint("12345");

            Assert.Empty(_service.GetAllEndpoints());  //Verifica que a lista está vazia
        }
    }
}