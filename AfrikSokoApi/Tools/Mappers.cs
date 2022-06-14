using AfrikSokoApi.Models;
using AfrikSoko_DAL.Interface;
using AfrikSoko_BLL.LocalModels;
using API = AfrikSokoApi.Models;
using DAL = AfrikSoko_DAL.Models;



namespace AfrikSokoApi.Tools
{
    public static class Mappers
    {
        public static CreateUserModel ToLocal(this NewUserInfo newUser)
        {
            return new CreateUserModel
            {
                Email = newUser.Email,
                LastName = newUser.LastName,
                FirstName = newUser.FirstName,
                Password = newUser.Passwd,
                NickName = newUser.NickName
            };
        }

        public static API.AppUser ToApi(this DAL.User u, IRoleRepository repo = null)
        {
            return new API.AppUser
            {
                Id = u.Id,
                Email = u.Email,
                LastName = u.LastName,
                FirstName = u.FirstName,
                NickName = u.NickName,
                Role =u.Role
            };
        }

        public static API.Product ProToApi(this DAL.Product p)
        {
            return new API.Product
            {
                Id = p.Id,
                Description = p.Description,
                Title = p.Title,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                Origin = p.Origin,
                Featured = p.Featured,
                Visible = p.Visible,
                Deleted = p.Deleted
            };
        }


        public static API.Address ProToApi(this DAL.Address a)
        {
            return new API.Address
            {
                Id = a.Id,
                UserId = a.UserId,
                Street = a.Street,
                City = a.City,
                State = a.State,
                Zip = a.Zip,
                Country = a.Country       
            };
        }


        public static API.ProductOverview ViewAllToApi(this DAL.ProductOverview p)
        {
            return new API.ProductOverview
            {
                Uid = p.Uid,
                Company = p.Company,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Title = p.Title,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Categories = p.Categories,
                Origin = p.Origin,
                ProductType = p.ProductType,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice  
            };
        }

        public static DAL.Product ProToDal(this API.NewProductCreate f)
        {
            return new DAL.Product
            {
                Description = f.Description,
                Title = f.Title,
                ImageUrl = f.ImageUrl,
                CategoryId = f.CategoryId,
                Origin = f.Origin
            };
        }

        public static DAL.Product ProToDal(this API.ModifyProduct f)
        {
            return new DAL.Product
            {
                Id = f.Id,
                Description = f.Description,
                Title = f.Title,
                ImageUrl = f.ImageUrl,
                CategoryId = f.CategoryId,
                Origin = f.Origin
            };
        }

        public static DAL.Address ProToDal(this API.NewAddressInfo a)
        {
            return new DAL.Address
            {
                UserId = a.UserId,
                Street = a.Street,
                City = a.City,
                State = a.State,
                Zip = a.Zip,
                Country = a.Country
            };
        }


        public static DAL.Address ProToDal(this API.PutAddress p)
        {
            return new DAL.Address
            {
                Id = p.Id,
                UserId = p.UserId,
                Street = p.Street,
                City = p.City,
                State = p.State,
                Zip = p.Zip,
                Country = p.Country
            };
        }

    }
}
