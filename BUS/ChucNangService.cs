using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class ChucNangService
    {
        public List<Sanpham> sanPhamCache;

        public ChucNangService()
        {
            sanPhamCache = GetSanPhams(); 
        }

        public List<Sanpham> GetSanPhams()
        {
            
            using (Model1 model = new Model1())
            {
                return model.Sanphams.ToList();
            }
        }
        public List<LoaiSP> GetLoaiSPs()
        {
            using (Model1 model = new Model1())
            {
                return model.LoaiSPs.ToList();
            }
        }


        public void AddSanPham(string maSP, string tenSP, DateTime ngayNhap, string maLoai)
        {
           
            if (sanPhamCache.Any(sp => sp.MaSP == maSP))
            {
                throw new Exception("Sản phẩm đã tồn tại.");
            }

           
            Sanpham newSanPham = new Sanpham
            {
                MaSP = maSP,
                TenSP = tenSP,
                Ngaynhap = ngayNhap,
                MaLoai = maLoai
            };
            sanPhamCache.Add(newSanPham);
        }

        public void UpdateSanPham(string maSP, string tenSP, DateTime ngayNhap, string maLoai)
        {
           
            var existingSanPham = sanPhamCache.FirstOrDefault(sp => sp.MaSP == maSP);
            if (existingSanPham == null)
            {
                throw new Exception("Sản phẩm không tồn tại.");
            }

           
            existingSanPham.TenSP = tenSP;
            existingSanPham.Ngaynhap = ngayNhap;
            existingSanPham.MaLoai = maLoai;
        }

        public void DeleteSanPham(string maSP)
        {
            
            var existingSanPham = sanPhamCache.FirstOrDefault(sp => sp.MaSP == maSP);
            if (existingSanPham == null)
            {
                throw new Exception("Sản phẩm không tồn tại.");
            }

           
            sanPhamCache.Remove(existingSanPham);
            SaveChanges();
            
        }

        public Sanpham FindSanPham(string maSP)
        {
            
            return sanPhamCache.FirstOrDefault(sp => sp.MaSP == maSP);
        }

        public void SaveChanges()
        {
            
            using (Model1 model = new Model1())
            {
                foreach (var sanpham in sanPhamCache)
                {
                    model.Sanphams.AddOrUpdate(sanpham);
                }
                model.SaveChanges();
            }
        }

        public void DiscardChanges()
        {
            
            sanPhamCache = GetSanPhams();
        }
    }
}
