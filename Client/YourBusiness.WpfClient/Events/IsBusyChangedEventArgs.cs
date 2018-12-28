namespace YourBusiness.WpfClient.Events
{
    public class IsBusyChangedEventArgs
    {
        public bool IsBusy { get; set; }
        public string Reason { get; set; }
    }
}