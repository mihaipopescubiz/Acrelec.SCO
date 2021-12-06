﻿using Acrelec.SCO.Core.Interfaces;
using Acrelec.SCO.DataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrelec.SCO.Core.Providers
{
    /// <summary>
    /// class providing the list of items as retrieved from POS system
    /// </summary>
    public class ItemsProvider : IItemsProvider
    {
        private List<POSItem> _posItems;
        
        public List<POSItem> AllPOSItems => _posItems;

        public List<POSItem> AvailablePOSItems => _posItems.Where(item => item.IsAvailable).ToList();

        public List<POSItem> OrderedByPriceAscPosItems => _posItems.OrderBy(item => item.UnitPrice).ToList();

        /// <summary>
        /// constructor
        /// </summary>
        public ItemsProvider()
        {
            _posItems = new List<POSItem>();
            LoadItemsFromPOS();
        }

        /// <summary>
        /// retrieving items from POS is a simple parse of a json
        /// </summary>
        public void LoadItemsFromPOS()
        {
            var content = File.ReadAllText(@"Data\ContentItems.json");
            _posItems = JsonConvert.DeserializeObject<List<POSItem>>(content);
            //todo - implement the code to load items from Data\ContentItems.json file
        }

        //todo - implement missing methods of interface
    }
}
