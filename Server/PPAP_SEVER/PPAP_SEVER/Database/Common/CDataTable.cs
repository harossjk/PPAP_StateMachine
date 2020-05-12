using System;

namespace PPAP_SEVER
{
    /// <summary>
    /// 테이블마다 연결 정보를 가지고 있어야 하기때문에 공통된 연결 정보와
    /// 테이블의 이름을 전역으로 가지고 있음
    /// </summary>
    public abstract class CDataTable : IDisposable
    {
        #region Member Variables

        protected CDatabaseConnector m_cConnector = null;
        protected string m_sTableName;

        #endregion


        #region Initialize/Dispose

        public CDataTable()
        {

        }

        public CDataTable(CDatabaseConnector cConnector)
        {
            m_cConnector = cConnector;
        }

        public void Dispose()
        {
            if (m_cConnector != null)
                m_cConnector = null;
        }

        #endregion


        #region Public Properties

        public CDatabaseConnector Connector
        {
            get { return m_cConnector; }
            set { m_cConnector = value; }
        }

        public string TableName
        {
            get { return m_sTableName; }
            set { m_sTableName = value; }
        }

        #endregion


        #region Public Methods


        #endregion
    }
}
