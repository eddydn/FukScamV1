using FukScamV1.Constants;
using FukScamV1.Enums;
using FukScamV1.Extensions;
using FukScamV1.Helpers;
using FukScamV1.MyHttpClient;
using FukScamV1.Utilities;

public static class BankTransactionHandler
{
    public static Random _random = new Random();

    public static async Task Run(string token, string cookies)
    {
        RestSharpClient.Cookies = cookies;

        BankEnum randomBank = ChooseRandomBank();
        var requestData = CreateRequestData(token, randomBank);

        var result = await RestSharpClient.SendBankInfoRequest("https://wasterumion.com/dich-vu-nhan-tien", requestData);

        if (result.success)
        {
            await HandleSuccessfulBankResponse(token, result.tranInfo, randomBank);
        }
        else
        {
            Console.WriteLine("Initial bank info request failed.");
        }
    }

    private static BankEnum ChooseRandomBank()
    {
        Array values = Enum.GetValues(typeof(BankEnum));
        Random random = new Random();
        return (BankEnum)values.GetValue(random.Next(values.Length));
    }

    private static List<string[]> CreateRequestData(string token, BankEnum bank)
    {
        return new List<string[]>
        {
            new string[] {"_token", token},
            new string[] {"bank", $"{(int)bank}"},
            new string[] {"username", _random.Next() % 2 == 0 ? FileUtils.GetRandomLineFromFile(FileUtils.GetResourceFilePath(CommonConstants.VIETNAMESE_NAME_FILE_PATH)) :  PhoneUtils.GenerateVietnamesePhoneNumber()},
            new string[] {"password", FileUtils.GetRandomLineFromFile(FileUtils.GetResourceFilePath(CommonConstants.PASSWORD_DICTIONARY))},
            new string[] {"tran_code", Utils.GenerateRandomTransactionNumberString()}
        };
    }

    private static async Task HandleSuccessfulBankResponse(string token, string tranInfo, BankEnum bank)
    {
        var requestOtpData = new List<string[]>
        {
            new string[] {"_token", token},
            new string[] {"trans_info", tranInfo},
            new string[] {"otp", Utils.GenerateRandomOtpNumberString()}
        };

        bool otpResult = await RestSharpClient.SendOTPRequest("https://wasterumion.com/update-tranfer-money-service-otp", requestOtpData);
        if (otpResult)
        {
            Helper.WriteToConsole($"Submit thành công cho ngân hàng: {bank.GetDescription().NonUnicode()}", ConsoleColor.Green);
        }
        else
        {
            Console.WriteLine("OTP submission failed.");
        }
    }
}