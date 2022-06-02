using DoAn_CoSo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo2.Controllers
{
    public class SanPhamController : Controller
    {
        dbQLNongsanDataContext data = new dbQLNongsanDataContext();
        // GET: SanPham
        public ActionResult Index_SanPham()
        {
            var DS_SP = from sp in data.SanPhams select sp;
            return View(DS_SP);
        }
        public ActionResult LaySPTheoLoai(int LoaiSP)
        {
            var SP_TheoLoai = from sp in data.SanPhams where sp.Id_LSP == LoaiSP select sp;
            return View(SP_TheoLoai);
        }
        public ActionResult LayCT_SanPham(int id)
        {
            var CT_SP = from sp in data.SanPhams where sp.Id_SP == id select sp;
            return View(CT_SP);
        }
    }
}