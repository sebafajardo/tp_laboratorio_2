using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private List<Producto> productos;
        int espacioDisponible;
        public enum ETipo 
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible)
        {
            this.productos = new List<Producto>();
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {   
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            //creo una lista para cada tipo de producto, lo que me ayuda despues a acceder al metodo Mostrar de cada una de las clases hijas
            List<Producto> dulce = new List<Producto>();
            List<Producto> snacks = new List<Producto>();
            List<Producto> leche = new List<Producto>();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", c.productos.Count, c.espacioDisponible);
            //recorro la lista de productos
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    //cargo las listas creadas anteriormente en funcion del tipo recibido como parametro
                    case ETipo.Snacks:
                        if (v is Snacks)
                            snacks.Add(v);

                        break;
                    case ETipo.Dulce:
                        if (v is Dulce)
                            dulce.Add(v);
                   
                        break;
                    case ETipo.Leche:
                        if (v is Leche)
                            leche.Add(v);
                        break;
                    default:
                        leche.Clear();
                        snacks.Clear();
                        dulce.Clear();

                        foreach(Producto p in c.productos)
                        {
                            if (p is Dulce)
                                dulce.Add(p);
                            if (p is Leche)
                                leche.Add(p);
                            if (p is Snacks)
                                snacks.Add(p);
                            
                        }
                        break;
                }


            }
            
                switch (tipo)
                {
                //muestro los datos requeridos imprimiendo las listas que arme
                    case ETipo.Snacks:
                        foreach (Snacks s in snacks)
                        {
                            sb.AppendLine(s.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        foreach (Dulce d in dulce)
                        {
                            sb.AppendLine(d.Mostrar());
                        }
                        
                        break;

                    case ETipo.Leche:
                        foreach (Leche l in leche)
                        {
                          sb.AppendLine(l.Mostrar());
                        }
                        break;


                    default:
                    foreach (Dulce d in dulce)
                    {
                        sb.AppendLine(d.Mostrar());
                    }
                    foreach (Snacks s in snacks)
                    {
                        sb.AppendLine(s.Mostrar());
                    }
                    foreach (Leche l in leche)
                    {
                        sb.AppendLine(l.Mostrar());
                    }
                    
                    break;
                        

                }
                return sb.ToString();
                
            }
            
        
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {   
            //valido que el producto a agregar no sea igual a otro que ya existe en el changuito
            foreach (Producto v in c.productos)
            {
                if (v == p)
                    return c;
            }
            //valido que no supere el espacio disponible
            if (c.productos.Count < 6) //hardcodeo un valor
            {
                c.productos.Add(p);
                return c;
            }
            else
                return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {  
            //busco el producto a eliminar y lo elimino
            foreach (Producto v in c.productos)
            { 
                if (v == p)
                {
                    c.productos.Remove(p);
                    return c;
                }
            }

            return c;
        }
        #endregion
    }
}
