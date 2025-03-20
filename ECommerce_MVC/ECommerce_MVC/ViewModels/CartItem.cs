﻿namespace ECommerce_MVC.ViewModels
{
    public class CartItem
    {
        public int MaHH { get; set; }
        public string Hinh { get; set; }
        public string TenHH { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public string TenGia { get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }
}
