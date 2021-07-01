using System.Collections.Generic;

using Newtonsoft.Json;

using CTPH_CoreBusiness.BusinessInterface;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreServiceAgent.Request;

namespace CTPH_CoreServiceAgent
{
    public class AdminServiceAgent
    {
        private Http.httpRequestObj requestObject = new Http.httpRequestObj();
        private HttpAdminRequest request;

        public AdminServiceAgent(string urlbase)
        {
            request = new HttpAdminRequest(urlbase);
        }

        public IEnumerable<IElemento> GetElementos()
        {

            var result = requestObject.GetRequestAdmin(request, "Admin/GetElementos").Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<Elemento>>(result);

            return ObjResult;
        }

        public IEnumerable<IListaValores> GetElemento_ListaValores(int idElemento)
        {
            string qs = "?idElemento=" + idElemento.ToString();

            var result = requestObject.GetRequestAdmin(request, "Admin/GetElemento_ListaValores" + qs).Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<ListaValores>>(result);

            return ObjResult;
        }

        public IEnumerable<IPuntoMedidaInfo> GetPuntosDeMedida()
        {
            string result = requestObject.GetRequestAdmin(request, "Admin/GetPuntosDeMedida").Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<PuntoMedida>>(result);

            return ObjResult;
        }
    }
}
