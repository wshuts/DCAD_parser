namespace DCAD_parser
{
    public class AccountApprlYear
    {
        public AccountApprlYear()
        {
            AccountNum = "";
            ImprVal = "";
            LandVal = "";
            TotVal = "";
            RevalYr = "";
            PrevRevalYr = "";
            PrevMktVal = "";
            CityJurisDesc = "";
            DivisionCd = "";
        }

        public override string ToString()
        {
            var result = ImprVal;
            result = result + "," + LandVal;
            result = result + "," + TotVal;
            result = result + "," + RevalYr;
            result = result + "," + PrevRevalYr;
            result = result + "," + PrevMktVal;
            result = result + "," + CityJurisDesc;
            //result = result + "," + _DIVISION_CD;
            return result;
        }

        public string AccountNum { get; set; }

        public string ImprVal { get; set; }

        public string LandVal { get; set; }

        public string TotVal { get; set; }

        public string RevalYr { get; set; }

        public string PrevRevalYr { get; set; }

        public string PrevMktVal { get; set; }

        public string CityJurisDesc { get; set; }

        public string DivisionCd { get; set; }
    }
}
