using SQLite;
using System.ComponentModel.DataAnnotations;
using ColumnAttribute = SQLite.ColumnAttribute;


namespace MauiBooks.Models
{
    
    public class Book
    {
        [PrimaryKey]
        [Column("id")]
        [Required]
        public Guid Id { get; set; } = new Guid();

        [Column("title")]
        [Required]
        public string Title { get; set; }

        [Column("decription")]
        [Required]
        public string Description { get; set; }

        [Column("author")]
        [Required]
        public string Author { get; set; }

        [Column("img")]
        [Required]
        public string ImgUrl { get; set; }  

        //public Book(int id, string title, string description, string author, string imgUrl) 
        //{
        //    this.Id = id; 
        //    this.Title = title; 
        //    this.Description = description; 
        //    this.Author = author;
        //    this.ImgUrl = imgUrl;
        //}
    }
}
