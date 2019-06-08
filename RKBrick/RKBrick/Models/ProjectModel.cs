using RKBrick.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RKBrick.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ImgUrl { get; set; }
        public int ProjectFileId { get; set; }
    }

    public class ProjectFilesModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ImgUrl { get; set; }
        public List<ProjectModel> Files { get; set; }
    }
}