using System;
using System.Collections.Generic;
using GesCom.BO;
using GesCom.DAL;

namespace GesCom.BLL
{
    public class ProvenanceBLL
    {
        private static ProvenanceBLL uneProvenanceBLL;
        private List<Provenance> listeProvenances = new List<Provenance>();

        public static ProvenanceBLL GetUneProvenanceBLL()
        {
            if (uneProvenanceBLL == null)
            {
                uneProvenanceBLL = new ProvenanceBLL();
            }
            return uneProvenanceBLL;
        }

        public List<Provenance> GetListeProvenances()
        {
            listeProvenances = ProvenanceDAL.GetUneProvenanceDAL().GetListProvenances();
            return listeProvenances;
        }

        public Provenance GetProvenanceByCode(int code)
        {
            return ProvenanceDAL.GetUneProvenanceDAL().GetProvenanceByCode(code);
        }
    }
}
