    using AutoMapper;
    using ECommerce_MVC.Data;
    using ECommerce_MVC.Helper;
    using ECommerce_MVC.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    namespace ECommerce_MVC.Controllers
    {
        public class KhachHangController : Controller
        {
            private readonly Hshop2023Context db;
            private readonly IMapper _mapper;

            public KhachHangController(Hshop2023Context context, IMapper mapper)
            {
                db = context;
                _mapper = mapper;
            }

            #region Register
            [HttpGet]
            public IActionResult DangKy()
            {
                return View();
            }

            [HttpPost]
            public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var khachHang = _mapper.Map<KhachHang>(model);
                        khachHang.RandomKey = Util.GenerateRandomKey();
                        khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
                        khachHang.HieuLuc = true;
                        khachHang.VaiTro = 0;

                        if (Hinh != null)
                        {
                            khachHang.Hinh = Util.UploadHinh(Hinh, "KhachHang");
                        }

                        db.Add(khachHang);
                        db.SaveChanges();
                        return RedirectToAction("Index", "HangHoa");
                    }
                    catch (Exception ex)
                    {
                        var mess = $"{ex.Message} shh";
                    }
                }
                return View();
            }
            #endregion


            #region Login
            [HttpGet]
            public IActionResult DangNhap(string? ReturnUrl)
            {
                ViewBag.ReturnUrl = ReturnUrl ?? Request.Query["ReturnUrl"].ToString();
                return View(new LoginVM());
            }

            [HttpPost]
            public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
            {
                ViewBag.ReturnUrl = ReturnUrl;
                if (ModelState.IsValid)
                {
                    var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.HoTen == model.Username);
                    if (khachHang == null)
                    {
                        ModelState.AddModelError("error", "Unable to recognize customer");
                    }
                    else
                    {
                        if (!khachHang.HieuLuc)
                        {
                            ModelState.AddModelError("error", "Your account was disabled");
                        }
                        else
                        {
                            if (khachHang.MatKhau != model.Password.ToMd5Hash(khachHang.RandomKey))
                            {
                                ModelState.AddModelError("error", "Invalid password or username");
                            }
                            else
                            {
                                var claims = new List<Claim> {
                                    new Claim(ClaimTypes.Email, khachHang.Email),
                                    new Claim(ClaimTypes.Name, khachHang.HoTen),
                                    new Claim(MySetting.CLAIM_CUSTOMER_ID, khachHang.MaKh),

								    
								    new Claim(ClaimTypes.Role, "Customer")
                                };

                                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                                await HttpContext.SignInAsync(claimsPrincipal);

                                if (Url.IsLocalUrl(ReturnUrl))
                                {
                                    return Redirect(ReturnUrl);
                                }
                                else
                                {
                                    return Redirect("/");
                                }
                            }
                        }
                    }
                }
                return View();
            }
            #endregion

            [Authorize]
            public IActionResult Profile()
            {
                return View();
            }

            [Authorize]
            public async Task<IActionResult> DangXuat()
            {
                await HttpContext.SignOutAsync();
                return Redirect("/");
            }
        }
    }

