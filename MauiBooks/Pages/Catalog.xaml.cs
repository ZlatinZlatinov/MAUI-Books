using MauiBooks.Models;

namespace MauiBooks.Pages;

public partial class Catalog : ContentPage
{

    private readonly LocalDbService _dbService;
    private List<Book> books;
    public Catalog(LocalDbService localDbService)
    {
        InitializeComponent();
        _dbService = localDbService;
       LoadBooks();
    } 

    public void LoadBooks()
    {
        Task.Run(async () => booksCollection.ItemsSource = (System.Collections.IEnumerable)_dbService.GetAllBooksAsync());
    }
}