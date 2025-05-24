using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoExcursionistas
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioNombre"] != null)
                {
                    lblUsuario.Text = Session["UsuarioNombre"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx"); // o redireccionar si no hay sesión
                }
            }
        }

        /// <summary>
        /// Metodo que permite definir la clase Elemento
        /// </summary>
        public class Elemento
        {
            public string Nombre { get; set; }
            public int Peso { get; set; }
            public int Calorias { get; set; }
        }

        /// <summary>
        /// Metodo que realiza al funcioanalidad del boton Calcular
        /// recibe como parametros de entrada el minimo de calorias y el peso maximo
        /// De acuerdo al algortimo se calculan las posibles combinaciones donde las calorias sean mayores o igual al numero que ingresa por parametro
        /// y donde el peso menor o igual al numero que ingresa por parametro
        /// Como resultado se obtiene texto donde se indican los elementos optimos de acuerdo al algoritmo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            int minCalorias = int.Parse(txtMinCalorias.Text);
            int pesoMaximo = int.Parse(txtPesoMaximo.Text);

            // Lista de elementos disponibles
            List<Elemento> elementos = new List<Elemento>
            {
            new Elemento { Nombre = "E1", Peso = 5, Calorias = 3 },
            new Elemento { Nombre = "E2", Peso = 3, Calorias = 5 },
            new Elemento { Nombre = "E3", Peso = 5, Calorias = 2 },
            new Elemento { Nombre = "E4", Peso = 1, Calorias = 8 },
            new Elemento { Nombre = "E5", Peso = 2, Calorias = 3 }
            };

            var combinaciones = GenerarCombinaciones(elementos);

            var validas = combinaciones
                .Where(c => c.Sum(el => el.Calorias) >= minCalorias && c.Sum(el => el.Peso) <= pesoMaximo)
                .OrderBy(c => c.Sum(el => el.Peso))
                .ToList();

            if (validas.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                int index = 1;

                foreach (var combinacion in validas)
                {
                    int pesoTotal = combinacion.Sum(el => el.Peso);
                    int caloriasTotales = combinacion.Sum(el => el.Calorias);
                    string nombres = string.Join(", ", combinacion.Select(el => el.Nombre));

                    sb.AppendLine($"Combinación {index++}: {nombres} → Peso: {pesoTotal}, Calorías: {caloriasTotales}");
                }

                // Obtener la mejor combinación (la de menor peso)
                var mejor = validas.First();
                string mejoresElementos = string.Join(", ", mejor.Select(el => el.Nombre));
                int mejorPeso = mejor.Sum(el => el.Peso);
                int mejorCalorias = mejor.Sum(el => el.Calorias);

                sb.AppendLine();
                sb.AppendLine($"✅ Mejor combinación: {mejoresElementos} → Peso: {mejorPeso}, Calorías: {mejorCalorias}");

                lblResultado.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            }
            else
            {
                lblResultado.Text = "❌ No se encontraron combinaciones válidas.";
            }
        }



        /// <summary>
        /// Metodo que permite realizar todas las posibles combinaciones de acuerdo a los parametros de entrada
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        private List<List<Elemento>> GenerarCombinaciones(List<Elemento> elementos)
        {
            var resultado = new List<List<Elemento>>();

            int n = elementos.Count;
            for (int i = 1; i < (1 << n); i++) // 2^n combinaciones
            {
                var grupo = new List<Elemento>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                        grupo.Add(elementos[j]);
                }
                resultado.Add(grupo);
            }

            return resultado;
        }

        /// <summary>
        /// Metodo que realiza la accion del boton Eliminar, el cual limpia los datos de los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            txtMinCalorias.Text = "";
            txtPesoMaximo.Text = "";
            lblResultado.Text = "";
        }

    }
}