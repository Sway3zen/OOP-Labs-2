using CefSharp;
using lab2_7.Data;
using lab2_7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7
{
  public class Login
  {
    public string Email { get; set; }
    public string Password { get; set; }

    public Login(string email, string password)
    {
      this.Email = email;
      this.Password = password;

      this.LoginUser();
    }

    public void LoginUser()
    {
      using (AppDbContext db = new AppDbContext())
      {
        var user = db.Users.Where(u => u.Email == this.Email && u.Password == this.Password).ToList<UserVm>();

        if (user.Count <= 0)
        {
          Form1.browser.ExecuteScriptAsync("alert('Wrong email or password')");
          return;
        }

        string FullName = user[0].Name + " " + user[0].Surname;
        Form1.browser.ExecuteScriptAsync("window.playerLogin('" + FullName + "', '" + user[0].Email + "');");
      }
    }
  }
}
