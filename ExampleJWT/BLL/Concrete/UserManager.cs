using ExampleJWT.BLL.Abstract;
using ExampleJWT.DAL.Abstract;
using ExampleJWT.DAL.UnitOfWork;
using ExampleJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleJWT.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public UserManager(IUserDal userDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _userDal = userDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public async Task<bool> AddAsync(User model)
        {
            await _userDal.AddAsync(model);
            if (await _unitOfWorkDal.SaveAsync()>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> AddRangeAsync(List<User> datas)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public  Task<User> GetSingleAsync(Expression<Func<User, bool>> method)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetSingleByRefreshTokenAsync(string token)
        {
            return await _userDal.GetSingleAsync(x => x.RefreshToken == token);
        }

        public async Task<User> GetSingleNameMailAsync(UserLogin user)
        {
            return await _userDal.GetSingleAsync(x=>x.Email==user.Email&&x.Password==user.Password);
        }

        public IQueryable<User> GetWhere(Expression<Func<User, bool>> method)
        {
            throw new NotImplementedException();
        }

        public bool Remove(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<User> datas)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(User model)
        {
            _userDal.Update(model);
            if (await _unitOfWorkDal.SaveAsync()>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
