using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBooks.Models
{
    internal class Book
    { 
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Author { get; set; } 
        public string ImgUrl { get; set; }  

        public Book(int id, string title, string description, string author, string imgUrl) 
        {
            this.Id = id; 
            this.Title = title; 
            this.Description = description; 
            this.Author = author;
            this.ImgUrl = imgUrl;
        }
    }
}
