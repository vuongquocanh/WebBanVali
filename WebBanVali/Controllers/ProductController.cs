using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class ProductController : Controller
    {
        VaLiEntities db = new VaLiEntities();
        // GET: Product
        public ActionResult Index(int? page)
        {
            List<tDanhMucSP> products = db.tDanhMucSPs.ToList();
            int pageSize = 12;
            int pageIndex = (page ?? 1);
            return View(products.ToPagedList(pageIndex, pageSize));
        }
        public PartialViewResult CategoryPartial()
        {
            return PartialView(db.tLoaiSPs.ToList());
        }
        public ViewResult ProductsByCategory(int? page, string categoryId = "vali")
        {
            List<tDanhMucSP> products = db.tDanhMucSPs.Where(x => x.MaLoai == categoryId).OrderBy(x => x.MaLoai).ToList();

            if(products.Count == 0)
            {
                ViewBag.Product = "Product is null!";
                ViewBag.products = db.tDanhMucSPs.ToList();
            }

            int pageSize = 4;
            int pageIndex = (page ?? 1);

            ViewBag.MaLoai = categoryId;

            return View(products.ToPagedList(pageIndex, pageSize));
        }
        public ViewResult ProductDetails(string productId)
        {
            tDanhMucSP product = db.tDanhMucSPs.SingleOrDefault(x => x.MaSP == productId);
            if(product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }
        [HttpGet]
        public ViewResult AddProduct()
        {
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(x => x.ChatLieu), "MaChatLieu", "ChatLieu");
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(x => x.KichThuoc), "MaKichThuoc", "KichThuoc");
            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(x => x.HangSX), "MaHangSX", "HangSX");
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(x => x.TenNuoc), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(x => x.Loai), "MaLoai", "Loai");
            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(x => x.TenLoai), "MaDT", "TenLoai");
            return View();
        }
        [HttpPost]
        public ViewResult AddProduct(tDanhMucSP product)
        {
            if (ModelState.IsValid)
            {
                db.tDanhMucSPs.Add(product);
                db.SaveChanges();
                return View("Index");
            }
            return View(product);
        }
        [HttpGet]
        public ViewResult UpdateProduct(string productId)
        {
            if(productId == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            tDanhMucSP product = db.tDanhMucSPs.Find(productId);
            if(product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(x => x.ChatLieu), "MaChatLieu", "ChatLieu");
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(x => x.KichThuoc), "MaKichThuoc", "KichThuoc");
            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(x => x.HangSX), "MaHangSX", "HangSX");
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(x => x.TenNuoc), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(x => x.Loai), "MaLoai", "Loai");
            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(x => x.TenLoai), "MaDT", "TenLoai");
            return View(product);
        }
        [HttpPost]
        public ViewResult UpdateProduct(tDanhMucSP product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State=EntityState.Modified;
                db.SaveChanges();
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult DeleteProduct(string productId)
        {
            tDanhMucSP product = db.tDanhMucSPs.SingleOrDefault(x => x.MaSP == productId);
            if(product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult ConfirmDelete(string productId)
        {
            tDanhMucSP product = db.tDanhMucSPs.SingleOrDefault(x => x.MaSP == productId);
            var productImage = from p in db.tAnhSPs
                               where p.MaSP == product.MaSP
                               select p;
            if(product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tAnhSPs.RemoveRange(productImage);
            db.tDanhMucSPs.Remove(product);
            db.SaveChanges();
            return View("Index");
        }
    }
}