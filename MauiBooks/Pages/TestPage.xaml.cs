using MauiBooks.Models;

namespace MauiBooks.Pages;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		List<Book> books = new List<Book>
		{
			new Book(
				1, 
				"Star Wars: The Rise and Fall of the Galactic Empire", 
				"This is the story of how a tyrannical regime rose from the ashes of democracy, ruled the galaxy with an iron fist, and then collapsed into dust.", 
				"Крис Кемпшал",
                "https://cdn.ozone.bg/media/catalog/product/cache/1/image/400x498/a4e40ebdc3e371adff845072e1c73f37/s/t/a62abff9cb2a97a191b73a852d37c4cf/star-wars--the-rise-and-fall-of-the-galactic-empire-30.jpg"
			),
			new Book(
				2,
                "Star Wars Year by Year: A Visual History",
                "Discover everything you've ever wanted to know about Star Wars in this complete history of the most famous franchise in movie history.",
                "Колектив",
                "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/s/t/1da0d57097195c2e250381e42d05329e/star-wars-year-by-year--a-visual-history-new-edition-30.jpg"
            )
		};

		InitializeComponent();

        booksCollection.ItemsSource = books;

    }
}