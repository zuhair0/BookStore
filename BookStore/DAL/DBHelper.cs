using System.Data.SqlClient;

namespace BookStore.DAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-RP6CCI6;Initial Catalog=BookStore;Integrated Security=True");
            SqlConnection con = new SqlConnection("Server=localhost,1401;Database=BookStore;User Id=sa;Password=Justice1234;Encrypt=false;");
            return con;
        }
    }
}
