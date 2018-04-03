using Newtonsoft.Json;
using System;
using System.IO;
using apiClientDotNet.Models;
using System.Collections.Generic;
namespace apiClientDotNet
{
    public class SymConfigLoader
    {
        public SymConfig loadFromFile(String fileLocation)
        {
            SymConfig symConfig = new SymConfig();
            try
            {   
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    String json = sr.ReadToEnd();
                    symConfig  = JsonConvert.DeserializeObject<SymConfig>(json);
                    Console.WriteLine(symConfig.sessionAuthHost);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return symConfig;

        }
    }
}

