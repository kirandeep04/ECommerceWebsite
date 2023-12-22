namespace E_Commerce_Website.API.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Createdon { get; set; }

    public int Createdby { get; set; }

    public DateTime Updatedon { get; set; }

    public int Updatedby { get; set; }

    public bool Isactive { get; set; }

    public virtual UserLogin CreatedbyNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual UserLogin UpdatedbyNavigation { get; set; } = null!;
}
