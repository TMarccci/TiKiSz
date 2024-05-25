using System.Diagnostics;

namespace Rise_of_Derma.providers
{
    public class Name
    {
        public void Set()
        {
            // Print debug
            Debug.WriteLine("Getting Name Sequence initalized");

            // First get config
            Config config = new Config();

            // Get name from config, if null than get the name from user
            if (config.UserName == "") 
            {
                String nev = "";
                while (nev == "" || nev == " ")
                {
                    // Get the name with function
                    nev = GetUserName();

                    // If not blocked names than set it
                    if (nev != "" || nev != " ")
                    {
                        config.setConfig("UserName", nev);
                    }

                    Console.Clear();
                };
            }
        }

        private String GetUserName()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Add meg, mi legyen a játékban a neved (Ez szerepel a toplistán is)!");
            Console.WriteLine();
                Console.Write("     Játékosnév: ");
            return Console.ReadLine()!;
        }
    }
}
