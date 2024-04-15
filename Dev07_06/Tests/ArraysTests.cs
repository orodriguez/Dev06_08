namespace Tests;

public class ArraysTests
{
    [Fact]
    public void Static_Access()
    {
        // static array
        var a = new int[3];

        a[0] = 20;
        a[1] = 16;
        a[2] = 18;
        
        Assert.Equal(16, a[1]);
    }
    
    [Fact]
    public void Array_Initialization()
    {
        var a = new[] { 20, 16, 18 };
        
        Assert.Equal(16, a[1]);
    }
    
    [Fact]
    public void Dynamic_List()
    {
        var a = new List<string>
        {
            "a",
            "b"
        };
        
        // O(n)
        a.Add("c");
        
        Assert.Equal("c", a[2]);
    }
    
    [Fact]
    public void ListCapacity()
    {
        var a = new List<string>
        {
            "a",
            "b"
        };

        Assert.Equal(4, a.Capacity);
    }
    
    [Fact]
    public void ExceedCapacity()
    {
        var a = new List<string>(4)
        {
            "a",
            "b",
            "c",
            "d"
        };
        
        // O(n)
        a.Add("e");

        Assert.Equal(8, a.Capacity);
    }
    
    [Fact]
    public void First()
    {
        var a = new List<string>
        {
            "a",
            "b",
            "c",
            "d"
        };
        
        // O(n)
        var result = a.First(e => e == "c"); // LINQ

        Assert.Equal("c", result);
    }
    
    [Fact]
    public void RemoveAt()
    {
        var a = new List<string>
        {
            "a",
            "b",
            "c",
            "d"
        };
        
        // O(n)
        a.RemoveAt(2);

        Assert.Equal(new[] { "a", "b", "d"}, a);
    }
    
    [Fact]
    public void ExtensionMethods()
    {
        var a = new List<string>
        {
            "a",
            "b",
            "c",
            "d"
        };

        var result = a.BuildString();
        
        Assert.Equal("a,b,c,d", result);
    }
}

public static class MyArrayMethods
{
    public static string BuildString(this List<string> list) => 
        string.Join(",", list);
}