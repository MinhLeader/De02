using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.Migrations;


namespace BUS
{
    public class SanPhamService
    {
    //    public List<Sanpham> GetAll()
    //    {
    //        Model1 model = new Model1();
    //        return model.Sanphams.ToList();
    //    }
    //    public Sanpham FindByID(string maSP)
    //    {
    //        Model1 sp = new Model1();
    //        return sp.Sanphams.FirstOrDefault(p => p.MaSP == maSP);
    //    }

    //    public void AddorUpdate(Sanpham S)
    //    {
    //        Model1 sp = new Model1();
    //        sp.Sanphams.AddOrUpdate(S);
    //        sp.SaveChanges();
    //    }

    //    public void DeleteSV(string maSV)
    //    {
    //        Model1 model = new Model1();
    //        var SP = model.Sanphams.FirstOrDefault(p => p.MaSP == maSV);
    //        model.Sanphams.Remove(SP);
    //        model.SaveChanges();
    //    }
    //    public void UpdateDatabase(List<Sanpham> sanphamList)
    //    {
    //        // Cập nhật cơ sở dữ liệu với danh sách sản phẩm được cung cấp
    //        Model1 model = new Model1();
    //        foreach (var sanpham in sanphamList)
    //        {
    //            model.Entry(sanpham).State = EntityState.Modified;
    //        }
    //        model.SaveChanges();
    //    }
    }
}
