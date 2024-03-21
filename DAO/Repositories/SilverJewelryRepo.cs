using BusinessObjects.Models;
using DAO.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public interface ISilverJewelryRepo
    {
        IQueryable<SilverJewelry> GetAll();
        Task<SilverJewelry> GetByID(string id);
        Task Create(SilverJewelry silverJewelry);
        Task<SilverJewelry> Update(SilverJewelry silverJewelry, string id);
    }
    public class SilverJewelryRepo : ISilverJewelryRepo
    {
        private readonly ISilverJewelryDAO _silverJewelryDao;
        public SilverJewelryRepo()
        {
            _silverJewelryDao = new SilverJewelryDAO();
        }
        public async Task Create(SilverJewelry silverJewelry)
        {
            try
            {
                await _silverJewelryDao.Add(silverJewelry);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<SilverJewelry> GetAll()
        {
            try
            {
                var silverJewlrys = _silverJewelryDao.GetAll().Include(s => s.Category);
                if (silverJewlrys != null)
                {
                    return silverJewlrys;
                }
                throw new Exception("No Shop Found");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<SilverJewelry> GetByID(string id)
        {
            try
            {
                var sil = _silverJewelryDao.GetByID(id);
                if (sil != null)
                {
                    return sil;

                }
                throw new Exception($"silverJewelry have {id} is not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<SilverJewelry> Update(SilverJewelry silverJewelry, string id)
        {
            //try
            //{
            //    var sil = await _silverJewelryDao.Get(s => s.SilverJewelryId.Equals(id)).SingleOrDefaultAsync();

            //    if (sil != null)
            //    {


            //        await _silverJewelryDao.Update()
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            throw new NotImplementedException();
        }
    }
}
