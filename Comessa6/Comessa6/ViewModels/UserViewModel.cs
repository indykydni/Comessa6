using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Comessa6.Models
{
  public class UserViewModel
  {

    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name length should be between 2 and 20")]
    public string Name { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
  }
}