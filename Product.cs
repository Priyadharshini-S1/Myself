using System.ComponentModel.DataAnnotations;

namespace product.Models
{
    public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Author {get; set;}

    public int Edition {get; set;}

   

    public byte[]? RowVer { get; set;}
}

}