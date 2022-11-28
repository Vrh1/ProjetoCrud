using ProjetoCrud.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCrud.Controllers
{
    public class ContatoController : Controller
    {
        private static string conection = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Contato> listaContato = new List<Contato>();

        // GET: Contato
        public ActionResult Inicio()
        {

            listaContato = new List<Contato>();

            using (SqlConnection oconection = new SqlConnection(conection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTATO", oconection);
                cmd.CommandType = CommandType.Text;
                oconection.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())  //Ler a consulta feita.
                {
                    while (dr.Read())
                    {
                        Contato novoContato = new Contato();
                        novoContato.IdContato = Convert.ToInt32(dr["IdContato"]);
                        novoContato.Nomes = dr["Nomes"].ToString();
                        novoContato.SobreNome = dr["Sobrenome"].ToString();
                        novoContato.Telefone = dr["Telefone"].ToString();
                        novoContato.Email = dr["Email"].ToString();

                        listaContato.Add(novoContato);
                    }
                }
            }
            return View(listaContato);
        }
    }
}