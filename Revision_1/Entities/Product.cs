namespace Revision_1.Entities;

public class Product
{
    private String name , id , description;
    private decimal price;

    public Product( String _name , String _id , String _description , decimal _price ) {
        this.name = _name;
        this.id = _id;
        this.description = _description;
        this.price = _price;
    }
    public String getName() { return name; }
    public String getId() { return id; }
    public String getDescription() { return description; }
    public decimal getPrice() { return price; }
    public void setPrice( decimal _price ) { price = _price; }
    public void setName( String _name ) { name = _name; }
    public void setDescription( String _description ) { description = _description; }
    public void setId ( String _id ) { id = _id; }
}