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

            // Show third page of intro
            PageThree();
            WaitKey.WaitForKey(ConsoleKey.Enter);
            Console.Clear();
        }

        private void PageOne()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Rise of Derma");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Az egykor virágzó Derma Birodalom a sötétség árnyékába merült,");
            Console.WriteLine("     amikor a gonosz varázsló, Morgron, felbukkant az ismeretlen erdô");
            Console.WriteLine("     mélyérôl. Morgron sötét mágikus erejével elárasztotta az egész");
            Console.WriteLine("     birodalmat, és a korábban békés területeken most sötét lények");
            Console.WriteLine("     (Merkam-ok) seregei kóborolnak. (Ezek számokként jelennek meg)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Az egyetlen remény a Birodalom számára egy ôsi Mágikus Kristály,");
            Console.WriteLine("     amelyet az ôsi mágusok hoztak létre az idôk kezdetén. A kristály a");
            Console.WriteLine("     Derma Birodalom védelmére szolgált, de Morgron hatalmának");
            Console.WriteLine("     elôretörésekor eltűnt.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Lapozz (Enter)                                                  1/3");
        }

        private void PageTwo()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Rise of Derma");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     A játék története ebben a sötét idôszakban veszi kezdetét, ahol");
            Console.WriteLine("     Finralnak (x) a feladata, hogy összegyűjtsék a birodalom különbözô");
            Console.WriteLine("     részein szétszórt ôsi kristály darabokat (*). A karakterek különbözô");
            Console.WriteLine("     területeken és birodalmi helyszíneken keresztül kalandoznak,");
            Console.WriteLine("     megküzdve Morgron sötét szolgálóival és helyreállítva a Derma");
            Console.WriteLine("     Birodalom egykori dicsôségét.");
            Console.WriteLine();
            Console.WriteLine("     Ahogy a játékos elôre halad, felfedezhet új területeket,");
            Console.WriteLine("     ellenségeket győzhet le, gyűjtheti a kristályokat,");
            Console.WriteLine("     hogy legyôzzék Morgront és visszahozzák a birodalmat a fénybe.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Lapozz (Enter)                                                  2/3");
        }

        private void PageThree()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Rise of Derma");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Karakter irányítása:");
            Console.WriteLine();
            Console.WriteLine("             ↑ / W       Felfele mozgás");
            Console.WriteLine("             ↓ / S       Lefele mozgás");
            Console.WriteLine("             ← / A       Balra mozgás");
            Console.WriteLine("             → / D       Jobbra mozgás");
            Console.WriteLine();
            Console.WriteLine("     Autómatikus mentés:");
            Console.WriteLine();
            Console.WriteLine("             A játék minden teljesített szintet követően mentést készít.");
            Console.WriteLine("             Az \"Esc\" gomb megnyomásával kiléphet a játékból.");
            Console.WriteLine("             A játék megnyitását követően ott folytathatja ahol");
            Console.WriteLine("             előbb abbahagyta!");
            Console.WriteLine();
            Console.WriteLine("     A játék használata alatt a konzol méretét ne változtassa!");
            Console.WriteLine("         Nagyításhoz (Ctrl + Görgő)");
            Console.WriteLine();
            Console.WriteLine("     Lapozz (Enter)                                                  3/3");
        }
    }
}
