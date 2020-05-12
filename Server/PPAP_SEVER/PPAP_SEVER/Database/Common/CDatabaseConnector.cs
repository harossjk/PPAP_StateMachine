using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP_SEVER
{
    public class CDatabaseConnector: IDisposable
    {
        #region Member Variables

        protected bool m_bConnect = false;
        protected MySqlConnection m_dbCon = null;
        protected string m_sIp = "127.0.0.1";
        protected int m_iPort = 0;
        protected string m_sUser = "";
        protected string m_sPassword = "";
        protected string m_sDatabase = "";

        #endregion


        #region Initialize/Dispose

        public CDatabaseConnector()
        {

        }

        public void Dispose()
        {
            Disconnect();
        }

        #endregion


        #region Public Properties

        public bool IsConnected
        {
            get { return m_bConnect; }
        }

        public string Ip
        {
            get { return m_sIp; }
            set { m_sIp = value; }
        }

        public int Port
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }

        public string User
        {
            get { return m_sUser; }
            set { m_sUser = value; }
        }

        public string Password
        {
            get { return m_sPassword; }
            set { m_sPassword = value; }
        }

        public string DatabaseName
        {
            get { return m_sDatabase; }
            set { m_sDatabase = value; }
        }

        #endregion


        #region Public Methods

        public bool Connect()
        {
            string sConnection = @"Host=" + m_sIp
                               + ";Port=" + m_iPort.ToString()
                               + ";Username=" + m_sUser
                               + ";Password=" + m_sPassword
                               + ";Database=" + m_sDatabase
                               + ";CharSet=utf8;";

            m_dbCon = new MySqlConnection(sConnection);

            try
            {
                m_dbCon.Open();
                m_bConnect = true;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return m_bConnect;
        }

        public void Disconnect()
        {
            if (m_bConnect == false)
                return;

            try
            {
                if (m_dbCon == null)
                    return;

                m_dbCon.Close();
                m_dbCon.Dispose();
                m_dbCon = null;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
        }

        public bool Execute(string sCommand)
        {
            bool bOK = true;

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);

            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return bOK;
        }

        public bool Execute(string sCommand, MySqlParameter cParam)
        {
            bool bOK = true;

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);

            try
            {
                dbCommand.Parameters.Add(cParam);

                dbCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return bOK;
        }

        public bool Execute(string sCommand, List<MySqlParameter> lstParam)
        {
            bool bOK = true;

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);

            try
            {
                for (int i = 0; i < lstParam.Count; i++)
                    dbCommand.Parameters.Add(lstParam[i]);

                dbCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return bOK;
        }

        public object ExecuteScalar(string sCommand)
        {
            object oValue = null;

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);

            try
            {
                oValue = dbCommand.ExecuteScalar();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return oValue;
        }

        public object ExecuteScalar(string sCommand, MySqlParameter cParam)
        {
            object oValue = null;

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);

            try
            {
                dbCommand.Parameters.Add(cParam);

                oValue = dbCommand.ExecuteScalar();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return oValue;
        }

        public object ExecuteScalar(string sCommand, List<MySqlParameter> lstParam)
        {
            object oValue = null;

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);

            try
            {
                for (int i = 0; i < lstParam.Count; i++)
                    dbCommand.Parameters.Add(lstParam[i]);

                oValue = dbCommand.ExecuteScalar();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return oValue;
        }

        public MySqlCommand CreateCommand(string sCommand)
        {
            MySqlCommand cCommand = new MySqlCommand(sCommand, m_dbCon);

            return cCommand;
        }

        public MySqlTransaction BeginTransaction()
        {
            MySqlTransaction dbTransaction = m_dbCon.BeginTransaction();

            return dbTransaction;
        }

        public bool DeleteLargeFile(int iId)
        {
            string sQuery = @"SELECT lo_unlink(" + iId.ToString() + ") FROM pg_largeobject_metadata;";

            bool bOK = Execute(sQuery);
            return bOK;
        }

        public DataTable ExecuteForDataTable(string sCommand)
        {
            DataTable dtValue = new DataTable();

            MySqlCommand dbCommand = new MySqlCommand(sCommand, m_dbCon);
            dbCommand.CommandType = CommandType.Text;
            MySqlDataAdapter dbDataAdapter = new MySqlDataAdapter(dbCommand);

            try
            {
                dbDataAdapter.Fill(dtValue);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
            }

            return dtValue;
        }

        #endregion


        #region Private Methods

        #endregion
    }
}
