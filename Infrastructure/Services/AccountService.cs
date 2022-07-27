﻿using ApplicationCore.Models;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(UserRegisterModel model)
        {
            // step 1: check if the email is in the db
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                throw new Exception("Email already exists, please try to login");
            }
            var salt = GetRandomSalt();

            var hashedPassword = GetHashedPasswordWithSalt(model.Password, salt);
            // continue with registration
            //create a unique salt and has the password with salt
            // save the user into user repository
            var dbUser = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var savedUser = await _userRepository.AddUser(user);
            if (savedUser.Id > 0)
            {
                return true;
            }
            return false;
        }

        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPasswordWithSalt(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Convert.FromBase64String(salt),
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));
            return hashed;
        }

        public async Task<bool> ValidateUser(UserLoginModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser == null)
            {
                throw new Exception("Please register first!");
            }

            var hashedPassword = GetHashedPasswordWithSalt(model.Password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                return true;
            }
            return false;
        }
    }
}
