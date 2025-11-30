using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Lessons
{
    [PrimaryKey(nameof(LessonID),nameof(VideoURL))]
    public class LessonVideo
    {
        public int LessonID { get; set; }
        [ForeignKey(nameof(LessonID))]

        [JsonIgnore]
        public Lesson? Lesson { get; set; }=null!;

        public string VideoURL { get; set; }=null!;
    }
}
