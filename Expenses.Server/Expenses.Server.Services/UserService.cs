using Expenses.Server.DTO;
using Expenses.Server.Entities;
using Expenses.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        const string wrongEmailOrPassMessage = "Wrong Email or Pass";
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        IBaseRepository<User> _baseRepository;

        public UserService(IBaseRepository<User> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public (bool, string, User?) Login(UserDTO userDTO)
        {
            var user = _baseRepository.Get(x => x.Email == userDTO.Email).FirstOrDefault();
            if (user == null) return (false, wrongEmailOrPassMessage, null);

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(userDTO.Password), Convert.FromHexString(user.PasswordSalt), iterations, hashAlgorithm, keySize);

            var sameHash = CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(user.PasswordHash));
            if (!sameHash) return (false, wrongEmailOrPassMessage, null);

            return (true, "OK", user);
        }

        public User Register(UserDTO userDTO)
        {

            var hashAndSalt = CreateHashAndSalt(userDTO.Password);

            var user = new User
            {
                Email = userDTO.Email,
                PasswordHash = hashAndSalt.Item1,
                PasswordSalt = hashAndSalt.Item2,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };
            return _baseRepository.Create(user);

        }
        private (string, string) CreateHashAndSalt(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return (Convert.ToHexString(hash), Convert.ToHexString(salt));
        }

    }


}
