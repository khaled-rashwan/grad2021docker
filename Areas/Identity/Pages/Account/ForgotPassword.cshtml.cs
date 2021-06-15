using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace grad2021.Areas.Identity.Pages.Account
{
    //[AllowAnonymous]
    [Authorize(Policy = "writepolicy")]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            //MY COMMENTS:
            //Email attribute is not needed (No emails are connected)
            //[EmailAddress]
            [MaxLength(14), MinLength(14)]
            [RegularExpression("([0-9]+)", ErrorMessage = "الرقم القومي الذي أدخلته غير صحيح")]
            [Display(Name = "الرقم القومي")]
            public string Email { get; set; }
            //public string Code { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);

                //MY COMMENTS:
                //No need to check email confirmation because it is turned off (No email is connected)

                //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                if (user == null)
                    {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //MY COMMENTS:
                //Th below lines are commented because no email accounts are connected to users
                
                //var callbackUrl = Url.Page(
                //    "/Account/ResetPassword",
                //    pageHandler: null,
                //    values: new { area = "Identity", code },
                //    protocol: Request.Scheme);
                //await _emailSender.SendEmailAsync(
                //    Input.Email,
                //    "Reset Password",
                //    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //MY COMMENTS:
                //This part is added so that the password is reset without sending email.
                //Input = new InputModel
                //{
                //    Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
                //};
                var result = await _userManager.ResetPasswordAsync(user, code, "5aled_Rashed");

                if (result.Succeeded)
                {
                    return RedirectToPage("./ResetPasswordConfirmation");
                }

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
