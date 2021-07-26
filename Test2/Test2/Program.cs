using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Test2.dtoContracts;

namespace Test2
{
    interface IDataProvider
    {
        DeviceInfo[] GetDevice();
        void WriteWorksGroup(Conflict[] conflicts);
    }
    interface IDataProccesor
    {
        void GetWorksGroup(IDataProvider dataProvider);
    }
    class Program
    {
        static void Main(string[] args)
        {
            IDataProccesor dataProccesor = new DataProccesor();
            dataProccesor.GetWorksGroup(new JsonDataProvider());            
        }        
    }
    class JsonDataProvider : IDataProvider
    {
        public DeviceInfo[] GetDevice()
        {
            DeviceInfo[] devInfo = JsonConvert.DeserializeObject<DeviceInfo[]>(File.ReadAllText("Devices.json"));
            return devInfo;
        }

        public void WriteWorksGroup(Conflict[] conflicts)
        {
            File.WriteAllText("Conflicts.json", JsonConvert.SerializeObject(conflicts));
        }
    }
    class DataProccesor : IDataProccesor
    {
        public void GetWorksGroup(IDataProvider dataProvider)
        {
            List<Conflict> listResults = new List<Conflict>();
            var resultGroup = from device in dataProvider.GetDevice()
                              group device by device.Brigade.Code into g
                              where g.Count() > 1
                              select g;
            foreach (IGrouping<string, DeviceInfo> brig in resultGroup)
            {
                Conflict conflict;
                int index = 0;
                int count = 0;
                conflict = new Conflict { BrigadeCode = brig.Key, DevicesSerials = new string[brig.Count()] };
                foreach (DeviceInfo numb in brig)
                {
                    if (numb.Device.IsOnline)
                        count++;

                    conflict.DevicesSerials[index] = numb.Device.SerialNumber;
                    index++;
                }
                if (count == 0)
                    continue;
                listResults.Add(conflict);

            }            
            dataProvider.WriteWorksGroup(listResults.ToArray());
        }
    }
}
