﻿using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Services.Platforms.DeviceTypes
{
    public class DeviceTypeManager: ApiEfRepository<DeviceType>
    {
        private readonly HttpClient _http;
        static string controllerName = "devicetype";

        public DeviceTypeManager(HttpClient http) : base(http, controllerName, "Id")
        {
            _http = http;
        }
    }
}