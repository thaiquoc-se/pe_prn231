using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IBranchAccountDAO : IBaseDAO<BranchAccount, int> { }
    public class BranchAccountDAO : BaseDAO<BranchAccount, int>, IBranchAccountDAO
    {

    }
}
