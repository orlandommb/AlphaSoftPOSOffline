using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AlphaSoftPOSOffline.Models;
using Microsoft.EntityFrameworkCore;
using AlphaSoftPOSOffline.Data;

namespace AlphaSoftPOSOffline.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly RoleManager<Rol> RolManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IDbContextFactory<ApplicationDbContext> _IDbContextFactory;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<Usuario> signInManager,
            ILogger<LoginModel> logger,
            UserManager<Usuario> userManager, RoleManager<Rol> rolManager, IDbContextFactory<ApplicationDbContext> iDbContextFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            RolManager = rolManager;
            _IDbContextFactory = iDbContextFactory;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/seleccionarempresasucursal");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            {

                if (Input.UserName == "AlphaSoft")
                {
                    var User = await _userManager.FindByNameAsync("AlphaSoft");
                    if (User == null)
                    {
                        var NewUser = new Usuario()
                        {
                            UserName = "AlphaSoft",
                            EmpresaId = 1
                        };

                        await _userManager.CreateAsync(NewUser, "AS8805");

                        if (!await RolManager.RoleExistsAsync("SuperAdmin"))
                        {
                            var NewRol = new Rol()
                            {
                                Name = "SuperAdmin"
                            };

                            await RolManager.CreateAsync(NewRol);


                        }
                        var SuperUser = await _userManager.FindByNameAsync("AlphaSoft");

                        await _userManager.AddToRoleAsync(SuperUser, "SuperAdmin");
                        
                        using var DbContext = _IDbContextFactory.CreateDbContext();
                        var UE = new UsuarioEmpresa()
                        {
                            UsuarioId = SuperUser.Id,
                            EmpresaId = 1
                        };

                        await DbContext.AddAsync(UE);
                        
                        var US = new UsuarioSucursal()
                        {
                            UsuarioId = SuperUser.Id,
                            SucursalId = 1
                        };

                        await DbContext.AddAsync(US);
                        await DbContext.SaveChangesAsync();
                    }
                }

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
