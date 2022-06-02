using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_CoSo2.Models;
namespace DoAn_CoSo2.Controllers
{
    public class TrangChuController : Controller
    {
        dbQLNongsanDataContext data = new dbQLNongsanDataContext();
        private List<SanPham> LaySPMoi(int count)
        {
            //Sắp xếp giảm dần theo ngày cập nhật
            return data.SanPhams.OrderByDescending(sp => sp.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index_TrangChu()
        {
            var SPMoi = LaySPMoi(8);
            return View(SPMoi);
        }

        public ActionResult DangXuat()
        {
            Session["hotenkh"] = null;
            var SPMoi = LaySPMoi(8);
            return View(SPMoi);
        }
    }
}