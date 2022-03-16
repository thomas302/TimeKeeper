namespace TimeKeeper.users
{
using System;
class Person{
    /*
    This is a data class used to contain the data relavent to a given person.
    Its properties are all public so that it can be used with the c# Json serialize
    and deserialize methods.
    */

    // The {get; set;} makes it possible to serialize the person class
    // when the serialize method is called on the userList mainList.
    public String? firstName {get; set;}
    public String? lastName {get; set;}
    public int id {get; set;}
    public double hours {get; set;}
    public DateTime lastLoginTime {get; set;}
    public bool mentor {get; set;} 
    public bool isLoggedIn{get; set;}

    // This is neccessary for JSON import to work.  IDK why, but it is.  It seems like it has to do with
    // how values are set/it instantiates a class with an empty constructor when deserializing json.
    public Person(){}

    public Person(String fName,  String lName, int id, double hours, bool mentor, bool isLoggedIn)
    {
        this.firstName = fName;
        this.lastName = lName;
        this.id = id;
        this.hours = hours;
        this.mentor = mentor;
        this.isLoggedIn = isLoggedIn;
    }

    public void print()
    {
        Console.WriteLine("Name: {0} {1}", firstName, lastName);
        Console.WriteLine("Hours: {0}", hours);
        Console.WriteLine("Mentor: {0}", mentor ? "Yes" : "No");
        Console.WriteLine(isLoggedIn ? "Logged In" : "Logged out");
    }

    public void updateHours()
    {
        DateTime endTime = DateTime.Now;

        TimeSpan elapsed = endTime.Subtract(lastLoginTime);

        hours = elapsed.TotalHours;
    }
}
}