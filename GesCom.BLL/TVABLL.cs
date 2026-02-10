using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesCom.BO;
using GesCom.DAL;

namespace GesCom.BLL
{
    public class TVABLL
    {
        private static TVABLL unTVABLL;
        private List<TVA> listTVA = new List<TVA>();

        public static TVABLL GetUnTVABLL()
        {
            if (unTVABLL == null)
            {
                unTVABLL = new TVABLL();
            }
            return unTVABLL;
        }

        public List<TVA> GetListTVA()
        {
            listTVA = TVADAL.GetUnTVADAL().GetListTVA();
            return listTVA;
        }

        public TVA GetTVAById(int id)
        {
            return TVADAL.GetUnTVADAL().GetTVAById(id);
        }
    }
}
