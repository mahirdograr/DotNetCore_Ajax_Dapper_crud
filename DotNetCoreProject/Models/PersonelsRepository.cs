using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetCoreProject.Models
{
    public class PersonelsRepository
    {
        private string connectionString;

        public PersonelsRepository()
        {
            connectionString = @"Data Source=MAHIRSUPPORT;Initial Catalog=PersonelHoliday;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(connectionString); }
        }


        public void Add(Personels pers)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Personels(FirstName, LastName, AllowedPermitCount,Password,ActiveStatus,Email,TotalPermitCount)
                  VALUES (@name, @surname, @allowedpermit, @password,@activestatus,@mail,@totalpermit)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, pers);
            }
        }

        public IEnumerable<Personels> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from personels";
                dbConnection.Open();
                return dbConnection.Query<Personels>(sQuery);
            }
        }

        public Personels GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from Personels where Id=@id";
                dbConnection.Open();
                return dbConnection.Query<Personels>(sQuery, new { id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"delete from Personels where Id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = id });
            }
        }

        public void Update(Personels pers)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Update Personels Set FirstName=@FirstName, LastName=@LastName, AllowedPermitCount=@AllowedPermitCount,Password=@Password,
                  ActiveStatus=@ActiveStatus,Email=@Email,TotalPermitCount=@TotalPermitCount where Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, pers);
            }
        }
    }
}
