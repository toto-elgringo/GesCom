using GesCom.BO;
using GesCom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesCom.BLL
{
    public class StatutBLL
    {
        private static StatutBLL unStatutBLL;
        private List<Statut> listStatuts = new List<Statut>();

        public static StatutBLL GetUnStatutBLL()
        {
            if (unStatutBLL == null)
            {
                unStatutBLL = new StatutBLL();
            }
            return unStatutBLL;
        }

        public List<Statut> GetListeStatuts()
        {
            listStatuts = StatutDAL.GetUnStatutDAL().GetListStatut();
            return listStatuts;
        }

        public Statut GetStatutByCode(int code)
        {
            return StatutDAL.GetUnStatutDAL().GetStatutByCode(code);
        }
    }
}
