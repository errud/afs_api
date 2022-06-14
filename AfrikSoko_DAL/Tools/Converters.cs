using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Tools
{
    public static class Converters
    {
        public static User Convert(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),               
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Role = reader["Role"].ToString(),
                NickName = reader["NickName"].ToString(),
                IsActive = (bool)reader["IsActive"]
            };
        }

        public static Comment CommentConvert(SqlDataReader reader)
        {
            return new Comment
            {
                Id = (int)reader["Id"],
                Content = reader["Content"].ToString(),
                PostDate = (DateTime)reader["PostDate"],
                UserId = (int)reader["UserId"],
                ProductId = (int)reader["ProductId"]
            };
        }

        public static Supplier SupplierConverter(SqlDataReader reader)
        {
            return new Supplier
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                Company = reader["Company"].ToString(),
                Logo = reader["Logo"].ToString(),
                SectorId = (int)reader["SectorId"],
                ServiceId = (int)reader["ServiceId"],
                Membership = (bool)reader["Membership"],
                Contact = reader["Contact"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString(),
                Url = reader["Url"].ToString(),
                Address = reader["Address"].ToString(),
                City = reader["City"].ToString(),
                Country = reader["Country"].ToString(),
                AdditInfo = reader["AdditInfo"].ToString(),
                Status = (bool)reader["Status"],
                Created = (DateTime)reader["Created"]
            };
        }

        public static ProductOverview ProdOverviewConverter (SqlDataReader reader)
        {
            return new ProductOverview
            {
                Uid = (int)reader["Uid"],
                Company = reader["Company"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Title = reader["Title"].ToString(),                
                Description = reader["Description"].ToString(),
                ImageUrl = reader["ImageUrl"].ToString(),
                Origin = reader["Origin"].ToString(),
                Categories = reader["Categories"].ToString(),
                ProductType = reader["ProductType"].ToString(),
                Quantity = (int)reader["Quantity"],
                TotalPrice = (decimal)reader["TotalPrice"]
            };
        }

        public static CommentOverview CommmentDetailedConverter(SqlDataReader reader)
        {
            return new CommentOverview
            {
   
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Content = reader["Content"].ToString(),
                ProductName = reader["ProductName"].ToString(),             
                Created = (DateTime)reader["Created"],
                Email = reader["Email"].ToString(),
                UserId = (int)reader["UserId"]

            };
        }

        public static Buyer BuyerConverter(SqlDataReader reader)
        {
            return new Buyer
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                Phone = reader["Phone"].ToString(),
                City = reader["City"].ToString(),
                Country = reader["Country"].ToString(),
                Company = reader["Company"].ToString(),
                Url = reader["Url"].ToString(),
                Status = (bool)reader["Status"]
            };
        }

        public static SupplyItemOverview SupplyItemDetailedConverter(SqlDataReader reader)
        {
            return new SupplyItemOverview
            {

                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                ProductTitle = reader["ProductTitle"].ToString(),
                ProductType = reader["ProductType"].ToString(),
                Quantity = (int)reader["Quantity"],
                TotalPrice = (decimal)reader["TotalPrice"],
                UserId = (int)reader["UserId"]

            };



        }
    }
}
