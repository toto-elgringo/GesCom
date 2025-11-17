using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesCom.BO;
using GesCom.DAL;

namespace GesCom.BLL
{
    public class DevisBLL
    {
        private static DevisBLL unDevisBLL;
        private List<Devis> listDevis = new List<Devis>();

        public static DevisBLL GetUnDevisBLL()
        {
            if (unDevisBLL == null)
            {
                unDevisBLL = new DevisBLL();
            }
            return unDevisBLL;
        }

        public List<Devis> GetListDevis()
        {
            listDevis = DevisDAL.GetUnDevisDAL().GetListDevis();
            return listDevis;
        }

        public Devis GetDevisByCode(int code)
        {
            return DevisDAL.GetUnDevisDAL().GetDevisByCode(code);
        }

        public void AjouterDevis(Devis devis)
        {
            DevisDAL.GetUnDevisDAL().AddDevis(devis);
        }

        public void UpdateDevis(Devis devis)
        {
            GetListDevis();
            if (listDevis.Any(d => d.Code != devis.Code && d.Date == devis.Date && d.Client.Code == devis.Client.Code))
            {
                throw new InvalidOperationException("Un autre devis avec cette date et ce client existe déjà.");
            }

            DevisDAL.GetUnDevisDAL().UpdateDevis(devis);
        }

        public void SupprimerDevis(int code)
        {
            DevisDAL.GetUnDevisDAL().DeleteDevis(code);
        }
    }
}
