using System;
using System.Collections.Generic;

class GeoCode{
    public long Lattitude;
    public long Longitude;

    public GeoCode()
    {
        Random rnd = new Random();
        Lattitude = rnd.Next();
        Longitude = rnd.Next();
    }
}

class Address{
    public int AddressId;
    public string Street;
    public string City;
    public string Zipcode;
    public GeoCode Geocode;
}

class Solution
{

    static void Main(string[] args)
    {
        //collection contains duplicate addresses - everything is same except AddressID
        Address[] addresses = new Address[] {
            new Address { AddressId = 1, Street = "123 Main", City = "Los Angeles", Zipcode = "90025" },
            new Address { AddressId = 2, Street = "456 1st Ave", City = "Santa Monica", Zipcode = "90401" },
            new Address { AddressId = 3, Street = "789 A Street", City = "San Francisco", Zipcode = "94086" },
            new Address { AddressId = 4, Street = "123 Main", City = "Santa Monica", Zipcode = "90401" },
            new Address { AddressId = 5, Street = "123 Main", City = "Los Angeles", Zipcode = "90025" },
            new Address { AddressId = 6, Street = "123 Main", City = "Santa Monica", Zipcode = "90401" },
        };

        PopulateGeoCode(addresses);
        foreach(var a in addresses)
        {
            Console.WriteLine($"Geocode for Address Id {a.AddressId.ToString()}: {a.Geocode?.Lattitude.ToString()} {a.Geocode?.Longitude.ToString()}");
        }
    }

    //expensive call - $1 / address
    static GeoCode GetGeoCode(Address addr){
        Console.WriteLine($"Expensive call to get geocode for {addr.Street}");
        return new GeoCode();
    }
    
    
    static void PopulateGeoCode(Address[] addresses){
        // write cost-efficient method to populate geocodes
        Dictionary<String, GeoCode> addressDict = new Dictionary<String, GeoCode>();
        foreach (var address in addresses){
            string addressKey = $"{address.Street}|{address.City}|{address.Zipcode}"; 
            if(!addressDict.ContainsKey(addressKey)){
                var geoCode = GetGeoCode(address);
                addressDict[addressKey] = geoCode;
            }
            address.Geocode = addressDict[addressKey];
        }
        
    }
}
