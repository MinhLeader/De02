using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.Entities;

namespace De02
{
    public partial class frmSanpham : Form
    {
        //private SanPhamService sanPhamService;
        //private LoaiSPService loaiSPService;
        private ChucNangService chucNangService;
        LoaiSPService loaiSPService = new LoaiSPService();

        public frmSanpham()
        {
            InitializeComponent();
            //sanPhamService = new SanPhamService();
            //loaiSPService = new LoaiSPService();
            chucNangService = new ChucNangService();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

            string keyword = txtFind.Text.Trim();


            if (!string.IsNullOrEmpty(keyword))
            {

                lvSanpham.Items.Clear();


                var sanPhams = chucNangService.GetSanPhams().Where(sp =>
                    sp.MaSP.Contains(keyword) ||
                    sp.TenSP.Contains(keyword) ||
                    sp.MaLoai.Contains(keyword)
                );


                foreach (var sanPham in sanPhams)
                {
                    ListViewItem item = new ListViewItem(sanPham.MaSP);
                    item.SubItems.Add(sanPham.TenSP);
                    item.SubItems.Add(sanPham.Ngaynhap.ToString("yyyy-MM-dd"));
                    item.SubItems.Add(sanPham.MaLoai);
                    lvSanpham.Items.Add(item);
                }
            }
            else
            {

                UpdateListView();
            }
        }

        private void lvSanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanpham.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSanpham.SelectedItems[0];
                string maSP = selectedItem.SubItems[0].Text;
                Sanpham selectedSanPham = chucNangService.FindSanPham(maSP);


                txtMaSP.Text = selectedSanPham.MaSP;
                txtTenSP.Text = selectedSanPham.TenSP;
                dtNgaynhap.Value = selectedSanPham.Ngaynhap;
                cboLoaiSP.SelectedValue = selectedSanPham.MaLoai;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string maSP = txtMaSP.Text;
                string tenSP = txtTenSP.Text;
                DateTime ngayNhap = dtNgaynhap.Value;
                string maLoai = cboLoaiSP.SelectedValue.ToString();

                chucNangService.AddSanPham(maSP, tenSP, ngayNhap, maLoai);
                chucNangService.SaveChanges();


                UpdateListView();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                string maSP = txtMaSP.Text;
                string tenSP = txtTenSP.Text;
                DateTime ngayNhap = dtNgaynhap.Value;
                string maLoai = cboLoaiSP.SelectedValue.ToString();

                chucNangService.UpdateSanPham(maSP, tenSP, ngayNhap, maLoai);
                chucNangService.SaveChanges();
                UpdateListView();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvSanpham.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSanpham.SelectedItems[0];
                string maSP = selectedItem.SubItems[0].Text;
                try
                {
                    chucNangService.DeleteSanPham(maSP);
                    chucNangService.SaveChanges();
                    lvSanpham.Items.Remove(selectedItem);
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                string maSP = txtMaSP.Text;
                string tenSP = txtTenSP.Text;
                DateTime ngayNhap = dtNgaynhap.Value;
                string maLoai = cboLoaiSP.SelectedValue.ToString();

                chucNangService.UpdateSanPham(maSP, tenSP, ngayNhap, maLoai);
                chucNangService.SaveChanges();


                UpdateListView();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNoUpdate_Click(object sender, EventArgs e)
        {

            chucNangService.DiscardChanges();


            UpdateListView();
            ClearInputFields();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateListView()
        {
            lvSanpham.Items.Clear();
            var sanPhams = chucNangService.GetSanPhams();
            foreach (var sanPham in sanPhams)
            {
                ListViewItem item = new ListViewItem(sanPham.MaSP);
                item.SubItems.Add(sanPham.TenSP);
                item.SubItems.Add(sanPham.Ngaynhap.ToString("yyyy-MM-dd"));
                item.SubItems.Add(sanPham.MaLoai);
                lvSanpham.Items.Add(item);
            }
        }

        private void frmSanpham_Load(object sender, EventArgs e)
        {

            lvSanpham.View = View.Details;
            lvSanpham.Columns.Add("Mã SP", 100);
            lvSanpham.Columns.Add("Tên SP", 200);
            lvSanpham.Columns.Add("Ngày Nhập", 100);
            lvSanpham.Columns.Add("Mã Loại", 100);

            cboLoaiSP.DataSource = chucNangService.GetLoaiSPs();
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";


            UpdateListView();
        }
        private void ClearInputFields()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            dtNgaynhap.Value = DateTime.Now;
            cboLoaiSP.SelectedIndex = -1;
        }
        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtNgaynhap_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



