using System;
using System.ComponentModel.DataAnnotations;

namespace Bamboo.Abp.LoginUi.Web;

public class ExternalRegisterOrUpdateDto 
{
    [Required]
    public string Phone { get; set; }
    public string Token { get; set; }
    public string Password { get; set; }

    public ExternalRegisterOrUpdateDto()
    {
        Phone = "";
        Token = "";
        Password = "";
    }
}


