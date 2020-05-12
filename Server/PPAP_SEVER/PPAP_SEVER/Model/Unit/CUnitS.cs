using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP_SEVER
{
    public class CUnitS : List<CUnit>, IDisposable, ICloneable
    {
        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CUnitS()
        {

        }

        public void Dispose()
        {

        }
        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public object Clone()
        {
            CUnitS cUnitLogS = new CUnitS();

            for (int i = 0; i < this.Count; i++)
            {
                cUnitLogS.Add((CUnit)this[i].Clone());
            }

            return cUnitLogS;
        }

        #endregion
    }
}
