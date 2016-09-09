using Figaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figaro.Other
{
    public class Carrito
    {
        public Chef chef { get; set; }
        //public List<Tuple<Plato, int>> listaPlatos { get; set; }
        public List<KeyValuePair<Plato, int>> listaPlatos { get; set; }
        public List<KeyValuePair<Menu, int>> listaMenus { get; set; }

        public Carrito()
        {
            chef = new Chef();
            listaPlatos = new List<KeyValuePair<Plato, int>>();
            listaMenus = new List<KeyValuePair<Menu, int>>();
        }

        public void anadirPlato(KeyValuePair<Plato, int> item)
        {
            var existPlato = listaPlatos.Exists(x => x.Key.Id == item.Key.Id);
            if (existPlato)
            {
                var platoCant = listaPlatos.Find(x => x.Key.Id == item.Key.Id);
                var newplato = new KeyValuePair<Plato, int>(platoCant.Key, platoCant.Value + item.Value);
                listaPlatos.Remove(platoCant);
                listaPlatos.Add(newplato);
            }
            else
            {
                listaPlatos.Add(item);
            }
        }

        public void anadirMenu(KeyValuePair<Menu, int> item)
        {
            var existMenu = listaMenus.Exists(x => x.Key.Id == item.Key.Id);
            if (existMenu)
            {
                var menuCant = listaMenus.Find(x => x.Key.Id == item.Key.Id);
                var newplato = new KeyValuePair<Menu, int>(menuCant.Key, menuCant.Value + item.Value);
                listaMenus.Remove(menuCant);
                listaMenus.Add(newplato);
            }
            else
            {
                listaMenus.Add(item);
            }
        }
    }
}
