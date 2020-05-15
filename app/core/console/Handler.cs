using System;

namespace MoneyCount.app.core.console
{
    public class Handler
    {
        public void Start()
        {
            bool active = true;

            do
            {
                Console.WriteLine(TemplateBuilder.GetTemplate());
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
    }
}