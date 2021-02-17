using Newtonsoft.Json;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.ComponentModel;

namespace ClassRoomDataAPI
{
    /// <summary>
    /// Class RoomServices
    /// Write your documentation here
    /// </summary>
    public class RoomServices : IRoomServices
    {
        private readonly HttpClient _client;

        public RoomServices() {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<RoomStatus>> GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync("https://smartclassroom-c4c2c-default-rtdb.firebaseio.com/room.json");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            //var objs = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
            //foreach (var value in objs) {
            //    var result = Dyn2Dict(value);
            //    string con = JsonConvert.SerializeObject(result);
            //    RoomStatus status = JsonConvert.DeserializeObject<RoomStatus>(con);
            //}

            return JsonConvert.DeserializeObject<IEnumerable<RoomStatus>>(jsonResponse);
        }

        public Dictionary<String, String> Dyn2Dict(dynamic dynObj)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
            {
                String obj = propertyDescriptor.GetValue(dynObj);
                dictionary.Add(propertyDescriptor.Name, obj);
            }
            return dictionary;
        }
    }
}