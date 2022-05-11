namespace DCAD_parser
{
    public class Land
    {
        public Land() 
        {
            AccountNum = "";
            AreaSize = "";
            ValAmt = "";
        }

        public override string ToString()
        {
            var result = AreaSize;
            return result;
        }

        public string AccountNum { get; set; }

        public string AreaSize { get; set; }

        public string ValAmt { get; set; }
    }
}
