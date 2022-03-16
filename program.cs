namespace TimeKeeper
{
    using System;
    using System.CommandLine;
    using System.CommandLine.DragonFruit;
    class program
    {
        /// <param name="tui">Set this flag to invoke the TUI, defaults to false Cannot be invoked with the GUI flag.</param>
        /// <param name="gui">Set this flag to invoke the GUI, defaults to true. Cannot be invoked with the TUI flag.</param>
        /// <param name="path">An optional path to the userList.json dile</param>
        static void Main(bool tui = false, bool gui = true, FileInfo? path=null)
        {   
            if(path == null) path = new FileInfo(".\\userList.json");

            if(tui && !gui) startTui(path);
            if(gui) startGui(path);
        }

        static void startTui(FileInfo path)
        {
            tui.loop mainUI = new tui.loop(path);
            mainUI.run();
        }

        static void startGui(FileInfo path)
        {

        }
    }
}