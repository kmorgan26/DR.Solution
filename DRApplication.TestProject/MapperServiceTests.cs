using DRApplication.Client.Interfaces;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
using Moq;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRApplication.TestProject
{
    public class MapperServiceTests
    {
        public class HttpMessageHandlerMock : HttpMessageHandler
        {
            public HttpMessageHandlerMock()
            {

            }
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }


        public readonly Mock<IManagerService> _managerServiceMock = new Mock<IManagerService>();
        public readonly Mock<ILoadHelpers> _loadHelpersMock =new();

        public MapperServiceTests(Mock<HttpMessageHandler> httpClient, Mock<IManagerService> managerServiceMock, Mock<ILoadHelpers> loadHelpersMock)
        {
            _managerServiceMock = managerServiceMock;
            _loadHelpersMock = loadHelpersMock;
        }

        [Fact]
        public async void DeviceFromDeviceInsertVmAsync_Should_Return_Device_Object()
        {
            // Arrange
            var mapperService = new MapperService(_managerServiceMock.Object, _loadHelpersMock.Object);
            var deviceInsertVm = new DeviceInsertVm();
            
            // Act
            var device = await mapperService.DeviceFromDeviceInsertVmAsync(deviceInsertVm);

            // Assert
            Assert.NotNull(device);
            Assert.IsType<Device>(device);
            Assert.Equal(device.Name, deviceInsertVm.Device);
        }
    }
}
