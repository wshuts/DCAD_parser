namespace DCAD_parser
{
    public class ResDetail
    {
        public ResDetail()
        {
            AccountNum = "";
            YrBuilt = "";
            ActAge = "";
            CduRatingDesc = "";
            TotMainSf = "";
            RoofMatDesc = "";
        }

        public override string ToString()
        {
            var result = YrBuilt;
            result = result + "," + ActAge;
            result = result + "," + CduRatingDesc;
            result = result + "," + TotMainSf;
            result = result + "," + RoofMatDesc;
            return result;
        }

        public string AccountNum { get; set; }

        public string YrBuilt { get; set; }

        public string ActAge { get; set; }

        public string CduRatingDesc { get; set; }

        public string TotMainSf { get; set; }

        public string RoofMatDesc { get; set; }
    }
}