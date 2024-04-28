// See https://aka.ms/new-console-template for more information
using FukScamV1.Constants;
using FukScamV1.Enums;
using FukScamV1.Extensions;
using FukScamV1.Helpers;
using FukScamV1.MyHttpClient;
using FukScamV1.Utilities;

Helper.WriteToConsole("FUK SCAM V1", ConsoleColor.Red);
Thread.Sleep(1000);
Helper.WriteToConsole("Victim: https://wasterumion.com/", ConsoleColor.Yellow);

Helper.WriteToConsole("[EDMTDev] Prepare passport ! ^_-", ConsoleColor.DarkYellow);
Thread.Sleep(1000);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
var fakeRequest = await RestSharpClient.GetCookie("https://wasterumion.com/dich-vu-nhan-tien");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Helper.WriteToConsole("[EDMTDev] Hehe passport da xong ! Bom no nao!!! ! ^_-", ConsoleColor.DarkYellow);
Thread.Sleep(1000);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


Array values = Enum.GetValues(typeof(BankEnum));
Random random = new Random();

#region FakeUI
int numberOfRuns = 1500;
1{
    BankEnum randomBank = (BankEnum)values.GetValue(random.Next(values.Length));
    Helper.WriteToConsole($"Submit thanh cong cho ngan hang: {randomBank.GetDescription().NonUnicode()}", ConsoleColor.Green);
    Thread.Sleep(500);
});
#endregion


#region RealBot
//if (fakeRequest.token is not null && fakeRequest.cookie is not null)
//{
//    int numberOfRuns = 5;
//    try
//    {
//        await Parallel.ForAsync(0, numberOfRuns, async (i, cancellationToken) =>
//        {
//            await BankTransactionHandler.Run(fakeRequest.token, fakeRequest.cookie);
//            await Task.Delay(500);
//        });
//    }
//    catch (Exception ex)
//    {
//        Helper.WriteToConsole($"An error occurred: {ex.Message}", ConsoleColor.Red);
//    }
//}
#endregion


var a = FileUtils.GetRandomLineFromFile(FileUtils.GetResourceFilePath(CommonConstants.VIETNAMESE_NAME_FILE_PATH));
Console.WriteLine(a);

Helper.WriteToConsole("====== DONE ======", ConsoleColor.DarkYellow);
Console.ReadLine();