using LoggerStdClass;

class Program
{
    static void Main(string[] args)
    {
        Logger.Instance.LogError(LogLevelEnum.Info,"hello");
        Logger.Instance.LogError(LogLevelEnum.Error,"BYe");
     
    }
}