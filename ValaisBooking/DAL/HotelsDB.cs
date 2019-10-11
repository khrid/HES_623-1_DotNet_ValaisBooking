using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class HotelsDB
    {
        public IConfiguration Configuration { get; set; }

        public HotelsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Hotel> GetAllHotels()
        {
            List<Hotel> results = null;
            string connectionString = Configuration.GetConnectionString("ValaisBookingLocal");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "select * from hotels";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                            {
                                results = new List<Hotel>();
                            }

                            Hotel hotel = new Hotel();
                            hotel.IdHotel = (int)dr["IdHotel"];
                            hotel.Name = (string)dr["Name"];
                            //hotel.Description = (string)dr["Description"];
                            hotel.Location = (string)dr["Location"];
                            hotel.Category = (int)dr["Category"];
                            hotel.HasWifi = (bool)dr["HasWifi"];
                            hotel.HasParking = (bool)dr["HasParking"];
                            hotel.Phone = (string)dr["Phone"];
                            hotel.Email = (string)dr["Email"];
                            hotel.Website = (string)dr["Website"];

                            results.Add(hotel);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return results;
        }
    }
}
