using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Redes.Models
{
    public class Login
    {

       
        public string nombre { get; set; }

        [Required(ErrorMessage = "correo is required")]
        [Display(Name = "correo")]
        public string correo { get; set; }
        [Required(ErrorMessage = "contraseña is required")]
        [Display(Name = "contraseña")]
        public string contraseña { get; set; }
        public bool checkUser(string correo, string contraseña )
        {
            bool flag = false;
            string connString = ConfigurationManager.ConnectionStrings["RedSocial"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Registro where correo='" + correo + "' and contraseña='" + contraseña + "'", conn);
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                return flag;
            }
        }
    }
}