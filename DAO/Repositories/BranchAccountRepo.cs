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
    public interface IBranchAccountRepo
    {
        public Task<BranchAccount> Login(string email, string password);
    }
    public class BranchAccountRepo : IBranchAccountRepo
    {
        private readonly IBranchAccountDAO _branchAccountDAO;
        public BranchAccountRepo()
        {
            _branchAccountDAO = new BranchAccountDAO();
        }
        public async Task<BranchAccount> Login(string email, string password)
        {
            try
            {
                var account = await _branchAccountDAO.Get(acc => acc.EmailAddress!.Equals(email) && acc.AccountPassword.Equals(password)).SingleOrDefaultAsync();
                if (account != null)
                {
                    return account;
                }
                throw new Exception();
            }
            catch
            {
                throw new Exception("Login fail");
            }
        }
    }
}
