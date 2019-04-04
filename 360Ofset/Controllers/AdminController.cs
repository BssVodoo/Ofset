using _360Ofset.Models;
using NZF_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace _360Ofset.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        #region Login
        public ActionResult Index()
        {
            Session["Eposta"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(KullaniciDB m)
        {
            DataAccesBase db = new DataAccesBase();
            string sql = "Select * from Kullanici";
            DataTable dt = db.ReturnDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Eposta"].ToString() == m.Eposta & dr["Sifre"].ToString() == m.Sifre)
                {
                    Session["Eposta"] = dr["Eposta"].ToString();
                    return RedirectToAction("Yonetim", "Admin");
                }

            }
            Response.Write("<script>alert('Kullanıcı Adı veya Şifre Hatalı')</script>)");
            return View();
        } 
        #endregion

        #region Slider

        public ActionResult Yonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            string sql;
            List<ImagesDB> list = new List<ImagesDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Images";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new ImagesDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    ResimUrl = item["ResimUrl"].ToString(),
                    RAciklama = item["RAciklama"].ToString(),
                    RBaslik = item["RBaslik"].ToString(),
                });
            }
            ViewBag.Slider = list;
            return View();
        }
        [HttpPost]
        public ActionResult ImageUpload(HttpPostedFileBase uploadfile, ImagesDB AS)
        {
            string UzunAd;
            Images re = new Images();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.ResimUrl = UzunAd;
            re.RAciklama = AS.RAciklama;
            re.RBaslik = AS.RBaslik;
            re.Kaydet();


            return RedirectToAction("Yonetim", "Admin");
        }
        public ActionResult SliderSil(int id)
        {
            string sql;
            List<ImagesDB> list = new List<ImagesDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Images where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["ResimUrl"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));
            Images b = new NZF_DAL.Images(id);
            var deleteState = b.Delete();
            return RedirectToAction("Yonetim", "Admin");
        } 
        #endregion

        #region Referans
        public ActionResult RefYonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
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
            ViewBag.Ref = list;
            return View();
        }
        [HttpPost]
        public ActionResult ImageRef(HttpPostedFileBase uploadfile)
        {
            string UzunAd;
            RefImages re = new RefImages();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.RefResim = UzunAd;
            re.Kaydet();


            return RedirectToAction("RefYonetim", "Admin");
        }
        public ActionResult RefSil(int id)
        {
            string sql;
            List<RefImagesDB> list = new List<RefImagesDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from RefImages where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["RefResim"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));

            RefImages b = new NZF_DAL.RefImages(id);
            var deleteState = b.Delete();
            return RedirectToAction("RefYonetim", "Admin");
        }
        #endregion

        #region Masaüstü
        public ActionResult MasaustuYonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
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
            ViewBag.Masa = list;
            return View();
        }
        [HttpPost]
        public ActionResult MasaUpload(HttpPostedFileBase uploadfile, MasaDB AS)
        {
            string UzunAd;
            Masa re = new Masa();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.MasaResim = UzunAd;
            re.MasaBaslik = AS.MasaBaslik;
            re.MasaAciklama = AS.MasaAciklama;
            re.Kaydet();


            return RedirectToAction("MasaustuYonetim", "Admin");
        }
        public ActionResult MasaSil(int id)
        {
            string sql;
            List<MasaDB> list = new List<MasaDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Masa where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["MasaResim"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));
            Masa b = new NZF_DAL.Masa(id);
            var deleteState = b.Delete();
            return RedirectToAction("MasaustuYonetim", "Admin");
        }
        #endregion

        #region Ambalaj
        public ActionResult AmbalajYonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
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
            ViewBag.Amba = list;
            return View();
        }
        public ActionResult AmbaUpload(HttpPostedFileBase uploadfile, AmbalajDB AS)
        {
            string UzunAd;
            Ambalaj re = new Ambalaj();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.AResim = UzunAd;
            re.ABaslik = AS.ABaslik;
            re.AAciklama = AS.AAciklama;
            re.Kaydet();


            return RedirectToAction("AmbalajYonetim", "Admin");
        }
        public string de;
        public ActionResult AmbaSil(int id)
        {

            string sql;
            List<AmbalajDB> list = new List<AmbalajDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Ambalaj where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["AResim"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));



            Ambalaj b = new NZF_DAL.Ambalaj(id);
            var deleteState = b.Delete();
            return RedirectToAction("AmbalajYonetim", "Admin");
        }
        #endregion

        #region Sticker
        public ActionResult StickerYonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
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
            ViewBag.Stic = list;
            return View();
        }
        public ActionResult SticUpload(HttpPostedFileBase uploadfile, StickerDB AS)
        {
            string UzunAd;
            Sticker re = new Sticker();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.SResim = UzunAd;
            re.SBaslik = AS.SBaslik;
            re.SAciklama = AS.SAciklama;
            re.Kaydet();


            return RedirectToAction("StickerYonetim", "Admin");
        }
        public ActionResult SticSil(int id)
        {
            string sql;
            List<StickerDB> list = new List<StickerDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Sticker where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["SResim"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));

            Sticker b = new NZF_DAL.Sticker(id);
            var deleteState = b.Delete();
            return RedirectToAction("StickerYonetim", "Admin");
        }
        #endregion

        #region Promosyon
        public ActionResult PromosyonYonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
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
            ViewBag.Pro = list;
            return View();
        }
        public ActionResult ProUpload(HttpPostedFileBase uploadfile, PromosyonDB AS)
        {
            string UzunAd;
            Promosyon re = new Promosyon();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.PResim = UzunAd;
            re.PBaslik = AS.PBaslik;
            re.PAciklama = AS.PAciklama;
            re.Kaydet();


            return RedirectToAction("PromosyonYonetim", "Admin");
        }
        public ActionResult ProSil(int id)
        {
            string sql;
            List<PromosyonDB> list = new List<PromosyonDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Promosyon where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["PResim"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));

            Promosyon b = new NZF_DAL.Promosyon(id);
            var deleteState = b.Delete();
            return RedirectToAction("PromosyonYonetim", "Admin");
        }
        #endregion

        #region UfakResim
        public ActionResult Ufakresim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            string sql;
            List<AnasayfaDB> list = new List<AnasayfaDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Anasayfa";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new AnasayfaDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    Aresim = item["Aresim"].ToString(),
                    ABaslik = item["ABaslik"].ToString(),
                });
            }
            ViewBag.Ana = list;
            return View();
        }
        public ActionResult AnaUpload(HttpPostedFileBase uploadfile, AnasayfaDB AS)
        {
            string UzunAd;
            Anasayfa re = new Anasayfa();

            string filePath = Path.Combine(Server.MapPath("~/Images/"));
            string Eki = Guid.NewGuid().ToString() + "_";
            string Ek = Path.GetFileName(uploadfile.FileName);
            string Topla = filePath + Eki + Ek;
            uploadfile.SaveAs(Topla);
            UzunAd = " ../Images/" + Eki + Ek;
            re.Aresim = UzunAd;
            re.ABaslik = AS.ABaslik;
            re.Kaydet();


            return RedirectToAction("Ufakresim", "Admin");
        }
        public ActionResult AnaSil(int id)
        {
            string sql;
            List<AnasayfaDB> list = new List<AnasayfaDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Anasayfa where ID =" + id;
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                de = item["Aresim"].ToString();

            }
            System.IO.File.Delete(Server.MapPath(de).Replace("\\Admin", ""));

            Anasayfa b = new NZF_DAL.Anasayfa(id);
            var deleteState = b.Delete();
            return RedirectToAction("Ufakresim", "Admin");
        }
        #endregion

        #region Hakkımızda
        public ActionResult HakkimizdaYonetim()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
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
            ViewBag.Hak = list;
            return View();
        }
        [HttpPost]
        public ActionResult HakkimizdaYonetim(HakkimizdaDB H)
        {
            Hakkimizda re = new Hakkimizda();
            re.HakkimizdaAc = H.HakkimizdaAc;
            re.Kaydet();


            return RedirectToAction("HakkimizdaYonetim", "Admin");
        }
        public ActionResult HakSil(int id)
        {
            
            Hakkimizda b = new NZF_DAL.Hakkimizda(id);
            var deleteState = b.Delete();
            return RedirectToAction("HakkimizdaYonetim", "Admin");
        }
        #endregion

        #region Kullanıcı
        public ActionResult KullaniciEkle()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(KullaniciDB u)
        {
            if (u.ID == 0)
            {
                Kullanici p = new Kullanici(u.ID);
                p.Eposta = u.Eposta;
                p.Sifre = u.Sifre;
                p.Kaydet();
                return RedirectToAction("KullaniciEkle", "Admin");
            }
            else
            {
                Kullanici p = new Kullanici(u.ID);
                p.Eposta = u.Eposta;
                p.Sifre = u.Sifre;
                p.Kaydet();
                return RedirectToAction("KullaniciEkle", "Admin");
            }
        }
        public ActionResult KullaniciListesi()
        {
            if (Session["Eposta"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            string sql;
            List<KullaniciDB> list = new List<KullaniciDB>();
            DataAccesBase db = new DataAccesBase();
            sql = "select * from Kullanici";
            DataTable model = db.ReturnDataTable(sql);
            foreach (DataRow item in model.Rows)
            {
                list.Add(new KullaniciDB
                {
                    ID = Convert.ToInt32(item["ID"]),
                    Eposta = item["Eposta"].ToString(),
                    Sifre = item["Sifre"].ToString(),

                });
            }
            return View(list);
        }
        public JsonResult KulSil(int id)
        {
            Kullanici b = new Kullanici(id);
            var deleteState = b.Delete();
            return Json(true, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        public ActionResult MailPost(Mail s)
        {
            string Mesaj = "Mail " + DateTime.Now + " tarihinde " + s.AdSoyAd + " Tarafından Gönderilmiştir. İletişim Bilgileri: " + s.Tel +" "+ s.Eposta + " Konu:" + s.Konu;
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new MailAddress("bilgi@360ofset.com.tr");//Verici
            mail.To.Add("info@360ofset.com.tr");//Alıcı
            mail.IsBodyHtml = true;//Html mi
            mail.Subject = "360Ofset İletişim";//Mail Konusu
            mail.BodyEncoding = System.Text.Encoding.UTF8;//UTF-8 Encoding
            mail.Body = Mesaj;//Mail Mesajı
            SmtpClient sc = new SmtpClient();
            sc.Host = "mail.technorob.com";//Smtp Host
            sc.Port = 587;//Smtp Port
            sc.EnableSsl = false;//Enable SSL
            sc.Credentials = new NetworkCredential("bilgi@360ofset.com.tr", "OTov43L5");//Gmail Kulanıcı - Şifre
            sc.Send(mail);//Mail Gönder
            return RedirectToAction("Index","Home");
        }

    }
}