using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface ISilverJewelryDAO : IBaseDAO<SilverJewelry, string> { }
    public class SilverJewelryDAO : BaseDAO<SilverJewelry, string>, ISilverJewelryDAO
    {

    }
}
