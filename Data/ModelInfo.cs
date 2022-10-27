using System.Data;

namespace EasyPlanner.Data
{
    internal struct ModelInfo
    {
        public static string GetHeaderText()
        {
            DataTable dt = DBUtility.getDBData("SELECT HEADERTEXT FROM 'TINFO' WHERE IDINFO='1'");
            if (dt!=null && dt.Rows.Count!=0)
                return dt.Rows[0][0].ToString();
            else
                return "";
        }
        public static void SetHeaderText(string text)
        {
            text = text.Replace("'", "''");

            string sqlComm = @"UPDATE TINFO SET HEADERTEXT ='" + text + "'WHERE IDINFO='1'";
            DBUtility.setDBData(sqlComm);
        }
    }
}
