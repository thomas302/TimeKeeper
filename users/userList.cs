namespace TimeKeeper.users
{
using e = exceptions;
class userList
{
    public Dictionary<int, Person>? mainList {get; set;}

    // Paramterless constructer for use with deserialize and serialize
    public userList() {}
    
    public void setMainList(Dictionary<int, Person> newList)
    {
        mainList = newList;
    }

    public void addPerson(String fName,  String lName, int id, double hours, bool mentor, bool isLoggedIn){
        if (mainList == null)
        {
            mainList = new Dictionary<int, Person>();
        }

        Person _person = new Person(fName, lName, id, hours, mentor, isLoggedIn);
        mainList.Add(id, _person);
    }

    public void addPerson(Person _person){
        if (mainList == null)
        {
            mainList = new Dictionary<int, Person>();
        }
        
        mainList.Add(_person.id, _person);
    }

    public void rmPerson(int id)
    {   
        if (mainList != null)
        {
            if(mainList.ContainsKey(id)) 
            {
                mainList.Remove(id);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        else
        {
            throw new e.NullMainList("Cannot Remove User From Null Main List");
        }
    }

    public Person getPerson(int id)
    {
        if (mainList == null)
        {
            throw new e.NullMainList("Main List Is Null");
        }
        return mainList[id];
    }

    public void loginPerson(int id){
        if (mainList == null)
        {
            throw new e.NullMainList("Main List Is Null");
        }
        
        if(mainList.ContainsKey(id)) 
        {
            mainList[id].lastLoginTime = DateTime.Now;
            mainList[id].isLoggedIn = true;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void logoutPerson(int id)
    {
        if (mainList == null)
        {   
            throw new e.NullMainList("Main List Is Null");
        }

        if (mainList.ContainsKey(id))
        {
            if (mainList[id].isLoggedIn)
            {
                mainList[id].updateHours();
                mainList[id].isLoggedIn = false;
            }
            else 
            {
                throw new e.InvalidLoginState("User Is Not Logged In");
            }
        }
        else
        {
            throw new IndexOutOfRangeException("Id Is Not In Main List");
        }
    }

    public void clearPersonHours(int id)
    {
        if (mainList == null)
        {
            throw new e.NullMainList("Main List Is Null");
        }

        if (mainList.ContainsKey(id))
                mainList[id].hours = 0;
            else
                throw new e.InvalidInput("ID Is Not In Main List");
    }

    public double getPersonHours(int id)
    {
        if ( mainList == null)
        {
            throw new e.NullMainList("Main List Is Null");
        }

        if (mainList.ContainsKey(id))
            return mainList[id].hours;
        else
            throw new IndexOutOfRangeException("ID Is Not In Main List");
        //return 0;
    }

    public void clearAllHours()
    {
        if (mainList == null)
        {
            throw new e.NullMainList("Main List Is Null");
        }
        
        foreach (KeyValuePair<int, Person> p in mainList)
            {
                p.Value.hours = 0;
            }
    }

    public Dictionary<int, Person> getMainList()
    {
        if (mainList == null)
        {
            throw new e.NullMainList("Main List Is Null");
        }
        return mainList;
    }
}
}