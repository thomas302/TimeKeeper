namespace TimeKeeper.jsonHandling
{
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
static class jsonHandling{

    public static void importJson()
    {

    }

    public static void exportJson(users.userList ul)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string exported = JsonSerializer.Serialize(ul.getMainList(), options);
        Console.WriteLine(exported);
    }
}
}
