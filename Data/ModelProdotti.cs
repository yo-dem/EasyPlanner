using System.Data;

namespace EasyPlanner.Data
{
    internal struct ModelProdotti
    {
        public static DataTable getProdottoById(string idProdotto)
        {
            DataTable dt = DBUtility.getDBData("SELECT * FROM 'TPRODOTTI' WHERE IDPRODOTTO='" + idProdotto + "'");
            return dt;
        }
        
        public static void getProdotti(DataGridView dgv)
        {
            DataTable dt = DBUtility.getDBData("SELECT * FROM 'TPRODOTTI' ORDER BY IDPRODOTTO DESC");
            dgv.DataSource = dt;
        }
        
        public static void addProdotto(
            string data,
            string marca,
            string descrizione,
            string aliquota,
            string qnt,
            string prezzoNetto,
            string prezzoIvato,
            string note)
        {
            data = data.Replace("'", "''");
            marca = marca.Replace("'", "''");
            descrizione = descrizione.Replace("'", "''");
            aliquota = aliquota.Replace("'", "''");
            qnt = qnt.Replace("'", "''");
            prezzoNetto = prezzoNetto.Replace("'", "''");
            prezzoIvato = prezzoIvato.Replace("'", "''");
            note = note.Replace("'", "''");

            string sqlComm = @"INSERT INTO TPRODOTTI (DATA,MARCA,DESCRIZIONE,ALIQUOTA,QNT,PREZZO_NETTO,PREZZO_IVATO,NOTE)VALUES('"
                + data + "','"
                + marca + "','"
                + descrizione + "','"
                + aliquota + "','"
                + qnt + "','"
                + prezzoNetto + "','"
                + prezzoIvato + "','"
                + note + "')";
            DBUtility.setDBData(sqlComm);
        }
        
        public static void editProdotto(
            string idProdotto,
            string data,
            string marca,
            string descrizione,
            string aliquota,
            string qnt,
            string prezzoNetto,
            string prezzoIvato,
            string note)
        {
            data = data.Replace("'", "''");
            marca = marca.Replace("'", "''");
            descrizione = descrizione.Replace("'", "''");
            aliquota = aliquota.Replace("'", "''");
            qnt = qnt.Replace("'", "''");
            prezzoNetto = prezzoNetto.Replace("'", "''");
            prezzoIvato = prezzoIvato.Replace("'", "''");
            note = note.Replace("'", "''");

            string sqlComm = @"UPDATE TPRODOTTI SET DATA ='" + data
                + "', MARCA='" + marca
                + "', DESCRIZIONE='" + descrizione
                + "', ALIQUOTA='" + aliquota
                + "', QNT='" + qnt
                + "', PREZZO_NETTO='" + prezzoNetto
                + "', PREZZO_IVATO='" + prezzoIvato
                + "', NOTE='" + note
                + "' WHERE IDPRODOTTO='" + idProdotto + "'";
            DBUtility.setDBData(sqlComm);
        }
        
        public static void deleteProdotto(string? idProdotto)
        {
            string sqlComm = @"DELETE FROM TPRODOTTI WHERE IDPRODOTTO='" + idProdotto + "'";
            DBUtility.setDBData(sqlComm);
        }
    }
}
