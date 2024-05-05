using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            AgregarPersona(10, "Federico", "Alcazar", "23/09/2001", "Santa Cruz", "Av.JuanGarza Nro345");
            AgregarPersona(9, "Federico", "Alcazar", "23/09/2001", "Santa Cruz", "Av.JuanGarza Nro345");
            EliminarPersona(10);

    }
    string connectionString = "Data Source=localhost;Initial Catalog=DBPablo;User ID=sa;Password=123456;";
    public void AgregarPersona(int id, string nombre, string apellidos, string fechaNacimiento, string departamento, string direccion)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Persona (idPesrona,nombre, apellidos, fechaNacimiento, departamento, direccion) VALUES (@id,@nombre, @apellidos, @fechaNacimiento, @departamento, @direccion)", connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@departamento", departamento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.ExecuteNonQuery();
            Response.Write(nombre+"\n");
            Response.Write(apellidos);
            Response.Write(fechaNacimiento);
            Response.Write(departamento);
            Response.Write(direccion);
        }
    }
    
    public void EliminarPersona(int idPersona)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Persona WHERE idPesrona = @idPersona", connection);
            cmd.Parameters.AddWithValue("@idPersona", idPersona);
            cmd.ExecuteNonQuery();
        }
    } 
}

