using Rise_of_Derma.providers;
using System.Diagnostics;

namespace Rise_of_Derma.scenarios
{
    public class Intro
    {
        public void InitIntro()
        {
            // Print debug
            Debug.WriteLine("Running Intro");

            // Show first page of intro
            PageOne();
            WaitKey.WaitForKey(ConsoleKey.Enter);
            Console.Clear();

            // Show seconds page of intro
            PageTwo();
            WaitKey.WaitForKey(ConsoleKey.Enter);
            Console.Clear();
        }

        private void PageOne()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Rise of Derma");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Az egykor virágzó Derma Birodalom a sötétség árnyékába merült,");
            Console.WriteLine("     amikor a gonosz varázsló, Morgron, felbukkant az ismeretlen erdő");
            Console.WriteLine("     mélyéről. Morgron sötét mágikus erejével elárasztotta az egész");
            Console.WriteLine("     birodalmat, és a korábban békés területeken most sötét lények");
            Console.WriteLine("     (Merkam-ok) seregei kóborolnak.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Az egyetlen remény a Birodalom számára egy Ősi Mágikus Kristály,");
            Console.WriteLine("     amelyet az ősi mágusok hoztak létre az idők kezdetén. A kristály a");
            Console.WriteLine("     Derma Birodalom védelmére szolgált, de Morgron hatalmának");
            Console.WriteLine("     előretörésekor eltűnt.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Lapozz (Enter)                                                  1/2");
        }

        private void PageTwo()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Rise of Derma");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     A játék története ebben a sötét időszakban veszi kezdetét, ahol");
            Console.WriteLine("     Finralnak a feladata, hogy összegyűjtsék a birodalom különböző");
            Console.WriteLine("     részein szétszórt ősi kristály darabokat. A karakterek különböző");
            Console.WriteLine("     területeken és birodalmi helyszíneken keresztül kalandoznak,");
            Console.WriteLine("     megküzdve Morgron sötét szolgálóival és helyreállítva a Derma");
            Console.WriteLine("     Birodalom egykori dicsőségét.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Ahogy a játékosok előre haladnak, felfedezhetnek új területeket,");
            Console.WriteLine("     szövetségeseket gyűjthetnek, és erősebb felszereléseket szerezhetnek,");
            Console.WriteLine("     hogy legyőzzék Morgront és visszahozzák a birodalmat a fénybe.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Lapozz (Enter)                                                  2/2");
        }
    }
}
