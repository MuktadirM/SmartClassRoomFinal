using Microsoft.Azure.CognitiveServices.Vision.Face;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.FaceServices
{
    public interface IFaceClientServices
    {
        public IFaceClient FaceClicent();
    }
}
