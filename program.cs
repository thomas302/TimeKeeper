namespace TimeKeeper
{
    using jsh = jsonHandling;
    using System;
    using ui;

    
    class program
    {
        static void Main()
        {   
            ui.loop mainUI = new ui.loop();

            mainUI.run();
        }
    }
}