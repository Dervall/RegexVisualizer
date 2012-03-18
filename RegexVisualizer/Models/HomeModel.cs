namespace RegexVisualizer.Models
{
    public class HomeModel
    {
        public string Regex { get; set; }
        public int NfaSize { get; set; }
        public int DfaSize { get; set; }
        public bool Minimize { get; set; }
    }
}