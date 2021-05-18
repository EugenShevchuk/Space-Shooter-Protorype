using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using System.Threading.Tasks;

namespace SpaceShooter.Architecture.SaveSystem
{
    public class Storage
    {
        private string filePath;
        private BinaryFormatter formatter;

        public Storage(string path)
        {
            filePath = Application.persistentDataPath + path;
            InitializeFormatter();
        }

        private void InitializeFormatter()
        {
            formatter = new BinaryFormatter();
        }

        public void Save(object dataToSave)
        {
            Debug.Log($"Saving {dataToSave}...");
            var file = new FileStream(filePath, FileMode.OpenOrCreate);

            try
            {
                formatter.Serialize(file, dataToSave);
            }
            catch (SerializationException exeption)
            {
                Debug.LogError("Data wasn't serialized " + exeption.Message);
            }
            finally
            {
                file.Close();
            }
        }

        public object Load(object defaultData)
        {
            Debug.Log("Loading...");

            if (File.Exists(filePath))
            {
                var file = new FileStream(filePath, FileMode.Open);

                try
                {
                    var savedData = formatter.Deserialize(file);
                    return savedData;
                }
                catch (SerializationException exeption)
                {
                    Debug.LogError("Data can't be deserialized " + exeption.Message);
                    return null;
                }
                finally
                {
                    file.Close();
                }
            }
            else
            {
                if (defaultData != null)
                {
                    Save(defaultData);
                    return defaultData;
                }
                else
                {
                    Debug.LogError("There is no saved data or default data to load");
                    return null;
                }
            }            
        }        
    }
}