using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Comessa6.Models
{
  public class UserDetails
  {

    [StringLength(7, MinimumLength = 2, ErrorMessage = "Name length should be between 2 and 7")]
    public string Name { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
  }
}