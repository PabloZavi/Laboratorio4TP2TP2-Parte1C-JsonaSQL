using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primero sé que voy a recibir datos de una URL que tiene datos Json, en este caso:
            //"https://restcountries.com/v2/callingcode/{callingcode}

            //1. Lo que tengo que hacer, es buscar cualquier código de ejemplo que nos dará 
            //   el Json de dicho país.
            //2. Copiar el Json e ir a https://json2csharp.com/ que nos convertirá el Json a una clase
            //   de C#, copiamos esa clase y creamos una clase en C# llamada (en este caso) Pais
            //   y le pegamos lo que nos devolvió la página. Ojo! Tendrá como nombre "Root" en el código, 
            //   por lo que lo tendremos que cambiar a "Pais". Y puede que haya problemas con los atributos
            //   de tipo double, por lo que hay que cambiarlos a string.

            //Ahora empezaremos a recibir los datos (de a uno) de los primeros 300 países
            for (int i = 1; i <= 300; i++)
            {
                String url = "https://restcountries.com/v2/callingcode/" + i;
                //Uso la clase WebClient que pasa la url a string...
                WebClient wc = new WebClient();
                //con el método DownLoadString:

                //Console.WriteLine(paisJson);

                //Ahora tengo los datos almacenados de un país en un string
                //Lo que tenemos que hacer es deserializar ese Json en un objeto C#
                //Primero tenemos que instalar una dependencia para poder usar el método "JsonConvert":
                //Clic derecho en "Dependencias" --> "Administrar paquetes NuGet" --> Buscar e instalar "NewtonSoft.Json"
                //Ahora sí convierte el paísJson a un objeto Pais
                //(Creamos una variable de tipo convert, deserializamos con: JsonConvert.DeserializeObject<NombreClase>(string que tiene el Json)

                try
                {
                    var paisJson = wc.DownloadString(url);
                    //No sé por qué hay que crear un <List> de Pais para que funcione siendo que es un solo país
                    //pero se hace así y se accede a la posición 0
                    //var pais = JsonConvert.DeserializeObject<Pais>(paisJson);
                    var pais = JsonConvert.DeserializeObject<List<Pais>>(paisJson);
                    //Pais paiss = (Pais)pais;
                    //Console.WriteLine(pais[0].callingCodes[0]);
                    //Console.WriteLine(pais[0].name);
                    Controlador contr = new Controlador();
                    if (contr.existePais(Convert.ToInt32(pais[0].callingCodes[0])))
                    {
                        contr.actualizarPais(Convert.ToInt32(pais[0].callingCodes[0]), pais[0].name, pais[0].capital,
                            pais[0].region, pais[0].population, pais[0].latlng[0], pais[0].latlng[1]);
                    }
                    else
                    {
                        contr.insertarPais(Convert.ToInt32(pais[0].callingCodes[0]), pais[0].name, pais[0].capital,
                            pais[0].region, pais[0].population, pais[0].latlng[0], pais[0].latlng[1]);
                        Console.WriteLine(pais[0].latlng[0]);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());

                }



                //Otra forma de hacerlo es directamente deserializar el string que me trae el método WebClient sin tener
                //que guardarlo en una variable String.
                //Pais pais2 = JsonConvert.DeserializeObject<Pais>(wc.DownloadString(url));

                //Recordar que tenemos que crear una clase "Conexion" para comunicarnos con la base de datos
                //y que tenemos que agregar la referencia a MySql (clic derecho en Dependencias-->Agregar referencia del proyecto
                //y buscar el conector a mysql)



            }





        }
    }
}