using Business.Abstract;
using Business.Constants;
using Core.Concrete;
using Core.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
           _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(eml => eml.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
           return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user),Messages.createToken);
        }
    }
}
