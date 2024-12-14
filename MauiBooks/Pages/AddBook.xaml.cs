using MauiBooks.Models;
using MauiBooks;

namespace MauiBooks.Pages;

public partial class AddBook : ContentPage
{
    private LocalDbService _localDbService;

    public AddBook(LocalDbService localDbService)
    {
        InitializeComponent();
        _localDbService = localDbService;
    }

    private async Task SaveBook_Clicked()
    {
        try
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(title.Text) || string.IsNullOrWhiteSpace(author.Text))
            {
                await DisplayAlert("Validation Error", "Title and Author are required fields.", "OK");
                return;
            }

            // Collect book details
            string title1 = title.Text.Trim();
            string desc = description.Text?.Trim();
            string img = imgUrl.Text?.Trim();
            string auth = author.Text.Trim();

            // Create and save the book
            var newBook = new Book
            {
                Title = title1,
                Description = desc,
                ImgUrl = img,
                Author = auth
            };

            await _localDbService.CreateBookAsync(newBook);

            // Provide user feedback
            await DisplayAlert("Success", "Book added successfully.", "OK");
            await Shell.Current.GoToAsync("//catalog");
            // Optionally clear the form
            title.Text = string.Empty;
            description.Text = string.Empty;
            imgUrl.Text = string.Empty;
            author.Text = string.Empty;
        }
        catch (Exception ex)
        {
            // Handle errors gracefully
            await DisplayAlert("Error", $"An error occurred while saving the book: {ex.Message}", "OK");
        }
    }

    private void saveBook_Clicked_2(object sender, EventArgs e)
    {
        _ = SaveBook_Clicked();
    }

    //    private void saveBook_Clicked_1(object sender, EventArgs e)
    //    {

    //    }
    //} 
}
