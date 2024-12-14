using MauiBooks.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MauiBooks
{
    public class LocalDbService : IDisposable
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DB_NAME);
            _connection = new SQLiteAsyncConnection(dbPath);
            InitializeDatabaseAsync().Wait(); // Ensure the table is created during service initialization
        }

        // Ensure the database and table are created
        private async Task InitializeDatabaseAsync()
        {
            try
            {
                await _connection.CreateTableAsync<Book>();
            }
            catch (Exception ex)
            {
                // Log error (replace with your preferred logging mechanism)
                Console.WriteLine($"Error initializing database: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            try
            {
                return await _connection.Table<Book>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error retrieving all books: {ex.Message}");
                throw;
            }
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            try
            {
                return await _connection.FindAsync<Book>(id);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error retrieving book by ID: {ex.Message}");
                throw;
            }
        }

        public async Task CreateBookAsync(Book book)
        {
            try
            {
                await _connection.InsertAsync(book);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error creating book: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                await _connection.UpdateAsync(book);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error updating book: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteBookAsync(Book book)
        {
            try
            {
                await _connection.DeleteAsync(book);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error deleting book: {ex.Message}");
                throw;
            }
        }

        // Dispose to clean up resources
        public void Dispose()
        {
            _connection.CloseAsync().Wait();
        }
    }
}
