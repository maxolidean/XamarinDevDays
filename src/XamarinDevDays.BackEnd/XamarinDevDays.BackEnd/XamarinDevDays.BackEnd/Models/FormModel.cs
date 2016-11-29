using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoRepo;

namespace XamarinDevDays.BackEnd.Models
{
    public class FormModel:  DocumentBase<FormModel>
    {
   
        private static string key = "gEWqPfpodjdglR455bXU4RbtAzAYWHUpR5ZveZt8mZfpWzCji1x52uR3hNhQsmrxpWDLB3kl6RfBjtNUrqoppA==";
        private static string endpoint = "https://lagash-xamarindevdays.documents.azure.com:443/";
        private static string dbName = "Lab";
        private static string collection = "Participants";
    
        public async Task<string> Create()
        {
            var repo = new DocumentDbRepo(endpoint, key, dbName, collection);
            var idReturn = await repo.Create(this).ConfigureAwait(false);

            return idReturn;
        }

        public async Task<IEnumerable<FormModel>> GetAll2()
        {
            var repo = new DocumentDbRepo(endpoint, key, dbName, collection);
            var data = await repo.Where<FormModel>(c => c.LastName.Length > 0);

            var data2 = await GetAll().ConfigureAwait(false);

            return data;
        }

        public string Name { get; set; }
   
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}