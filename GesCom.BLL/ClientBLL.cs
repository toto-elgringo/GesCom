using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesCom.BO;
using GesCom.DAL;

namespace GesCom.BLL
{
    public class ClientBLL
    {   
        private static ClientBLL unClientBLL;
        private List<Client> listClients = new List<Client>();

        public static ClientBLL GetUnClientBLL()
        {
            if (unClientBLL == null)
            {
                unClientBLL = new ClientBLL();
            }
            return unClientBLL;
        }

        public List<Client> GetListClients()
        {
            listClients = ClientDAL.GetUnClientDAL().GetListClients();
            return listClients;
        }

        public Client GetClientByCode(int code)
        {
            return ClientDAL.GetUnClientDAL().GetClientByCode(code);
        }

        public void AjouterClient(Client client)
        {
            ClientDAL.GetUnClientDAL().AddClient(client);
        }

        public void UpdateClient(Client client)
        {
            

            GetListClients();
            if (listClients.Any(c => c.Code != client.Code && c.Nom.Trim().ToLower() == client.Nom.Trim().ToLower()))
            {
                throw new InvalidOperationException("Un autre clinet avec ce libellé existe déjà.");
            }

            ClientDAL.GetUnClientDAL().UpdateClient(client);
        }

        public void SupprimerClient(int code)
        {
            ClientDAL.GetUnClientDAL().DeleteClient(code);
        }
    }
}
