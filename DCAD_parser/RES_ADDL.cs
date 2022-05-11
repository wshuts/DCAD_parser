namespace DCAD_parser
{
    public class ResAddl
    {
        public ResAddl() 
        {
            AccountNum = "";
            AreaSize = "";
            ValAmt = "";
        }

        public override string ToString()
        {
            var result = AreaSize;
            result = result + "," + ValAmt;
            return result;
        }

        public string AccountNum { get; set; }

        public string AreaSize { get; set; }

        public string ValAmt { get; set; }
    }
}
