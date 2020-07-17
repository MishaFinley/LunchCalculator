using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LunchCalculator.Models
{
    public class User
    {
        public ObjectId _id { get; set; }
        public string username { get; set; }
        public string zip { get; set; }
        public byte[] password { get; set; }
        //Requirements = they will ONLY eat food that description has this tag
        public List<string> dietaryRequirements { get; set; }
        //Resrictions = they will NEVER eat food that description has this tag
        public List<string> dietaryRestrictions { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = hashPassword(password, username);
            this.dietaryRequirements = new List<string>();
            this.dietaryRestrictions = new List<string>();
        }
        public User()
        {
            this.dietaryRequirements = new List<string>();
            this.dietaryRestrictions = new List<string>();
        }

        public bool validPassword(string password, string username)
        {
            byte[] hashedPassword = hashPassword(password, username);
            return hashedPassword.SequenceEqual(this.password);
        }

        public static byte[] hashPassword(string password, string username)
        {
            byte[] salt = Encoding.UTF8.GetBytes(username);
            byte[] hashed = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
            return hashed;
        }

    }
}
