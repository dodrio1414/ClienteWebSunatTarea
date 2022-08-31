using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeppAplicationSunat
{
    public partial class Sunat : System.Web.UI.Page
    {

        //Acceder al servicio web
        private static ServiceReference1.WebService1SoapClient servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar()
        {
            gvSunat.DataSource = servicio.Listar().Tables[0];
            gvSunat.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }


        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtTexto.Text.Trim();
            string tipo = List.SelectedItem.Value.ToString();
            //bool rsta = servicio.Buscar(texto, criterio);
            if (tipo == "Ruc")
            {
                gvSunat.DataSource = servicio.Buscar(texto, tipo).Tables[0];
                gvSunat.DataBind();
            }
            else if (tipo == "Nombre")
            {
                gvSunat.DataSource = servicio.Buscar(texto, tipo).Tables[0];
                gvSunat.DataBind();
            }
        }
    }
}