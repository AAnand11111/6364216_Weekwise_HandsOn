public class SearchDemo
{
    public static Product LinearSearch(Product[] products, int id)
    {
        foreach (var product in products)
        {
            if (product.ProductId == id)
                return product;
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, int id)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (products[mid].ProductId == id)
                return products[mid];
            else if (products[mid].ProductId < id)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }
}
