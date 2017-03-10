namespace Frapid.Configuration.Moneywave
{
    public class MoneywaveConfig
    {
        public string Env { get; set; }
        public MoneywaveParam Test { get; set; }
        public MoneywaveParam Live { get; set; }
    }

    public class MoneywaveParam
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string Secret { get; set; }
    }

    
}