using System.Collections.Generic;

using CTPH_CoreBusiness.BusinessInterface;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Common;
using CTPH_CoreServiceAgent.Request;

using Newtonsoft.Json;

namespace CTPH_CoreServiceAgent
{
    public class MuestrasServiceAgent
    {
        private Http.httpRequestObj requestObject = new Http.httpRequestObj();
        private HttpMuestrasRequest request;

        public MuestrasServiceAgent(string urlbase)
        {
            request = new HttpMuestrasRequest(urlbase);
        }

        public IEnumerable<IMuestraInfo> Get()
        {
            string result = requestObject.GetRequest(request, "").Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<IMuestraInfo>>(result);

            return ObjResult;
        }

        public IEnumerable<IElemento> GetElementos()
        {

            var result = requestObject.GetRequest(request, "Muestras/GetElementos").Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<Elemento>>(result);

            return ObjResult;
        }

        public IEnumerable<IListaValores> GetElemento_ListaValores(int idElemento)
        {
            string qs = "?idElemento=" + idElemento.ToString();

            var result = requestObject.GetRequest(request, "Muestras/GetElemento_ListaValores" + qs).Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<ListaValores>>(result);

            return ObjResult;
        }

        public IEnumerable<IPuntoMedidaInfo> GetPuntosDeMedida()
        {
            string result = requestObject.GetRequest(request, "Muestras/GetPuntosDeMedida").Result;

            var ObjResult = JsonConvert.DeserializeObject<IEnumerable<PuntoMedida>>(result);

            return ObjResult;
        }

        public IResultDTO Insert(IMuestraInfo Muestra)
        {
            string body = JsonConvert.SerializeObject(Muestra);

            IResultDTO res = requestObject.PutRequest(request, "", body).Result;

            return res;
        }
    }
}
