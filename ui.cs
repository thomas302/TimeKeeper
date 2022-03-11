namespace TimeKeeper.ui
{
using u = users;
using jsh = jsonHandling;
class loop{
    bool updateState = false;
    String? mode;

    public u.userList? ul;

    public loop() {

        ul = null;
        if (File.Exists(".\\userList.json")){
            ul = jsh.serializer.Deserialize(".\\userList.json");
        }

        if (ul == null){
            ul = new u.userList();
        }


    }

    public void main()
    {
        switch (this.mode){
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
            this.mode = Console.ReadLine();
        }
    }

    public void run()
    {   
        printMainMenu();
        this.mode = Console.ReadLine();

        while (true)
        {   
            main();
        }
    }

    public void addUser()
    {   
        if (this.ul == null){
            throw new Exception("User List Is Null");
        }
        
        bool isUserInputValid = true;
        bool mentor = false;

        Console.Clear();
        Console.WriteLine(6);

        Console.WriteLine("First Name: ");
        String? fName = Console.ReadLine();
        if (fName == null){
            isUserInputValid = false;
            Console.WriteLine("You Must Enter A First Name.");
        }

        Console.WriteLine("Last Name: ");
        String? lName = Console.ReadLine();
        if (lName == null){
            isUserInputValid = false;
            Console.WriteLine("You Must Enter A Last Name.");
        }

        Console.WriteLine("Enter An ID Number (It must be an integer): ");
        String? id_s = Console.ReadLine();
        int id;
        if (!int.TryParse(id_s, out id))
        {
            Console.WriteLine("Invalid ID");
            isUserInputValid = false;
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
            Console.WriteLine("Invalid Input");
            isUserInputValid = false;
        }

        // The extra check of fName and lName for null is redundant, but avoids a compilation warning.
        if (isUserInputValid && fName != null && lName != null)
        {
            u.Person _person = new u.Person(fName, lName, id, 0, mentor, false);
            ul.addPerson(_person);
            this.updateState = true;
        }
        else 
        {
            updateState = false;
        }
    }

    public void rmUser()
    {
        if (this.ul == null){
            throw new Exception("User list is null");
        }
        Console.Clear();
        Console.WriteLine(7);

        Console.WriteLine("Enter an Id To remove or c to cancel");
        String? id_s = Console.ReadLine();
        int id;

        if (int.TryParse(id_s, out id)){
            this.ul.rmPerson(id);
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
        if (this.ul == null){
            throw new Exception("User list is null");
        }
        Console.Clear();
        Console.WriteLine(1);

        Console.WriteLine("Enter an Id to login/out or c to cancel");
        String? id_s = Console.ReadLine();
        int id;
        if (int.TryParse(id_s, out id)){
            if(this.ul.getPerson(id).isLoggedIn)
            {
                this.ul.logoutPerson(id);
            }
            else
            {
                this.ul.loginPerson(id);
            }
            updateState = true;
        }
        else if (id_s == "c")
        {
            updateState = true;
        }
        else
        {
            Console.WriteLine("Please Enter a c input");
        }
    }

    public void getUserHours()
    {
        Console.Clear();
        Console.WriteLine(2);
        updateState = true;
    }

    public void getUserList()
    {
        Console.Clear();
        Console.WriteLine(3);
        updateState = true;
    }

    public void logOutAll()
    {
        Console.Clear();
        Console.WriteLine(5);
        updateState = true;
    }

    public void displayAllUsersHours()
    {
        if (this.ul == null){
            throw new Exception("User List Is Null");
        }
        Console.Clear();
        Console.WriteLine(4);
        foreach(KeyValuePair<int, u.Person> p in this.ul.getMainList())
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
        Console.WriteLine("    (q) Exit and Logout All");
    }

    void saveUserList(String? path = null){
        if (this.ul == null){
            throw new Exception("User List Is Null");
        }

        if (path == null){
            path = ".\\";
        }
        jsh.serializer.Serialize(this.ul, path);
    }
}
}