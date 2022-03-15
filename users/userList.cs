namespace TimeKeeper.users
{
class userList
{
    public Dictionary<int, Person>? mainList {get; set;}

    // Paramterless constructer for use with deserialize and serialize
    public userList() {}
    
    public void setMainList(Dictionary<int, Person> newList){
        this.mainList = newList;
    }

    public void addPerson(String fName,  String lName, int id, double hours, bool mentor, bool isLoggedIn){
        if (this.mainList == null)
        {
            this.mainList = new Dictionary<int, Person>();
        }
        Person _person = new Person(fName, lName, id, hours, mentor, isLoggedIn);
        this.mainList.Add(id, _person);
    }

    public void addPerson(Person _person){
        if (this.mainList == null)
        {
            this.mainList = new Dictionary<int, Person>();
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
        if (this.mainList == null)
        {
            throw new Exception("User List is Null");
        }
        return this.mainList[id];
    }

    public void loginPerson(int id){
        if (this.mainList != null)
        {
            this.mainList[id].lastLoginTime = DateTime.Now;
            this.mainList[id].isLoggedIn = true;
        }
        else
        {
            throw new Exception("User List is null");
        }
    }

    public void logoutPerson(int id)
    {
        if (this.mainList != null)
        {   
            if (mainList[id].isLoggedIn)
            {
                DateTime startTime = this.mainList[id].lastLoginTime;
                DateTime endTime = DateTime.Now;

                TimeSpan elapsed = endTime.Subtract(startTime);

                this.mainList[id].hours = elapsed.TotalHours;

                this.mainList[id].isLoggedIn = false;
            }
            else 
            {
                Console.WriteLine("User Is not logged in.");
            }
        }
        else
        {
            throw new Exception("User List is null");
        }
    }

    public void clearPersonHours(int id)
    {
        if (this.mainList != null && this.mainList.ContainsKey(id))
        {
            this.mainList[id].hours = 0;
        }
        else
        {
            throw new Exception("User List is null");
        }
    }

    public double getPersonHours(int id)
    {
        if ( this.mainList != null && this.mainList.ContainsKey(id))
        {
            return this.mainList[id].hours;
        }
        else
        {
            throw new Exception("User List is null");
        }
        //return 0;
    }

    public void clearAllHours()
    {
        if (this.mainList != null)
        {
            foreach (KeyValuePair<int, Person> p in this.mainList)
            {
                p.Value.hours = 0;
            }
        }
        else
        {
            throw new Exception("User List is null");
        }
    }

    public Dictionary<int, Person> getMainList()
    {
        if (this.mainList != null)
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