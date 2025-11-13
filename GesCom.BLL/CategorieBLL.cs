using System;
using System.Collections.Generic;
using GesCom.BO;
using GesCom.DAL;

namespace GesCom.BLL
{
    public class CategorieBLL
    {
        private static CategorieBLL uneCategorieBLL;
        private List<Categorie> listCategories = new List<Categorie>();

        public static CategorieBLL GetUneCategorieBLL()
        {
            if (uneCategorieBLL == null)
            {
                uneCategorieBLL = new CategorieBLL();
            }
            return uneCategorieBLL;
        }

        public List<Categorie> GetListeCategories()
        {
            listCategories = CategorieDAL.GetUneCategorieDAL().GetListCategories();
            return listCategories;
        }

        public Categorie GetCategorieByCode(int code)
        {
            return CategorieDAL.GetUneCategorieDAL().GetCategorieByCode(code);
        }
    }
}