using SmartClassRoom.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartClassRoom.Domain.Models.FaceProcessing
{
    [Table("StudentFaces", Schema = "Admin")]
    public class StudentFaceData : DomainObject
    {
        [ForeignKey("Student")]
        public int StudentFaceDataId { get; set; }

        [MaxLength(100)]
        public string GroupId { get; set; }

        [MaxLength(100)]
        public string GroupName { get; set; }

        [MaxLength(20)]
        public string ContainerName { get; set; }

        [MaxLength(10)]
        public int NumberOfImage { get; set; }

        public bool IsTrained { get; set; }
        public bool IsActive { get; set; }

        public virtual List<StorageInfo> StorageInfos { get; set; }
        public virtual Student Student { get; set; }

    }
}
