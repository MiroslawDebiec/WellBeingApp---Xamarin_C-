using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WellBeingApp.Models;

namespace WellBeingApp.Data
{
    public class WellBeingDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public WellBeingDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserEntry>().Wait();
            _database.CreateTableAsync<Profile>().Wait();
            _database.CreateTableAsync<User>().Wait();
        }

        //User Entries
        public Task<List<UserEntry>> GetNotesAsync()
        {
            return _database.Table<UserEntry>().ToListAsync();
        }

        public Task<UserEntry> GetNoteAsync(int id)
        {
            return _database.Table<UserEntry>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(UserEntry userEntry)
        {
            if (userEntry.Id != 0)
            {
                return _database.UpdateAsync(userEntry);
            }
            else
            {
                return _database.InsertAsync(userEntry);
            }
        }

        public Task<int> DeleteNoteAsync(UserEntry userEntry)
        {
            return _database.DeleteAsync(userEntry);
        }

        //Users
        public Task<int> CreateUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserAsync(string username)
        {
            return _database.Table<User>()
                .Where(i => i.Username == username)
                .FirstOrDefaultAsync();
        }

        public Task<User> GetUserAsync(Guid id)
        {
            return _database.Table<User>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Profile
        public Task<int> CreateProfileAsync(Profile profile)
        {
            return _database.InsertAsync(profile);
        }

        public Task<int> UpdateProfileAsync(Profile profile)
        {
            return _database.UpdateAsync(profile);
        }

        public Task<Profile> GetProfileAsync(Guid userId)
        {
            return _database.Table<Profile>()
            .Where(i => i.UserId == userId)
            .FirstOrDefaultAsync();
        }

    }
}
