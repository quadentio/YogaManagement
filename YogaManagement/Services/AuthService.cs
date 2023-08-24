using AutoMapper;
using Data.Access.Repositories;
using Data.Models;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using Utilities.Helper;
using YogaManagement.Common;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Services
{
    public interface IAuthService
    {
        User VerifyUserLoginInformation(UserViewModel user);
        ClaimsIdentity CreateSecurityContext(User user);
        bool CheckDuplicateUserInformation(UserViewModel user);
        bool RegisterUserInformation(UserViewModel user);
    }

    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AuthService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Verify user information and create security context (claim identity)
        /// </summary>
        /// <param name="user">LoginViewModel</param>
        /// <returns></returns>
        public ClaimsIdentity CreateSecurityContext(User user)
        {
            // Create security context
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role ?? "")
                };

            var identity = new ClaimsIdentity(claims, Const.COOKIE_SCHEME);

            return identity;
        }

        public User VerifyUserLoginInformation(UserViewModel user)
        {
            var verifyingUser = _unitOfWork.UserRepository.GetFirstOrDefault(u =>
            u.UserName == user.UserName &&
            u.DeletedAt == null);

            if (verifyingUser == null)
            {
                return null;
            }

            string hashedPassword = EncryptionHelper.HashPassword(user.Password, verifyingUser.Salt);
            if (hashedPassword != verifyingUser.Password)
            {
                return null;
            }

            return verifyingUser;
        }

        /// <summary>
        /// Check if username is duplicate
        /// </summary>
        /// <param name="user">RegisterUserViewModel</param>
        /// <returns></returns>
        public bool CheckDuplicateUserInformation(UserViewModel user)
        {
            var dbUser = _unitOfWork.UserRepository.GetFirstOrDefault(u => u.UserName == user.UserName);
            if (dbUser != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Register user information
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool RegisterUserInformation(UserViewModel user)
        {
            // Map RegisterUserViewModel to User
            User entity = _mapper.Map<User>(user);
            entity.Salt = EncryptionHelper.CreateSalt();
            entity.Password = EncryptionHelper.HashPassword(entity.Password, entity.Salt);
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            try
            {
                _unitOfWork.UserRepository.Add(entity);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                // Logger here
                _logger.LogError("ExecAuthService: {@ErrorMessage}, {@DateTimeUTC}", ex.Message, DateTime.UtcNow);
                return false;
            }
        }
    }
}
