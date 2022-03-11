namespace TimeKeeper.jsonHandling
{
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
static class importExport{
    public static users.userList? importJson(String? pathToFile=null)
    {
        users.userList? ml;
        string jsonString = File.ReadAllText("userList.json");
        Console.WriteLine(jsonString);
        
        ml = JsonSerializer.Deserialize<users.userList> (jsonString);

        return ml;
    }

    public static void exportJson(users.userList ul, String pathToFile)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string exported = JsonSerializer.Serialize(ul, options);
        Console.WriteLine(exported);

        File.WriteAllText( pathToFile + "userList.json", exported);


    }
}
}
