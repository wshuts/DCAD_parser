namespace DCAD_parser
{
    public class Master
    {
        private Land land;
        private ResAddl resAddl;

        public Master() 
        {
            AccountInfo = new AccountInfo();
            AccountApprlYear = new AccountApprlYear();
            land = new Land();
            resAddl = new ResAddl();
            ResDetail = new ResDetail();
        }

        public string AccountNum
        {
            get { return AccountInfo.AccountNum; }
            set { AccountInfo.AccountNum = value; }
        }

        public string Legal1
        {
            get { return AccountInfo.Legal1; }
            set { AccountInfo.Legal1 = value; }
        }

        public string NbhdCd
        {
            get { return AccountInfo.NbhdCd; }
            set { AccountInfo.NbhdCd = value; }
        }

        public string Mapsco
        {
            get { return AccountInfo.Mapsco; }
            set { AccountInfo.Mapsco = value; }
        }

        public string DivisionCd
        {
            get { return AccountInfo.DivisionCd; }
            set { AccountInfo.DivisionCd = value; }
        }

        public string DeedTxfrDate
        {
            get { return AccountInfo.DeedTxfrDate; }
            set { AccountInfo.DeedTxfrDate = value; }
        }

        public string ImprVal
        {
            get { return AccountApprlYear.ImprVal; }
            set { AccountApprlYear.ImprVal = value; }
        }

        public string LandVal
        {
            get { return AccountApprlYear.LandVal; }
            set { AccountApprlYear.LandVal = value; }
        }

        public string TotVal
        {
            get { return AccountApprlYear.TotVal; }
            set { AccountApprlYear.TotVal = value; }
        }

        public string RevalYr
        {
            get { return AccountApprlYear.RevalYr; }
            set { AccountApprlYear.RevalYr = value; }
        }

        public string PrevRevalYr
        {
            get { return AccountApprlYear.PrevRevalYr; }
            set { AccountApprlYear.PrevRevalYr = value; }
        }

        public string PrevMktVal
        {
            get { return AccountApprlYear.PrevMktVal; }
            set { AccountApprlYear.PrevMktVal = value; }
        }

        public string CityJurisDesc
        {
            get { return AccountApprlYear.CityJurisDesc; }
            set { AccountApprlYear.CityJurisDesc = value; }
        }  
      
        public string LandAreaSize
        {
            get { return land.AreaSize; }
            set { land.AreaSize = value; }
        }

        public string GarageAreaSize
        {
            get { return resAddl.AreaSize; }
            set { resAddl.AreaSize = value; }
        }

        public string GarageValAmt
        {
            get { return resAddl.ValAmt; }
            set { resAddl.ValAmt = value; }
        }

        public string YrBuilt
        {
            get { return ResDetail.YrBuilt; }
            set { ResDetail.YrBuilt = value; }
        }

        public string ActAge
        {
            get { return ResDetail.ActAge; }
            set { ResDetail.ActAge = value; }
        }

        public string CduRatingDesc
        {
            get { return ResDetail.CduRatingDesc; }
            set { ResDetail.CduRatingDesc = value; }
        }

        public string TotMainSf
        {
            get { return ResDetail.TotMainSf; }
            set { ResDetail.TotMainSf = value; }
        }

        public string RoofMatDesc
        {
            get { return ResDetail.RoofMatDesc; }
            set { ResDetail.RoofMatDesc = value; }
        }

        public override string ToString()
        {
            var result = AccountInfo.ToString();
            result = result + "," + AccountApprlYear;
            result = result + "," + land;
            result = result + "," + resAddl;
            result = result + "," + ResDetail;
            return result;
        }

        public AccountInfo AccountInfo { get; set; }

        public AccountApprlYear AccountApprlYear { get; set; }

        public Land Land
        {
            get { return land; }
            set 
            { 
                land = value ?? new Land();
            }
        }

        public ResAddl ResAddl
        {
            get { return resAddl; }
            set 
            {
                resAddl = value ?? new ResAddl();
            }
        }

        public ResDetail ResDetail { get; set; }
    }
}
