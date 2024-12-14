using MauiBooks.Models;
using SQLite;

namespace MauiBooks
{
    internal class LocalDbService
    {
        private const string DB_NAME = "demo_local_db.db3"; 
        private readonly SQLiteAsyncConnection _connection; 

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Book>();
        } 

        public async Task<List<Book>> GetAllBooks()
        {
            return await _connection.Table<Book>().ToListAsync();
        } 

        public async Task<Book> GetById(Guid id)
        {
            return await _connection.Table<Book>().Where(x => x.Id == id).FirstOrDefaultAsync();
        } 

        public async void Create(Book book)
        {
            await _connection.CreateTableAsync<Book>();
        }

        public async void Update(Book book)
        { 
            await _connection.UpdateAsync(book);
        }

        public async void Delete(Book book)
        { 
            await _connection.DeleteAsync(book);
        }
    }
}
