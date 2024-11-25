using BookStore.Model;
using System.Data.SqlClient;

namespace BookStore.DAL
{
    public class bookStoreDAL
    {
        public static int SaveBook(bookStoreModel bm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bookid", bm.Bookid);
            cmd.Parameters.AddWithValue("@Title", bm.Title);
            cmd.Parameters.AddWithValue("@Author", bm.Author);
            cmd.Parameters.AddWithValue("@Genere", bm.Genere);
            cmd.Parameters.AddWithValue("@Pub_year", bm.Pub_year);
            cmd.Parameters.AddWithValue("@Price", bm.Price);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static List<bookStoreModel> GetBooks()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetBooks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<bookStoreModel> BookList = new List<bookStoreModel>();
            while (reader.Read())
            {
                bookStoreModel books = new bookStoreModel();

                books.Bookid = int.Parse(reader["Bookid"].ToString());
                books.Title = reader["Title"].ToString();
                books.Author = reader["Author"].ToString();
                books.Genere = reader["Genere"].ToString();
                books.Pub_year = int.Parse(reader["Pub_year"].ToString());
                books.Price = int.Parse(reader["Price"].ToString());

                BookList.Add(books);
            }
            con.Close();
            return BookList;
        }
        public static int DeleteBook(int bookid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_Delete", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bookid", bookid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
