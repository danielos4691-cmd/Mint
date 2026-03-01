using System;
using System.Threading;

class Mint
{
    static bool calcInstalled = false;
    static bool tttInstalled = false;
    static bool guessInstalled = false;
    static bool terminalPolish = false;
    static bool proVersion = false;
    static string author = "On Mint";
    static Random rand = new Random();

    static void Main()
    {
        StartSystem();
    }

    // ================= START SYSTEM =================
    static void StartSystem()
    {
        calcInstalled = false;
        tttInstalled = false;
        guessInstalled = false;
        terminalPolish = false;

        Console.Title = "Mint OS";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        ShowBootScreen();
        MainMenu();
    }

    // ================= LOGO =================
    static void ShowBootScreen()
    {
        Console.Clear();
        Console.WriteLine("\n");
        Console.WriteLine("                ---===---");
        Console.WriteLine(@"
███╗   ███╗██╗███╗   ██╗████████╗
████╗ ████║██║████╗  ██║╚══██╔══╝
██╔████╔██║██║██╔██╗ ██║   ██║
██║╚██╔╝██║██║██║╚██╗██║   ██║
██║ ╚═╝ ██║██║██║ ╚████║   ██║
╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝   ╚═╝
");
        Console.WriteLine("                ---===---\n");
        Thread.Sleep(600);
    }

    // ================= MAIN MENU =================
    static void MainMenu()
    {
        while (true)
        {
            Console.Write("Mint> ");
            string cmd = Console.ReadLine().ToLower();

            if (cmd == "help")
            {
                Console.WriteLine("help");
                Console.WriteLine("boot");
            }
            else if (cmd == "boot")
            {
                BootMenu();
            }
        }
    }

    // ================= BOOT MENU =================
    static void BootMenu()
    {
        FullScreenDigits(6);

        while (true)
        {
            Console.Write("BOOT> ");
            string cmd = Console.ReadLine().ToLower();

            switch (cmd)
            {
                case "help":
                    Console.WriteLine("S-install");
                    Console.WriteLine("S-try");
                    Console.WriteLine("B-do");
                    Console.WriteLine("term");
                    Console.WriteLine("about");
                    Console.WriteLine("matrix");
                    Console.WriteLine("loader");
                    Console.WriteLine("exit");
                    break;

                case "s-install":
                    InstallMenu();
                    break;

                case "s-try":
                    FullScreenDigits(10);
                    break;

                case "b-do":
                    BootDoMenu();
                    break;

                case "term":
                    Terminal();
                    break;

                case "about":
                    if (proVersion)
                        Console.WriteLine($"Mint Pro Version\nAuthor: {author}");
                    else
                        Console.WriteLine("Mint 1.0 Base Version\nAuthor: On Mint");
                    break;

                case "matrix":
                    MatrixEffect(20);
                    break;

                case "loader":
                    LoaderEffect();
                    break;

                case "exit":
                    return;
            }
        }
    }

    // ================= S-INSTALL MENU =================
    static void InstallMenu()
    {
        while (true)
        {
            Console.Write("S-INSTALL> ");
            string cmd = Console.ReadLine().ToLower();

            switch (cmd)
            {
                case "help":
                    Console.WriteLine("calc");
                    Console.WriteLine("ttt");
                    Console.WriteLine("guess");
                    Console.WriteLine("more");
                    Console.WriteLine("exit");
                    break;

                case "calc":
                    calcInstalled = true;
                    Calculator();
                    break;

                case "ttt":
                    tttInstalled = true;
                    TicTacToe();
                    break;

                case "guess":
                    guessInstalled = true;
                    GuessGame();
                    break;

                case "more":
                    Console.WriteLine("Extra features enabled");
                    break;

                case "exit":
                    return;
            }
        }
    }

    // ================= B-DO MENU =================
    static void BootDoMenu()
    {
        while (true)
        {
            Console.Write("B-DO> ");
            string cmd = Console.ReadLine().ToLower();

            switch (cmd)
            {
                case "help":
                    Console.WriteLine("restart");
                    Console.WriteLine("delete-calc");
                    Console.WriteLine("delete-ttt");
                    Console.WriteLine("delete-guess");
                    Console.WriteLine("delete-system");
                    Console.WriteLine("recompile");
                    Console.WriteLine("exit");
                    break;

                case "restart":
                    ShowBootScreen();
                    return;

                case "delete-calc":
                    calcInstalled = false;
                    Console.WriteLine("Calculator deleted.");
                    break;

                case "delete-ttt":
                    tttInstalled = false;
                    Console.WriteLine("TicTacToe deleted.");
                    break;

                case "delete-guess":
                    guessInstalled = false;
                    Console.WriteLine("Guess game deleted.");
                    break;

                case "delete-system":
                    Environment.Exit(0);
                    break;

                case "recompile":
                    FullScreenDigits(20);
                    StartSystem(); // reset system and all apps
                    return;

                case "exit":
                    return;
            }
        }
    }

    // ================= TERMINAL =================
    static void Terminal()
    {
        Console.WriteLine("Entering terminal. Type 'help' for commands.");

        while (true)
        {
            Console.Write(terminalPolish ? "Terminal> " : "Terminal> ");
            string cmd = Console.ReadLine().Trim().ToLower();

            if (terminalPolish)
            {
                if (cmd.StartsWith("echo ")) Console.WriteLine(cmd.Substring(5));
                else if (cmd == "echo") Console.WriteLine("Użycie: echo [tekst]");
                else if (cmd == "time") Console.WriteLine("Czas: " + DateTime.Now.ToLongTimeString());
                else if (cmd == "date") Console.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                else if (cmd == "rand") Console.WriteLine("Losowa liczba: " + rand.Next(0, 101));
                else if (cmd == "clear") Console.Clear();
                else if (cmd == "help")
                {
                    Console.WriteLine("echo [text] - wypisz tekst");
                    Console.WriteLine("time - pokaz czas");
                    Console.WriteLine("date - pokaz date");
                    Console.WriteLine("rand - losowa liczba 0-100");
                    Console.WriteLine("clear - wyczyść terminal");
                    Console.WriteLine("pl - pokaz 2 linie cyfr");
                    Console.WriteLine("en - switch back to English");
                    Console.WriteLine("start-version - show version info");
                    Console.WriteLine("recompile-pro - reset and activate Pro");
                    Console.WriteLine("pro-install - activate Pro version");
                    Console.WriteLine("exit - wyjście z terminala");
                }
                else if (cmd == "exit") break;
                else if (cmd == "pl") { FullScreenDigits(2); terminalPolish = true; }
                else if (cmd == "en") { terminalPolish = false; Console.WriteLine("Language: English"); }
                else if (cmd == "start-version") Console.WriteLine(proVersion ? "Pro Version" : "Base Version");
                else if (cmd == "recompile-pro") { FullScreenDigits(20); proVersion = true; author = "Drav1"; StartSystem(); return; }
                else if (cmd == "pro-install") { proVersion = true; author = "Drav1"; Console.WriteLine("Pro version activated."); }
                else Console.WriteLine("Nieznana komenda");
            }
            else
            {
                if (cmd.StartsWith("echo ")) Console.WriteLine(cmd.Substring(5));
                else if (cmd == "echo") Console.WriteLine("Usage: echo [text]");
                else if (cmd == "time") Console.WriteLine("Time: " + DateTime.Now.ToLongTimeString());
                else if (cmd == "date") Console.WriteLine("Date: " + DateTime.Now.ToShortDateString());
                else if (cmd == "rand") Console.WriteLine("Random number: " + rand.Next(0, 101));
                else if (cmd == "clear") Console.Clear();
                else if (cmd == "help")
                {
                    Console.WriteLine("echo [text] - print text");
                    Console.WriteLine("time - show time");
                    Console.WriteLine("date - show date");
                    Console.WriteLine("rand - random number 0-100");
                    Console.WriteLine("clear - clear terminal");
                    Console.WriteLine("pl - switch to Polish mode");
                    Console.WriteLine("en - switch to English mode");
                    Console.WriteLine("start-version - show version info");
                    Console.WriteLine("recompile-pro - reset and activate Pro");
                    Console.WriteLine("pro-install - activate Pro version");
                    Console.WriteLine("exit - exit terminal");
                }
                else if (cmd == "exit") break;
                else if (cmd == "pl") { FullScreenDigits(2); terminalPolish = true; }
                else if (cmd == "en") { terminalPolish = false; Console.WriteLine("Language: English"); }
                else if (cmd == "start-version") Console.WriteLine(proVersion ? "Pro Version" : "Base Version");
                else if (cmd == "recompile-pro") { FullScreenDigits(20); proVersion = true; author = "Drav1"; StartSystem(); return; }
                else if (cmd == "pro-install") { proVersion = true; author = "Drav1"; Console.WriteLine("Pro version activated."); }
                else Console.WriteLine("Unknown command");
            }
        }
    }

    // ================= FULLSCREEN DIGITS =================
    static void FullScreenDigits(int screens)
    {
        for (int s = 0; s < screens; s++)
        {
            Console.Clear();
            int w = Console.WindowWidth;
            int h = Console.WindowHeight;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                    Console.Write(rand.Next(10));
            }
            Thread.Sleep(100);
        }
        Console.Clear();
    }

    // ================= MATRIX EFFECT =================
    static void MatrixEffect(int screens)
    {
        for (int s = 0; s < screens; s++)
        {
            Console.Clear();
            int w = Console.WindowWidth;
            int h = Console.WindowHeight;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(rand.Next(10));
                }
            }
            Thread.Sleep(80);
        }
        Console.ResetColor();
        Console.Clear();
    }

    // ================= LOADER EFFECT =================
    static void LoaderEffect()
    {
        Console.Clear();
        Console.WriteLine("Loading...");
        for (int i = 0; i <= 100; i += 5)
        {
            Console.Write("\r[" + new string('#', i / 2) + new string(' ', 50 - i / 2) + $"] {i}%");
            Thread.Sleep(50);
        }
        Console.WriteLine("\nDone!");
    }

    // ================= CALCULATOR =================
    static void Calculator()
    {
        Console.WriteLine("Enter calculation, e.g. 5+3:");
        string input = Console.ReadLine();
        try
        {
            var dt = new System.Data.DataTable();
            Console.WriteLine("= " + dt.Compute(input, ""));
        }
        catch { Console.WriteLine("Error!"); }
    }

    // ================= GUESS GAME =================
    static void GuessGame()
    {
        int number = rand.Next(1, 21);
        Console.WriteLine("Guess a number from 1 to 20");
        while (true)
        {
            int g = int.Parse(Console.ReadLine());
            if (g == number) { Console.WriteLine("You win!"); break; }
            else Console.WriteLine(g < number ? "Higher" : "Lower");
        }
    }

    // ================= TIC TAC TOE =================
    static void TicTacToe()
    {
        string[] b = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string p = "X";
        for (int i = 0; i < 9; i++)
        {
            Console.Clear();
            Console.WriteLine($"{b[0]}|{b[1]}|{b[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{b[3]}|{b[4]}|{b[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{b[6]}|{b[7]}|{b[8]}");

            int m = int.Parse(Console.ReadLine()) - 1;
            if (b[m] == "X" || b[m] == "O") continue;
            b[m] = p;
            p = p == "X" ? "O" : "X";
        }
        Console.WriteLine("...");
    }
}

