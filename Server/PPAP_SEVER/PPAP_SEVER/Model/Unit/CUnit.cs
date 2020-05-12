using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP_SEVER
{
    public class CUnit : ICloneable, IDisposable
    {
        #region Member Variables
        //이름
        private string m_sName = string.Empty;
        //범위
        private double m_dRange = -1;
        //위치
        private Point m_pUnitPos = new Point(0, 0);
        //상태
        private EMUnitStatuse m_emStatuse = EMUnitStatuse.NONE;

        #endregion

        #region Initialize/Dispose

        public CUnit()
        {
        }

        public CUnit(string name , double range, Point pos, EMUnitStatuse statuse)
        {
            this.m_sName = name;
            this.m_dRange = range;
            this.m_pUnitPos = pos;
            this.m_emStatuse = statuse;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public double Rnage
        {
            get { return m_dRange; }
            set { m_dRange = value; }
        }

        public Point Position
        {
            get { return m_pUnitPos; }
            set { m_pUnitPos = value; }
        }

        public EMUnitStatuse Statuse
        {
            get { return m_emStatuse; }
            set { m_emStatuse = value; }
        }

        #endregion


        #region Public Methods



        public object Clone()
        {
            CUnit cUnit = new CUnit();
            cUnit.Name = this.m_sName;
            cUnit.Rnage = this.Rnage;
            cUnit.Position = this.Position;
            cUnit.Statuse = this.Statuse;

            return cUnit;
        }

        #endregion


        #region Private Methods



        #endregion


        #region Event Methods


        #endregion
    }
}
