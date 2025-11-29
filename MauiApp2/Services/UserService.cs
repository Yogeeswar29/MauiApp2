using MauiApp2.Data;
using MauiApp2.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(MongoDbService db) 
        {
           _users = db.GetCollection<User>("users");

        }
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _users.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
