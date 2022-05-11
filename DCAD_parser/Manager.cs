using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace DCAD_parser
{
    public class Manager
    {
        private StreamWriter sw;
        private Dictionary<string, AccountInfo> accountsInfo;
        private Dictionary<string, AccountApprlYear> accountsApprlYear;
        private List<Land> lands;
        private List<ResAddl> ressAddl;
        private List<ResDetail> ressDetail;
        private readonly Dictionary<string, Master> masters;
        private Dictionary<string, Master> accountsComps;

        public Manager()
        {
            masters = new Dictionary<string, Master>();
        }

        public void Launch()
        {
            ThreadStart start = Worker;
            var t = new Thread(start);
            t.Start();
        }

        private void Worker()
        {
            CreateResCoppell5OSK01();
            ReadResCoppell5OSK01();
            WriteComps();
        }

        private void CreateResCoppell5OSK01()
        {
            Read_ACCOUNT_INFO_ForRes5OSK01();
            Read_ACCOUNT_APPRL_YEAR_ForResCoppell();
            Read_LAND();
            Read_RES_ADDL();
            Read_RES_DETAIL();
            Test();
        }

        private void Read_ACCOUNT_INFO_ForRes5OSK01()
        {
            const string readFile = "account_info.csv";
            var allLines = File.ReadAllLines(readFile);

            var queryAccountsInfo =
                from line in allLines
                let screen = line.Split(',')
                where screen[2] == "\"RES\""
                where screen[21] == "\"5OSK01\""
                select new AccountInfo()
                {
                    AccountNum = screen[0],
                    DivisionCd = screen[2],
                    Mapsco = screen[20],
                    NbhdCd = screen[21],
                    Legal1 = screen[22],
                    DeedTxfrDate = screen[27]
                };

            accountsInfo = queryAccountsInfo.ToDictionary(p => p.AccountNum);
        }

        private void Read_ACCOUNT_APPRL_YEAR_ForResCoppell()
        {
            const string readFile = "account_apprl_year.csv";
            var allLines = File.ReadAllLines(readFile);

            var queryAccountsApprlYear =
                from line in allLines
                let screen = line.Split(',')
                where screen[13] == "\"COPPELL\""
                where screen[41] == "\"RES\""
                select new AccountApprlYear()
                {
                    AccountNum = screen[0],
                    ImprVal = screen[2],
                    LandVal = screen[3],
                    TotVal = screen[6],
                    RevalYr = screen[8],
                    PrevRevalYr = screen[9],
                    PrevMktVal = screen[10],
                    CityJurisDesc = screen[13],
                    DivisionCd = screen[41]
                };

            accountsApprlYear = queryAccountsApprlYear.ToDictionary(p => p.AccountNum);
        }

        private void Read_LAND()
        {
            const string readFile = "land.csv";
            var allLines = File.ReadAllLines(readFile);

            var queryLands =
                from line in allLines
                let screen = line.Split(',')
                select new Land()
                {
                    AccountNum = screen[0],
                    AreaSize = screen[8],
                    ValAmt = screen[13]
                };

            lands = queryLands.ToList();
        }

        private void Read_RES_ADDL()
        {
            const string readFile = "res_addl.csv";
            var allLines = File.ReadAllLines(readFile);

            var queryRessAddl =
                from line in allLines
                let screen = line.Split(',')
                select new ResAddl()
                {
                    AccountNum = screen[0],
                    AreaSize = screen[11],
                    ValAmt = screen[12]
                };

            ressAddl = queryRessAddl.ToList();
        }

        private void Read_RES_DETAIL()
        {
            const string readFile = "res_detail.csv";
            var allLines = File.ReadAllLines(readFile);

            var queryRessDetail =
                from line in allLines
                let screen = line.Split(',')
                select new ResDetail()
                {
                    AccountNum = screen[0],
                    YrBuilt = screen[4],
                    ActAge = screen[6],
                    CduRatingDesc = screen[7],
                    TotMainSf = screen[8],
                    RoofMatDesc = screen[20]
                };

            ressDetail = queryRessDetail.ToList();
        }

        private void Test()
        {
            masters.Clear();
            foreach (var accountNum in accountsInfo.Keys)
            {
                var currentMaster = new Master
                {
                    AccountInfo = accountsInfo[accountNum],
                    AccountApprlYear = accountsApprlYear[accountNum],
                    Land = lands.Find(p => p.AccountNum == accountNum),
                    ResAddl = ressAddl.Find(p => p.AccountNum == accountNum),
                    ResDetail = ressDetail.Find(p => p.AccountNum == accountNum)
                };
                masters.Add(accountNum, currentMaster);
            }

            const string masterFile = "ResCoppell5OSK01.csv";

            using (sw = new StreamWriter(masterFile))
            {
                var firstRow = CreateHeader();
                sw.WriteLine(firstRow);
                foreach (var accountNum in masters.Keys)
                {
                    var row = masters[accountNum].ToString();
                    sw.WriteLine(row);
                }
            }
        }

        private void ReadResCoppell5OSK01()
        {
            const string readFile = "ResCoppell5OSK01.csv";
            var allLines = File.ReadAllLines(readFile);
            allLines = RemoveHeader(allLines);

            var queryAccountsComps =
                from line in allLines
                let screen = line.Split(',')
                where Math.Abs(double.Parse(screen[17].Trim('"')) - 34) < 2
                where double.Parse(screen[19].Trim('"')) < 1284
                where double.Parse(screen[19].Trim('"')) > 1264
                where double.Parse(screen[13].Trim('"')) > 6999
                where double.Parse(screen[13].Trim('"')) < 7400
                where double.Parse(screen[14].Trim('"')) > 300
                select new Master
                {
                    AccountNum = screen[0],
                    Legal1 = screen[1],
                    NbhdCd = screen[2],
                    Mapsco = screen[3],
                    DivisionCd = screen[4],
                    DeedTxfrDate = screen[5],
                    ImprVal = screen[6],
                    LandVal = screen[7],
                    TotVal = screen[8],
                    RevalYr = screen[9],
                    PrevRevalYr = screen[10],
                    PrevMktVal = screen[11],
                    CityJurisDesc = screen[12],
                    LandAreaSize = screen[13],
                    GarageAreaSize = screen[14],
                    GarageValAmt = screen[15],
                    YrBuilt = screen[16],
                    ActAge = screen[17],
                    CduRatingDesc = screen[18],
                    TotMainSf = screen[19],
                    RoofMatDesc = screen[20]
                };

            accountsComps = queryAccountsComps.ToDictionary(p => p.AccountNum);
        }

        private static string[] RemoveHeader(IEnumerable<string> allLines)
        {
            var lines = allLines.ToList();
            lines.RemoveAt(0);
            return lines.ToArray();
        }

        private void WriteComps()
        {
            const string masterFile = "comps.csv";
            using (sw = new StreamWriter(masterFile))
            {
                var firstRow = CreateHeader();
                sw.WriteLine(firstRow);
                foreach (var accountNum in accountsComps.Keys)
                {
                    var row = accountsComps[accountNum].ToString();
                    sw.WriteLine(row);
                }
            }
        }

        private static string CreateHeader()
        {
            var header = "\"";

            header = header + "ACCOUNT_NUM" + "\",\"";
            header = header + "LEGAL1" + "\",\"";
            header = header + "NBHD_CD" + "\",\"";
            header = header + "MAPSCO" + "\",\"";
            header = header + "DIVISION_CD" + "\",\"";
            header = header + "DEED_TXFR_DATE" + "\",\"";

            header = header + "IMPR_VAL" + "\",\"";
            header = header + "LAND_VAL" + "\",\"";
            header = header + "TOT_VAL" + "\",\"";
            header = header + "REVAL_YR" + "\",\"";
            header = header + "PREV_REVAL_YR" + "\",\"";
            header = header + "PREV_MKT_VAL" + "\",\"";
            header = header + "CITY_JURIS_DESC" + "\",\"";

            header = header + "LAND_AREA_SIZE" + "\",\"";

            header = header + "GARAGE_AREA_SIZE" + "\",\"";
            header = header + "GARAGE_VAL_AMT" + "\",\"";

            header = header + "YR_BUILT" + "\",\"";
            header = header + "ACT_AGE" + "\",\"";
            header = header + "CDU_RATING_DESC" + "\",\"";
            header = header + "TOT_MAIN_SF" + "\",\"";
            header = header + "ROOF_MAT_DESC" + "\"";

            return header;
        }

        public event EventHandler<ProgressArgs> Progress;

        protected virtual void OnProgress(ProgressArgs e)
        {
            var handler = Progress;
            if (handler != null) handler(this, e);
        }
    }
}