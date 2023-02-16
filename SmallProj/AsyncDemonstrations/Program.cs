using System.Threading.Tasks;
namespace Async{
    internal class Cake{
    public async static void BakeCake(){
        Console.WriteLine("Mixing cake ingredients");
        Thread.Sleep(250);
        Console.WriteLine("Putting cake in oven");
        Thread.Sleep(250);
        await Task.Delay(5000);
        Console.WriteLine("Removing cake from oven, waiting to cool");
        await Task.Delay(2000);
        Console.WriteLine("Icing cake now");
        Thread.Sleep(250);
        Console.WriteLine("Cake is finished");
        await Async.WashDishes();
        Console.WriteLine("Dishes from cake washed");
            }
    }
    internal class Pasta{
        public async static void MakePasta(){
        Console.WriteLine("Pot of water put on stove");
        Thread.Sleep(250);
        await Task.Delay(3000);
        Console.WriteLine("Adding pasta to water");
        Thread.Sleep(250);
        await Task.Delay(5000);
        Console.WriteLine("Pasta is now ready");
        await Async.WashDishes();
        Console.WriteLine("Dishes from pasta washed");
    }
    }

    internal class Chips{
        public static void PutOutChips(){
        Console.WriteLine("Chips have been put out");
        Thread.Sleep(250);
    }
    }
    public class Async{
        public static Task WashDishes(){
            return Task.Delay(200);
        }
        public static void DinnerParty(){
            Cake.BakeCake();
            Pasta.MakePasta();
            Chips.PutOutChips();
        }
    public static void Main(string[] args){
        Console.WriteLine("Press Enter to end execution early");
        DinnerParty();
        Console.ReadLine();

        
    }
    }
}