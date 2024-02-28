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
  public class Register
  {
    private UserVm user;

    public Register(UserVm user)
    {
      this.user = user;

      this.RegisterUser();
    }

    private bool IsUserExists()
    {
      using (AppDbContext db = new AppDbContext())
      {
        bool isEmailExists = db.Users.Any(u => u.Email == this.user.Email);
        if (isEmailExists)
        {
          Form1.browser.ExecuteScriptAsync("alert('Email already registered')");
          return true;
        }

        bool isNumberExists = db.Users.Any(u => u.PhoneNumber == this.user.PhoneNumber);
        if (isNumberExists) {
          Form1.browser.ExecuteScriptAsync("alert('Phone number already registered')");
          return true;
        }
      }

      return false;
    }

    private void RegisterUser()
    {
      bool isUserExists = this.IsUserExists();

      if (isUserExists) return;

      using (AppDbContext db = new AppDbContext())
      {
        db.Users.Add(this.user);
        db.SaveChanges();

        MessageBox.Show("add");
      }
    }
  }
}
