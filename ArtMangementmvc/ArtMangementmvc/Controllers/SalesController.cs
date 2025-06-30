using ArtMangementmvc.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ArtMangementmvc.ViewModels;
using System.IO;
using ArtMangementmvc.Data;

namespace ArtMangementmvc.Controllers
{
    public class SalesController : Controller
    {
        AppDbContext db = new AppDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Sale> sales = db.Sales.Include(c => c.CustomerType).Include(c => c.SaleDetailes).ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale != null)
            {
                var details = db.SaleDetailes.Where(s => s.SaleId == id).ToList();
                db.SaleDetailes.RemoveRange(details);
            }
            db.Entry(sale).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            SaleViewModel sale = new SaleViewModel();
            sale.CustomerTypes = db.CustomerTypes.ToList();
            sale.SaleDetailes.Add(new SaleDetaile() { SaleDetaileId = 1 });
            return View(sale);
        }
        [HttpPost]
        public ActionResult Create(SaleViewModel vObj)
        {
            if (!ModelState.IsValid)
            {
                vObj.CustomerTypes = db.CustomerTypes.ToList();

            }
            Sale obj = new Sale();
            if (vObj.ProfileFile != null)
            {
                HttpPostedFileBase file = vObj.ProfileFile;
                string fileName = GetFileName(file);
                obj.ImageUrl = fileName;
            }
            else
            {
                obj.ImageUrl = "noimage.png";
            }
            obj.CustomerName = vObj.CustomerName;
            obj.InvoiceDate = vObj.InvoiceDate;
            obj.InvoiceNo = vObj.InvoiceNo;
            obj.CustomerTypeId = vObj.CustomerTypeId;
            obj.IsPaid = vObj.IsPaid;
            obj.SaleDetailes = vObj.SaleDetailes;
            db.Sales.Add(obj);

            try
            {
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error Occured While saving Sale");
                vObj.CustomerTypes = db.CustomerTypes.ToList();
                return Json(new { success = false, errors = new[] { "Error Occured While saving Sale" } });

            }

        }
        private string GetFileName(HttpPostedFileBase file)
        {
            string fileName = "";
            if (file != null)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/"), fileName);
                file.SaveAs(path);

            }
            return fileName;
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sale = db.Sales.Include(c => c.CustomerType).Include(c => c.SaleDetailes).Where(s => s.SaleId == id).FirstOrDefault();
            if (sale == null)
                return HttpNotFound("Student Not found");
            var vObj = new SaleViewModel
            {
                CustomerName = sale.CustomerName,
                SaleId = sale.SaleId,
                InvoiceDate = sale.InvoiceDate,
                InvoiceNo = sale.InvoiceNo,
                CustomerTypeId = sale.CustomerTypeId,
                IsPaid = sale.IsPaid,
                ImageUrl = sale.ImageUrl,
                SaleDetailes = sale.SaleDetailes.ToList(),
                CustomerTypes = db.CustomerTypes.ToList()
            };
            return View(vObj);
        }
        [HttpPost]
       
        public ActionResult Edit(SaleViewModel vobj, string OldImageUrl)
        {
            if (!ModelState.IsValid)
            {
                vobj.CustomerTypes = db.CustomerTypes.ToList();
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            Sale obj = db.Sales
                .Include(a => a.SaleDetailes)
                .FirstOrDefault(x => x.SaleId == vobj.SaleId);
            if (obj != null)
            {
                obj.CustomerName = vobj.CustomerName;
                obj.CustomerTypeId = vobj.CustomerTypeId;
                obj.InvoiceNo = vobj.InvoiceNo;
                obj.IsPaid = vobj.IsPaid;
                obj.InvoiceDate = vobj.InvoiceDate;

                if (vobj.ProfileFile != null)
                {
                    string uniqueFileName = GetFileName(vobj.ProfileFile);
                    obj.ImageUrl = uniqueFileName;
                }
                else
                    obj.ImageUrl = OldImageUrl;


                var SaleDetailesToRemove = obj.SaleDetailes
                    .Where(existingSaleDetailes => !vobj.SaleDetailes.Any(updatedSaleDetailes =>
                        updatedSaleDetailes.ArtName == existingSaleDetailes.ArtName &&
                        updatedSaleDetailes.Quantity == existingSaleDetailes.Quantity))
                    .ToList();

                foreach (var SaleDetaileToRemove in SaleDetailesToRemove)
                {

                    db.SaleDetailes.Remove(SaleDetaileToRemove);
                }

                foreach (var item in vobj.SaleDetailes)
                {
                    if (!obj.SaleDetailes.Any(existingSaleDetailes =>
                        existingSaleDetailes.ArtName == item.ArtName &&
                        existingSaleDetailes.Quantity == item.Quantity))
                    {
                        var newSaleDetailes = new SaleDetaile
                        {
                            SaleId = obj.SaleId,
                            ArtName = item.ArtName,
                            Quantity = item.Quantity
                        };
                        obj.SaleDetailes.Add(newSaleDetailes);
                    }
                }
                try
                {
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error Occured while editing Sale");
                    vobj.CustomerTypes = db.CustomerTypes.ToList();
                    return Json(new { success = false, errors = new[] { "Error occured while saving Sales" } });
                }
            }
            return View();
        }
    }
}