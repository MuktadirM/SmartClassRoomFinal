using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartClassRoom.Domain.Models.FaceProcessing
{
    [Table("StorageInfo", Schema = "Student")]
    public class StorageInfo : DomainObject
    {
        [ForeignKey("StudentFaceData")]
        public int StudentFaceId { get; set; }

        [MaxLength(20)]
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime AddedOn { get; set; }

        public StudentFaceData StudentFace { get; set; }
        
    }
}
