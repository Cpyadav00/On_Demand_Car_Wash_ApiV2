using Microsoft.EntityFrameworkCore;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.DTOs;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Models;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class PackageRepository : IPackage
    {
        private readonly CarDbContext _packageDb;

        public PackageRepository(CarDbContext context)
        {
            _packageDb = context;
        }
        #region Adding Package
        public async Task<bool> AddPackage(Package package)
        {
            try
            {
              if(package == null)
                {
                    return false;
                }
               await _packageDb.Packages.AddAsync(package);
                   await  _packageDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Package

        #region Delete Package
        public async Task<bool> DeletePackage(int id)
        {
            try
            {
               var package = await _packageDb.Packages.FindAsync(id);
                if(package == null)
                    return false;
                _packageDb.Packages.Remove(package);
                _packageDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Package

        #region GetAll Package
        public async Task<List<Package>> GetAllPackage()
        {
            try
            {
                var temp = await _packageDb.Packages.ToListAsync();
                return temp;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
       
        #endregion GetAll Package

        #region Get Package
        public async Task<Package> GetPackage(int id)
        {
            Package package;
            try
            {
                package = await _packageDb.Packages.FindAsync(id);
                if (package != null)
                {
                    return package;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return package;
        }
        #endregion Get Package

        #region Update Package
        public async Task<bool> UpdatePackage(Package package)
        {
            try
            {
           var package1= await _packageDb.Packages.AsNoTracking().FirstOrDefaultAsync(u=>u.Id==package.Id);
                if (package1 == null)
                   return false;
                     _packageDb.Packages.Update(package);
                await  _packageDb.SaveChangesAsync();
                return true;    
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Package


    }
}
