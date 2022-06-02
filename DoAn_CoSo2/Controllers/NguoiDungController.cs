using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_CoSo2.Models;
namespace DoAn_CoSo2.Controllers
{
    public class NguoiDungController : Controller
    {
        dbQLNongsanDataContext data = new dbQLNongsanDataContext();

        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var gmail = collection["gmail"];
            var matkhau = collection["matkhau"];
            var hotenkh = collection["hotenkh"];
            var sdt = collection["sdt"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            kh.Gmail = gmail;
            kh.Matkhau = matkhau;        
            kh.Hotenkh = hotenkh;
            kh.Sdt = sdt;
            kh.Ngaysinh = DateTime.Parse(ngaysinh);
            data.KhachHangs.InsertOnSubmit(kh);
            data.SubmitChanges();
            return RedirectToAction("DangNhap", "NguoiDung");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var gmail = collection["gmail"];
            var matkhau = collection["matkhau"];
            var kh = data.KhachHangs.SingleOrDefault(n => n.Gmail == gmail && n.Matkhau == matkhau);
            if (kh != null)
            {
                Session["hotenkh"] = data.KhachHangs.FirstOrDefault().Hotenkh;
                return RedirectToAction("Index_TrangChu", "TrangChu");
            }
            else
                ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
            return View();
        }

        
    }
}