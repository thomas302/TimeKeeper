namespace TimeKeeper.users
{
using System;
class Person{
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
}

class userList
{
    public Dictionary<int, Person>? mainList {get; set;}

    public userList()
    {
    }
    

    public void setMainList(Dictionary<int, Person> newList){
        this.mainList = newList;
    }

    public void addPerson(String fName,  String lName, int id, double hours, bool mentor, bool isLoggedIn){
        if (mainList == null)
        {
            mainList = new Dictionary<int, Person>();
        }
        Person _person = new Person(fName, lName, id, hours, mentor, isLoggedIn);
        this.mainList.Add(id, _person);
    }

    public void addPerson(Person _person){
        if (mainList == null)
        {
            mainList = new Dictionary<int, Person>();
        }
        //Person _person = new Person(fName, lName, id, hours, mentor, isLoggedIn);
        this.mainList.Add(_person.id, _person);
    }

    public void rmPerson(int id)
    {   
        if (this.mainList != null)
        {
            this.mainList.Remove(id);
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public Person getPerson(int id)
    {
        if (mainList == null){
            throw new Exception("User List is Null");
        }
        return this.mainList[id];
    }

    public void loginPerson(int id){
        if (mainList != null)
        {
            mainList[id].lastLoginTime = DateTime.Now;
            mainList[id].isLoggedIn = true;
        }
        else
        {
            throw new Exception("User List is null");
        }
    }

    public void logoutPerson(int id)
    {
        if (mainList != null)
        {   
            DateTime startTime = mainList[id].lastLoginTime;
            DateTime endTime = DateTime.Now;

            TimeSpan elapsed = endTime.Subtract(startTime);

            mainList[id].hours = elapsed.TotalHours;

            mainList[id].isLoggedIn = false;
            
        }
        else
        {
            throw new Exception("User List is null");
        }
    }

    public double getPersonHours(int id)
    {
        if (mainList != null)
        {
            return this.mainList[id].hours;
        }
        else
        {
            throw new Exception("User List is null");
        }
        //return 0;
    }

    public Dictionary<int, Person> getMainList()
    {
        if (mainList != null)
        {
            return this.mainList;
        }
        else
        {
            throw new Exception("User List is null");
        }  
    }
}

}