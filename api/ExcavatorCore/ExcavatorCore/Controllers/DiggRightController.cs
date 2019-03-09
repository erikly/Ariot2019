﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mqtt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExcavatorCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiggRightController : ControllerBase
    {
        public async Task<IActionResult> DiggRight()
        {
            var mqttClient = await MqttClient.CreateAsync("xxx");

            var sess = await mqttClient.ConnectAsync(new MqttClientCredentials("xxx", "xxx", "xxx"));

            string sendTopic = "digg";

            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("o"));

            await mqttClient.PublishAsync(new MqttApplicationMessage(sendTopic, data), MqttQualityOfService.ExactlyOnce);

            return Ok();
        }
    }
}