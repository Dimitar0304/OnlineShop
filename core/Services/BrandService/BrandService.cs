using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Contracts;
using OnlineShop.Core.Models.Accessory;
using OnlineShop.Core.Models.AllClothes;
using OnlineShop.Core.Models.Shoe;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Models.Brand;
using OnlineShop.Models.Garment;

namespace OnlineShop.Core.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IRepository repository;
        public BrandService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<List<BrandViewModel>> GetAllBrands()
        {
            if (repository.All<Brand>().Count()==0)
            {
                return new List<BrandViewModel>();
            }
            return await repository.All<Brand>()
                .Select(b=>new BrandViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                }).ToListAsync();
        }


        public async Task<BrandViewModel> GetBrandById(int id)
        {
            var brand =   repository.GetByIdAsync<Brand>(id).Result;
            if (brand != null)
            {

                return new BrandViewModel()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    
                    
                };
            }
            return null;
        }

        public async Task<List<ClothesViewModel>> GetClothesForCurrentBrand(int currentBrandId)
        {
            var brand = await GetBrandById(currentBrandId);

            var clothes = new List<ClothesViewModel>();
            

            if (brand != null)
            {
                brand.Garments = await GetGarmentsForCurrentBrand(currentBrandId);
                brand.Shoes = await GetShoesForCurrentBrand(currentBrandId);
                brand.Accessories = await GetAccessoriesForCurrentBrand(currentBrandId);

                if (brand.Garments.Count>0)
                {
                    foreach (var g in brand.Garments)
                    {
                        clothes.Add(new ClothesViewModel()
                        {
                            Id = g.Id,
                            ClothesType = "Garment",
                            ImageUrl = g.ImageUrl,
                            Name = g.Name,
                            Price = g.Price
                        });
                    }
                }
                if (brand.Shoes.Count>0)
                {
                    foreach (var s in brand.Shoes)
                    {
                        clothes.Add(new ClothesViewModel()
                        {
                            Id = s.Id,
                            ClothesType = "Shoe",
                            ImageUrl = s.ImageUrl,
                            Name = s.Name,
                            Price = s.Price

                        });
                    }
                }
                if (brand.Accessories.Count>0)
                {
                    foreach (var s in brand.Accessories)
                    {
                        clothes.Add(new ClothesViewModel()
                        {
                            Id = s.Id,
                            ClothesType = "Accessory",
                            ImageUrl = s.ImageUrl,
                            Name = s.Name,
                            Price = s.Price

                        });
                    }
                }

                if (clothes.Count>0)
                {
                    return clothes;
                }
                else
                {
                    return new List<ClothesViewModel>();
                }
            }
            return clothes;
        }

        public async Task<List<GarmentViewModel>> GetGarmentsForCurrentBrand(int brandId)
        {
            var models =  repository.All<Garment>()
                .Where(g => g.BrandId == brandId)
                .ToList();
            if (models.Count<=0&&models==null)
            {
                return new List<GarmentViewModel>();
            }
            return models
                .Select(g => new GarmentViewModel()
                {
                    Id = g.Id,
                    BrandId=brandId,
                    Name =g.Model,
                    Color = g.Color,
                    Price = g.Price,
                    ImageUrl = g.ImageUrl,  
                    TypeId = g.TypeId,
                })
                .ToList();
        }
        public async Task<List<AccessoryAddViewModel>> GetAccessoriesForCurrentBrand(int brandId)
        {
            var models = repository.All<Accessory>()
                .Where(a => a.BrandId == brandId).ToList();

            if (models.Count<=0&&models==null)
            {
                return new List<AccessoryAddViewModel>();
            }
            return models
                .Select(a => new AccessoryAddViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    Type = a.Type,
                    BrandId = brandId
                }).ToList();
        }

        public async Task<List<ShoeAddViewModel>> GetShoesForCurrentBrand(int brandId)
        {
            var models = repository.AllReadOnly<Shoe>()
                .Where(s => s.BrandId == brandId).ToList();

            if (models.Count<=0&&models==null)
            {
                return new List<ShoeAddViewModel>();
            }
            return models.Select(s => new ShoeAddViewModel()
            {
                Id = s.Id,
                Name = s.Model,
                ImageUrl = s.ImageUrl,
                Price = s.Price,
                TypeId = s.TypeId,
                BrandId = brandId,
                Color = s.Color
                
            }).ToList();
        }
    }
}
