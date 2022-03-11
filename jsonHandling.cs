namespace TimeKeeper.jsonHandling
{
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
static class jsonHandling{

    public static users.userList importJson(String pathToFile)
    {
        string jsonString = File.ReadAllText(pathToFile);
        users.userList? ul = JsonSerializer.Deserialize<users.userList>(jsonString);
        if(ul != null){
            return ul;
        }
        else{
            ul = new users.userList();
            return ul;
        }
    }

    public static void exportJson(users.userList ul)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string exported = JsonSerializer.Serialize(ul.getMainList(), options);
        Console.WriteLine(exported);
    }
}
}
