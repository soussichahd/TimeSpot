using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAmazonstore3.Data;
using MyAmazonstore3.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace MyAmazonstore3.Pages.User
{
    public class authModel : PageModel
    {
        private readonly MyAmazonstore3Context _context;

        public authModel(MyAmazonstore3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public void OnGet()
        {
            // Rien à faire pour GET
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Vérifier les informations dans la BDD
            var user = _context.User
                .FirstOrDefault(u => u.Email == Input.Email && u.Password == Input.Password);

            if (user != null)
            {

                // 2️⃣ Sérialiser l'objet utilisateur (DTO léger recommandé)
                var userInfo = new
                {
                    user.UserId,
                    user.Nom,
                    user.Email,
                    user.Role
                };

                string userJson = JsonSerializer.Serialize(userInfo);

                //  Créer le cookie qui contient un JSON avec les infos utilisateur ds le cookie
                Response.Cookies.Append("UserCookie", userJson, new CookieOptions
                {
                    HttpOnly = true,              // sécurisé côté client
                    Expires = DateTimeOffset.UtcNow.AddHours(2)  // durée du cookie
                });

                // Authentification réussie
                // Tu peux ici créer une session ou cookie si besoin
                // Exemple : HttpContext.Session.SetString("UserEmail", user.Email);


       
                    return RedirectToPage("/Acceuil/Acceuil");
            }
            else
            {
                ErrorMessage = "Email ou mot de passe incorrect.";
                return Page();
            }
        }
    }
}
