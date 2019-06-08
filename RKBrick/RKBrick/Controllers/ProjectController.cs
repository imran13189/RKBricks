using RKBrick.Data;
using RKBrick.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RKBrick.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            RKBrickEntities _db = new RKBrickEntities();
            return View(_db.Projects.ToList());
        }

        [HttpPost]
        public ActionResult SaveProject(ProjectModel model)
        {
            RKBrickEntities _db = new RKBrickEntities();
            Project pr = new Project();
            pr.ProjectName = model.ProjectName;
            _db.Projects.Add(pr);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjectFile(int ProjectId)
        {
            ViewBag.ProjectID = ProjectId;
            return View("_ProjectFiles");
        }

        [HttpGet]
        public ActionResult Delete(int ProjectId)
        {
            RKBrickEntities _db = new RKBrickEntities();
            var pr = _db.Projects.FirstOrDefault(x => x.ProjectId == ProjectId);
            _db.Projects.Remove(pr);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteFiles(string fileId)
        {
            RKBrickEntities _db = new RKBrickEntities();
            var pr = _db.ProjectFiles.FirstOrDefault(x => x.ImgUrl == fileId);
            _db.ProjectFiles.Remove(pr);
            _db.SaveChanges();
            return Json(true);
        }

        public ActionResult Gallery()
        {
            RKBrickEntities _db = new RKBrickEntities();
            List<ProjectModel> data = (from m in _db.Projects
                                       join file in _db.ProjectFiles on m.ProjectId equals file.ProjectId
                                       select new ProjectModel()
                                       {
                                           ProjectName = m.ProjectName,
                                           ImgUrl = file.ImgUrl,
                                           ProjectId = m.ProjectId,
                                           ProjectFileId=file.ProjectFileId
                                       }).ToList();

            List<ProjectFilesModel> data1= data.GroupBy(x=>x.ProjectName,(key,g)=>new ProjectFilesModel() {ProjectName=key,ImgUrl=g.FirstOrDefault().ImgUrl,ProjectId=g.FirstOrDefault().ProjectId,Files=g.Where(x=>x.ProjectFileId != g.FirstOrDefault().ProjectFileId).ToList() }).ToList();

            return View("_Gallery", data1);
        }

        public ActionResult _GalleryFiles()
        {
            RKBrickEntities _db = new RKBrickEntities();
            List<ProjectFilesModel> data = (from m in _db.Projects
                                       join file in _db.ProjectFiles on m.ProjectId equals file.ProjectId
                                       select new ProjectModel()
                                       {
                                           ProjectName = m.ProjectName,
                                           ImgUrl = file.ImgUrl,
                                           ProjectId = m.ProjectId
                                       }).GroupBy(x => x.ProjectName, (key, g) => new ProjectFilesModel() { ProjectName = key, ImgUrl = g.FirstOrDefault().ImgUrl, ProjectId = g.FirstOrDefault().ProjectId }).ToList();

            return View(data);
        }
    }
}