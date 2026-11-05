using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TryParseBatikan
{
    internal class Storage
    {
        private readonly string path;

        public Storage(string path)
        {
            this.path = path;
        }

        public ToDoStorage Load()
        {
            if(!File.Exists(path))
            {
                return new ToDoStorage();
            }

            string json = File.ReadAllText(path);
            
            ToDoStorage todoStorage = JsonSerializer.Deserialize<ToDoStorage>(json);

            return todoStorage;
        }

        public void Save(ToDoStorage todoStorage)
        {
            string json = JsonSerializer.Serialize(todoStorage);

            File.WriteAllText(path, json);
        }

    }
}
