using System;
using MoneyCount.app.core.console.services;

namespace MoneyCount.app.core.console
{
    public class Handler
    {
        public void Start()
        {
            bool active = true;

            do
            {
                Write(TemplateBuilder.GetTemplate());
                int chosenOption = GetUserInput();
                
                switch (chosenOption)
                {
                    case 0:
                        active = false;
                        
                        break;
                    case 404:

                        break;
                    default:
                        ApplicationState.Handle(chosenOption);
                        
                        break;
                }
                Console.Clear();
            } while (active);
        }

        private int GetUserInput()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                TemplateBuilder.AddArgument("message", "Wrong option!");
                TemplateBuilder.RebuildCurrentTemplate();
            }

            return 404;
        }
        
        public static void Write(string message)
        {
            Console.WriteLine(message);
        }

        public static void Write(string message, ConsoleColor colorToDisplay)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = colorToDisplay;
            Console.WriteLine(message);

            Console.ForegroundColor = defaultColor;
        }

        public static object Read()
        {
            return Console.ReadLine();
        }
    }
}