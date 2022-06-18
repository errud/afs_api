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


        public static API.Supplier ToApi(this DAL.Supplier s)
        {
            return new API.Supplier
            {
                Id = s.Id,
                UserId=s.UserId,
                Logo = s.Logo,
                Company = s.Company,
                SectorId = s.SectorId,
                ServiceId = s.ServiceId,
                Membership = s.Membership,
                Contact = s.Contact,
                Phone = s.Phone,
                Email = s.Email,
                Url = s.Url,
                Address = s.Address,
                City = s.City,
                Country = s.Country,
                AdditInfo = s.AdditInfo,
                Status = s.Status,
                Created = s.Created
            };
        }

        public static API.Buyer ToApi(this DAL.Buyer b)
        {
            return new API.Buyer
            {
                Id = b.Id,
                UserId = b.UserId,
                Phone = b.Phone,
                City = b.City,
                Country = b.Country,
                Company = b.Company,
                Url = b.Url,
                Status = b.Status
            };
        }

        public static API.Category ToApi(this DAL.Category c)
        {
            return new API.Category
            {
                Id = c.Id,
                Name = c.Name,
                Url = c.Url,
                Visible = c.Visible,
                Deleted = c.Deleted,
                Editing = c.Editing,
                IsNew = c.IsNew
            };
        }


        public static API.Comment ToApi(this DAL.Comment c)
        {
            return new API.Comment
            {
                Id = c.Id,
                UserId = c.UserId,
                ProductId = c.ProductId,
                Content = c.Content
       
            };
        }

        public static API.Sector ToApi(this DAL.Sector s)
        {
            return new API.Sector
            {
                Id = s.Id,
                SectorName = s.SectorName      
            };
        }

        public static API.Service ToApi(this DAL.Service s)
        {
            return new API.Service
            {
                Id = s.Id,
                ServiceName = s.ServiceName,
                Price = s.Price,
                Period = s.Period,
                Note = s.Note
            };
        }

        public static API.ProductType ToApi(this DAL.ProductType pt)
        {
            return new API.ProductType
            {
                Id = pt.Id,
                Name = pt.Name,
                Editing = pt.Editing,
                IsNew = pt.IsNew         
            };
        }


        public static API.SupplyItemOverview ToApi(this DAL.SupplyItemOverview si)
        {
            return new API.SupplyItemOverview
            {
                //UserId = si.UserId,
                FirstName = si.FirstName,
                LastName = si.LastName,
                Email = si.Email,
                ProductTitle = si.ProductTitle,
                ProductType = si.ProductType,
                Quantity = si.Quantity,
                TotalPrice = si.TotalPrice 
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

        public static DAL.Supplier ProToDal(this API.NewSupplierCreate n)
        {
            return new DAL.Supplier
            {
                UserId = n.UserId,
                Logo = n.Logo,
                Company = n.Company,
                SectorId = n.SectorId,
                ServiceId = n.ServiceId,
                Membership = n.Membership,
                Contact = n.Contact,
                Phone = n.Phone,
                Email = n.Email,
                Url = n.Url,
                Address = n.Address,
                City = n.City,
                Country = n.Country,
                AdditInfo = n.AdditInfo,
                Status = n.Status,
                Created = n.Created
            };
        }


        public static DAL.Supplier ProToDal(this API.ModifySupplier m)
        {
            return new DAL.Supplier
            {
                Id = m.Id,
                UserId = m.UserId,
                Logo = m.Logo,
                Company = m.Company,
                SectorId = m.SectorId,
                ServiceId = m.ServiceId,
                Membership = m.Membership,
                Contact = m.Contact,
                Phone = m.Phone,
                Email = m.Email,
                Url = m.Url,
                Address = m.Address,
                City = m.City,
                Country = m.Country,
                AdditInfo = m.AdditInfo,
                Status = m.Status,
                Created = m.Created
            };
        }

        public static DAL.Buyer ProToDal(this API.NewBuyerCreate n)
        {
            return new DAL.Buyer
            {
                UserId = n.UserId,
                Phone = n.Phone,
                City = n.City,
                Country = n.Country,
                Company = n.Company,
                Url = n.Url,
                Status = n.Status
            };
        }


        public static DAL.Buyer ProToDal(this API.ModifyBuyer m)
        {
            return new DAL.Buyer
            {
                Id = m.Id,
                UserId = m.UserId,
                Phone = m.Phone,
                City = m.City,
                Country = m.Country,
                Company = m.Company,
                Url = m.Url,
                Status = m.Status
            };
        }

        public static DAL.Category ProToDal(this API.NewCategoryCreate n)
        {
            return new DAL.Category
            {
                Name = n.Name,
                Url = n.Url,
                Visible = n.Visible,
                Deleted = n.Deleted
     
            };
        }

        public static DAL.Category ProToDal(this API.ModifyCategory m)
        {
            return new DAL.Category
            {
                Id = m.Id,
                Name = m.Name,
                Url = m.Url,
                Visible = m.Visible,
                Deleted = m.Deleted

            };
        }

        public static DAL.Comment ProToDal(this API.NewCommentCreate n)
        {
            return new DAL.Comment
            {
                UserId = n.UserId,
                ProductId = n.ProductId,
                Content = n.Content

            };
        }

        public static DAL.Comment ProToDal(this API.ModifyComment m)
        {
            return new DAL.Comment
            {
                Id = m.Id,
                UserId = m.UserId,
                ProductId = m.ProductId,
                Content = m.Content
            };
        }
        public static DAL.Sector ProToDal(this API.NewSectorCreate n)
        {
            return new DAL.Sector
            {
                SectorName = n.SectorName
            };
        }

        public static DAL.Service ProToDal(this API.NewServiceCreate n)
        {
            return new DAL.Service
            {
                ServiceName = n.ServiceName,
                Price = n.Price,
                Period = n.Period,
                Note = n.Note
            };
        }

        public static DAL.ProductType ProToDal(this API.NewProductTypeCreate n)
        {
            return new DAL.ProductType
            {
                Name = n.Name,
                IsNew = n.IsNew,
                Editing = n.Editing
            };
        }

        public static DAL.SupplyItem ProToDal(this API.NewSupplyItemCreate n)
        {
            return new DAL.SupplyItem
            {
              UserId = n.UserId,
              ProductId= n.ProductId,
              ProductTypeId = n.ProductTypeId,
              Quantity = n.Quantity,
              TotalPrice = n.TotalPrice
            };
        }

        public static DAL.SupplyItem ProToDal(this API.ModifySupplyItem ms)
        {
            return new DAL.SupplyItem
            {
                UserId = ms.UserId,
                ProductId = ms.ProductId,
                ProductTypeId = ms.ProductTypeId,
                Quantity = ms.Quantity,
                TotalPrice = ms.TotalPrice
            };
        }





    }
}
