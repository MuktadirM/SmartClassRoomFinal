using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClassRoom.Domain.Models.FaceProcessing
{
    public class FaceProcess
    {
        public int Id { get; set; }
        public string Matric { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; }
    }
}
