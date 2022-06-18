using AdoToolbox;
using AfrikSoko_DAL.Interface;
using AfrikSoko_DAL.Models;
using AfrikSoko_DAL.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Repository
{
    public class SupplyItemRepo : BaseRepository, ISupplyItemRepository
    {
        public SupplyItemRepo(IConfiguration config) : base(config)
        {
        }


        internal SupplyItem Converter(SqlDataReader reader)
        {
            return new SupplyItem
            {
                UserId = (int)reader["UserId"],
                ProductId = (int)reader["ProductId"],
                ProductTypeId = (int)reader["ProductTypeId"],
                Quantity = (int)reader["Quantity"],
                TotalPrice = (decimal)reader["TotalPrice"]
             
            };
        }


        public IEnumerable<SupplyItemOverview> GetAll()
        {
            Command cmd = new Command("SELECT a.FirstName as FirstName, a.LastName as LastName, a.Email as Email, p.Title as ProductTitle, pt.Name as ProductType, su.Quantity as Quantity, su.TotalPrice as TotalPrice FROM SupplyItems su JOIN AppUser a ON su.UserId = a.Id JOIN Product p ON su.ProductId = p.id JOIN ProductType pt ON pt.id = su.ProductTypeId");
            return cnx.ExecuteReader(cmd, Converters.SupplyItemDetailedConverter);
        }

        public IEnumerable<SupplyItemOverview> GetByUser(int Id)
        {
            Command cmd = new Command("SELECT a.FirstName as FirstName, a.LastName as LastName, a.Email as Email, p.Title as ProductTitle, pt.Name as ProductType, su.Quantity as Quantity, su.TotalPrice as TotalPrice FROM SupplyItems su JOIN AppUser a ON su.UserId = a.Id JOIN Product p ON su.ProductId = p.id JOIN ProductType pt ON pt.id = su.ProductTypeId WHERE su.UserId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converters.SupplyItemDetailedConverter); 
        }
        
        public bool Create(SupplyItem s)
        {
            Command cmd = new Command("AddSupplyItem", true);

            cmd.AddParameter("userid", s.UserId);
            cmd.AddParameter("prodid", s.ProductId);
            cmd.AddParameter("prodtypeid", s.ProductTypeId);
            cmd.AddParameter("qty", s.Quantity);
            cmd.AddParameter("totprice", s.TotalPrice);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Update(SupplyItem s)
        {
            Command cmd = new Command("UpdateSupplyItem", true);

            cmd.AddParameter("prodid", s.ProductId);
            cmd.AddParameter("prodtypeid", s.ProductTypeId);
            cmd.AddParameter("qty", s.Quantity);
            cmd.AddParameter("totprice", s.TotalPrice);
            cmd.AddParameter("userid", s.UserId);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
        public bool Delete(int UserId, int ProductId, int ProductTypeId)
        {
            Command cmd = new Command("DeleteSupplyItem", true);

            cmd.AddParameter("userid", UserId);
            cmd.AddParameter("prodid", ProductId);
            cmd.AddParameter("prodtypeid", ProductTypeId);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
           
 }
