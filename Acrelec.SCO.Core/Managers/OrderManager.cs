using Acrelec.SCO.Core.Interfaces;
using Acrelec.SCO.Core.Model.RestExchangedMessages;
using Acrelec.SCO.DataStructures;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Acrelec.SCO.Core.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly HttpClient _httpClient;

        private IItemsProvider _itemsProvider { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public OrderManager(IItemsProvider itemsProvider, HttpClient httpClient)
        {
            _itemsProvider = itemsProvider;
            _httpClient = httpClient;
        }

        public async Task<string> InjectOrderAsync(Order orderToInject)
        {
            InjectOrderRequest request = new InjectOrderRequest()
            {
                Customer = new Customer() { Address = "Bucharest", Firstname = "John" },
                Order = orderToInject
            };
            InjectOrderResponse injectOrderResponse = null;

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api-sco/v1/order", request);

                if (response.IsSuccessStatusCode)
                {
                    var injectOrderTask = await response.Content.ReadAsStringAsync();
                    injectOrderResponse = JsonSerializer.Deserialize<InjectOrderResponse>(injectOrderTask,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
            return injectOrderResponse?.OrderNumber ?? string.Empty;
        }

        //todo - implement interface knowing that it has to call the REST API described in readme.txt file 
    }
}
