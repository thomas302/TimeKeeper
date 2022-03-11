namespace TimeKeeper.users
{
using System;
class Person{
    public String? firstName {get; set;}
    public String? lastName {get; set;}
    public int id {get; set;}
    public double hours {get; set;}
    public DateTime lastLoginTime {get; set;}
    public bool mentor {get; set;} 
    public bool isLoggedIn{get; set;}

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
    public Dictionary<int, Person> mainList;

    public userList(){
        this.mainList = new Dictionary<int, Person>();
    }

    public userList(Dictionary<int, Person> mainList)
    {
        this.mainList = mainList;
    }

    public void addPerson(String fName,  String lName, int id, double hours, bool mentor, bool isLoggedIn){
        Person _person = new Person(fName, lName, id, hours, mentor, isLoggedIn);
        this.mainList.Add(id, _person);
    }

    public void addPerson(Person _person){
        //Person _person = new Person(fName, lName, id, hours, mentor, isLoggedIn);
        this.mainList.Add(_person.id, _person);
    }

    public void loginPerson(int id){
        mainList[id].lastLoginTime = DateTime.Now;
    }

    public double getPersonHours(int id)
    {
        return this.mainList[id].hours;
        //return 0;
    }

    public Dictionary<int, Person> getMainList()
    {
        return this.mainList;
    }
}

}