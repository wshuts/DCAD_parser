namespace DCAD_parser
{
    public class AccountInfo
    {
        public AccountInfo() 
        {
            AccountNum = "";
            Legal1 = "";
            NbhdCd = "";
            Mapsco = "";
            DivisionCd = "";
            DeedTxfrDate = "";
        }
        
        public override string ToString()
        {
            var result = AccountNum;
            result = result + "," + Legal1;
            result = result + "," + NbhdCd;
            result = result + "," + Mapsco;
            result = result + "," + DivisionCd;
            result = result + "," + DeedTxfrDate;
            return result;
        }

        public string AccountNum { get; set; }

        public string Legal1 { get; set; }

        public string NbhdCd { get; set; }

        public string Mapsco { get; set; }

        public string DivisionCd { get; set; }

        public string DeedTxfrDate { get; set; }
    }
}
