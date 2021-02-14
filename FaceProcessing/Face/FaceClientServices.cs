using Microsoft.Azure.CognitiveServices.Vision.Face;
using SmartClassRoom.Domain.Services.FaceServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaceProcessing.Face
{
    public class FaceClientServices : IFaceClientServices
    {
        private readonly string _endpoint;
        private readonly string _key;

        public FaceClientServices(string endpoint, string key)
        {
            _endpoint = endpoint;
            _key = key;
        }

        public IFaceClient FaceClicent()
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(_key)) { Endpoint = _endpoint };
        }
    }
}
