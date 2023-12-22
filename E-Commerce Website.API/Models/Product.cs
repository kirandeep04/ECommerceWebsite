namespace E_Commerce_Website.API.Models;

public partial class Product
{
    public int Productid { get; set; }

    public int Categoryid { get; set; }

    public string Description { get; set; } = null!;

    public byte[] Image { get; set; } = null!;

    public DateTime Createdon { get; set; }

    public int Createdby { get; set; }

    public DateTime Updatedon { get; set; }

    public int Updatedby { get; set; }

    public bool Isactive { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual UserLogin CreatedbyNavigation { get; set; } = null!;

    public virtual UserLogin UpdatedbyNavigation { get; set; } = null!;
}
