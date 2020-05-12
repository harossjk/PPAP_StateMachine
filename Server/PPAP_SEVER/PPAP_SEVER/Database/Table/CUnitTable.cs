using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP_SEVER
{
    public class CUnitTable : CDataTable
    {
        #region Member Variables


        #endregion

        #region Initialize/Dispose

        public CUnitTable(CDatabaseConnector cConnector)
        {
            m_sTableName = "t_unit";
            this.m_cConnector = cConnector;
        }

        public new void Dispose()
        {
            if (m_cConnector != null)
                m_cConnector = null;
        }
        #endregion 

        #region Public Methods

        public bool CreateTable()
        {
            //DeleteTable();
            //string sQuery = @"CREATE TABLE " + m_sTableName + "("
            //                + "pr_key SMALLINT UNSIGNED NOT NULL,"
            //                + "tag_key VARCHAR(20) NOT NULL,"
            //                + "start_tm DATETIME(3) NOT NULL,"
            //                + "end_tm DATETIME(3) NOT NULL,"
            //                + "`desc` VARCHAR(100)"
            //                + ");";

            //return m_cConnector.Execute(sQuery);
            return false;
        }

        public bool DeleteTable()
        {
            string sQuery = "DROP TABLE IF EXISTS " + m_sTableName;

            return m_cConnector.Execute(sQuery);
        }

        public CUnitS Select()
        {
            string sQuery = "SELECT * FROM " + m_sTableName;
            return Select(sQuery);
        }

        public CUnitS Select(string sQuery)
        {
            CUnitS cLogS = null;

            DataTable dtTable = m_cConnector.ExecuteForDataTable(sQuery);

            if (dtTable != null)
            {
                cLogS = ReadTable(dtTable);
                dtTable.Dispose();
                dtTable = null;
            }
            return cLogS;
        }

        public bool Insert(CUnit cLog)
        {
            //string sQuery = @" INSERT INTO " + m_sTableName + " (pr_key, tag_key, start_tm, end_tm, `desc`) " +
            //                " VALUES (" +
            //                cLog.ProcessKey + ", " +
            //                cLog.AlarmTagKey + ", '" +
            //                CTypeConverter.ToLongTimeText(cLog.ErrorStartTime) + "', '" +
            //                CTypeConverter.ToLongTimeText(cLog.ErrorEndTime) + "', '" +
            //                cLog.Description + "'); ";

            //return m_cConnector.Execute(sQuery);
            return false;
        }

        public bool Delete(int prkey)
        {
            string sQuery = " DELETE FROM " + m_sTableName + "  WHERE pr_key ='" + prkey + "' ";
            return m_cConnector.Execute(sQuery);
        }

        #endregion

        #region Private Methods        
        private CUnit ReadRecord(DataTable dtTable)
        {
            CUnitS cRowS = null;
            foreach (DataRow dtRow in dtTable.Rows)
            {
                CUnit cRow = new CUnit();
                //cRow.ProcessKey = (ushort)dtRow[0];
                //cRow.AlarmTagKey = (string)dtRow[1];
                //cRow.ErrorStartTime = (DateTime)dtRow[2];
                //cRow.ErrorEndTime = (DateTime)dtRow[3];
                //cRow.Description = (string)dtRow[4];

                cRowS.Add(cRow);
            }

            if (cRowS.Count != 0)
                return (CUnit)cRowS[0];

            else
                return null;
        }

        private CUnitS ReadTable(DataTable dtTable)
        {
            CUnitS cRowS = new CUnitS();

            foreach (DataRow dtRow in dtTable.Rows)
            {
                CUnit cRow = new CUnit();
                //cRow.ProcessKey = (ushort)dtRow[0];
                //cRow.AlarmTagKey = (string)dtRow[1];
                //cRow.ErrorStartTime = (DateTime)dtRow[2];
                //cRow.ErrorEndTime = (DateTime)dtRow[3];
                //cRow.Description = (string)dtRow[4];

                cRowS.Add(cRow);
            }

            return cRowS;
        }
        #endregion
    }
}
