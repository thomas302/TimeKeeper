namespace TimeKeeper.tui
{
using u = users;
using jsh = jsonHandling;
class loop{
    bool updateState = false;
    String? mode;

    public u.userList? ul;

    public loop(FileInfo path) {
        ul = null;
        if (File.Exists(path.ToString())){
            ul = jsh.serializer.Deserialize(path.ToString());
        }

        if (ul == null){
            ul = new u.userList();
        }


    }

    public void main()
    {
        switch (mode){
            case "1":
            case "(1)":
                login_logout();
                break;
            
            case "2":
            case "(2)":
                getUserHours();
                break;

            case "3":
            case "(3)":
                getUserList();
                break;

            case "4":
            case "(4)":
                displayAllUsersHours();
                break;

            case "5":
            case "(5)":
                logOutAll();
                break;

            case "6":
            case "(6)":
                addUser();
                break;

            case "7":
            case "(7)":
                rmUser();
                break;

            case "8":
                saveUserList();
                updateState = true;
                break;

            case "q":
            case "Q":
                Console.Clear();
                Console.WriteLine("exit");
                logOutAll();
                saveUserList();
                System.Environment.Exit(0);
                break;
            
            default:
                Console.WriteLine("Invalid Input, please try again");
                updateState = true;
                break;

        }

        if (updateState){
            continue_on_key();
            Console.Clear();
            printMainMenu();
            mode = Console.ReadLine();
        }
    }

    public void run()
    {   
        printMainMenu();
        mode = Console.ReadLine();
        updateState = false;

        while (true)
        {   
            try
            {
            main();
            }
            catch (Exception ex) when (ex is u.exceptions.InvalidInput || ex is ArgumentException || ex is u.exceptions.InvalidLoginState)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    void continue_on_key()
    {
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
    }

    void printMainMenu()
    {
        Console.WriteLine("Choose a mode:");
        Console.WriteLine("    (1) Log User In\\Out");
        Console.WriteLine("    (2) Get User Hours");
        Console.WriteLine("    (3) Get User List");
        Console.WriteLine("    (4) Get All Hours");
        Console.WriteLine("    (5) Logout All");
        Console.WriteLine("    (6) Add User");
        Console.WriteLine("    (7) Remove User");
        Console.WriteLine("    (8) Save User List");
        Console.WriteLine("    (q) Exit and Logout All");
    }

    public void addUser()
    {   
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");
        
        bool mentor = false;

        Console.Clear();
        Console.WriteLine(6);

        Console.WriteLine("First Name: ");
        String? fName = Console.ReadLine();

        if (fName == null)
        {
            updateState = false;
            throw new users.exceptions.InvalidInput("Invalid ID");
        }

        Console.WriteLine("Last Name: ");
        String? lName = Console.ReadLine();
        if (lName == null){
            throw new users.exceptions.InvalidInput("Invalid ID");
        }

        Console.WriteLine("Enter An ID Number (It must be an integer): ");
        String? id_s = Console.ReadLine();
        int id;
        if (!int.TryParse(id_s, out id))
        {
            updateState = false;
            throw new users.exceptions.InvalidInput("Invalid ID");
        }

        Console.WriteLine("Are You A Mentor? Yes (y) Or No (n)");
        String? m = Console.ReadLine();

        if (m == "y" || m == "Y")
        {
            mentor = true;
        } 
        else if (m == "n"|| m == "N")
        {
            mentor = false;
        }
        else{
            updateState = false;
            throw new users.exceptions.InvalidInput("Invalid ID");
        }

        u.Person _person = new u.Person(fName, lName, id, 0, mentor, false);
        ul.addPerson(_person);
        updateState = true;
    }

    public void rmUser()
    {
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");

        Console.Clear();
        Console.WriteLine(7);

        Console.WriteLine("Enter an Id To remove or c to cancel");
        String? id_s = Console.ReadLine();
        int id;

        if (int.TryParse(id_s, out id)){
            ul.rmPerson(id);
            updateState = true;
        }
        else if (id_s == "c")
        {
            updateState = true;
        }
        else
        {
            Console.WriteLine("Please Enter a Valid Command");
        }
    }

    public void login_logout()
    {
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");

        Console.Clear();
        Console.WriteLine(1);

        Console.WriteLine("Enter an Id to login/out or c to cancel");
        String? id_s = Console.ReadLine();
        int id;
        if (int.TryParse(id_s, out id)){
            if(ul.getPerson(id).isLoggedIn)
            {
                ul.logoutPerson(id);
                Console.WriteLine("User: {0}: {1} {2} is {3}", id, 
                    ul.getPerson(id).firstName, ul.getPerson(id).lastName, 
                    ul.getPerson(id).isLoggedIn ? "Logged In" : "Logged Out");
            }
            else
            {
                ul.loginPerson(id);
                Console.WriteLine("User: {0}: {1} {2} is {3}", id, 
                    ul.getPerson(id).firstName, ul.getPerson(id).lastName, 
                    ul.getPerson(id).isLoggedIn ? "Logged In" : "Logged Out");
            }
            updateState = true;
        }
        else if (id_s == "c")
        {
            updateState = true;
        }
        else
        {
            Console.WriteLine("Please Enter a valid input");
        }
    }

    public void getUserHours()
    {
        Console.Clear();
        Console.WriteLine(2);
        Console.WriteLine("Please Enter an ID");
        String? id_s = Console.ReadLine();
        int id;

        if (ul != null)
        {   
            
            if (int.TryParse(id_s, out id))
            {
                u.Person _person;
                _person = ul.getPerson(id);

                Console.WriteLine("Name: {0}, {1}", _person.firstName, _person.lastName);
                Console.WriteLine("Hours: {0}", _person.hours);
                updateState = true;
            }
            else
            {
                throw new u.exceptions.InvalidInput("Invalid Input, input should be an integer.");
            }
        }
    }

    public void getUserList()
    {
        Console.Clear();
        Console.WriteLine(3);
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");
        
        foreach(KeyValuePair<int, u.Person> p in ul.getMainList())
        {
            p.Value.print();
            Console.WriteLine();
        }
        
        updateState = true;
    }

    public void logOutAll()
    {
        Console.Clear();
        Console.WriteLine(5);
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");

        foreach (KeyValuePair<int, u.Person> p in ul.getMainList())
        {
            // if user is logged in, log user out
            if (p.Value.isLoggedIn)
                ul.logoutPerson(p.Key);
        }
        updateState = true;
    }

    public void displayAllUsersHours()
    {
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");
        
        Console.Clear();
        Console.WriteLine(4);

        foreach(KeyValuePair<int, u.Person> p in ul.getMainList())
        {
            int id = p.Key;
            Console.Write(p.Value.firstName);
            Console.Write(" ");
            Console.WriteLine(p.Value.lastName);
            Console.Write("Hours: ");
            Console.WriteLine(p.Value.hours);
            Console.WriteLine();
        }
        updateState = true;
    }

    void saveUserList(String? path = null){
        if(ul == null)
            throw new users.exceptions.NullMainList("Main List Is Null");

        if (path == null){
            path = ".\\";
        }
        jsh.serializer.Serialize(ul, path);
    }
}
}