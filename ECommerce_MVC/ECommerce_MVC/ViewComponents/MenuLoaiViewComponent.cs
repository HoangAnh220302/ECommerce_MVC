using ECommerce_MVC.Data;
using ECommerce_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_MVC.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        public readonly Hshop2023Context db;
        public MenuLoaiViewComponent(Hshop2023Context context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(loai => new MenuLoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai, 
                SoLuong = loai.HangHoas.Count
            }).OrderBy(p => p.TenLoai);

            return View(data);
        }
    }
}
