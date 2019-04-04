using _360Ofset.Models;
using NZF_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _360Ofset.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string sql;
            List<ImagesDB> list = new List<ImagesDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Images";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new ImagesDB
                {
                    ResimUrl = item["ResimUrl"].ToString(),
                    RAciklama = item["RAciklama"].ToString(),
                    RBaslik = item["RBaslik"].ToString(),
                });
            }
            ViewBag.Slider = list;

            string Asql;
            List<AnasayfaDB> Alist = new List<AnasayfaDB>();
            Asql = "select * from Anasayfa";
            DataTable Amodel = db.ReturnDataTable(Asql);
            foreach (DataRow item in Amodel.Rows)
            {
                Alist.Add(new AnasayfaDB
                {
                    Aresim = item["Aresim"].ToString(),
                    ABaslik = item["ABaslik"].ToString(),
                });
            }
            ViewBag.Anas = Alist;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Hakkimizda()
        {
            string sql;
            List<HakkimizdaDB> list = new List<HakkimizdaDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Hakkimizda";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new HakkimizdaDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    HakkimizdaAc = item["HakkimizdaAc"].ToString(),
                });
            }
            ViewBag.HakK = list;
            return View();
        }
        public ActionResult Refereanslar()
        {
            string sql;
            List<RefImagesDB> list = new List<RefImagesDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from RefImages";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new RefImagesDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    RefResim = item["RefResim"].ToString(),
                });
            }
            ViewBag.Refe = list;
            return View();
        }
        public ActionResult MasaustuYayincilik()
        {
            string sql;
            List<MasaDB> list = new List<MasaDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Masa";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new MasaDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    MasaResim = item["MasaResim"].ToString(),
                    MasaBaslik = item["MasaBaslik"].ToString(),
                    MasaAciklama = item["MasaAciklama"].ToString(),
                });
            }
            ViewBag.Masas = list;
            return View();
        }
        public ActionResult Ambalaj()
        {
            string sql;
            List<AmbalajDB> list = new List<AmbalajDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Ambalaj";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new AmbalajDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    AResim = item["AResim"].ToString(),
                    ABaslik = item["ABaslik"].ToString(),
                    AAciklama = item["AAciklama"].ToString(),
                });
            }
            ViewBag.Ambal = list;
            return View();
        }
        public ActionResult Etiket()
        {
            string sql;
            List<StickerDB> list = new List<StickerDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Sticker";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new StickerDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    SResim = item["SResim"].ToString(),
                    SBaslik = item["SBaslik"].ToString(),
                    SAciklama = item["SAciklama"].ToString(),
                });
            }
            ViewBag.Stick = list;
            return View();
        }
        public ActionResult Promosyon()
        {
            string sql;
            List<PromosyonDB> list = new List<PromosyonDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Promosyon";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new PromosyonDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    PResim = item["PResim"].ToString(),
                    PBaslik = item["PBaslik"].ToString(),
                    PAciklama = item["PAciklama"].ToString(),
                });
            }
            ViewBag.Prom = list;
            return View();
        }
    }
}