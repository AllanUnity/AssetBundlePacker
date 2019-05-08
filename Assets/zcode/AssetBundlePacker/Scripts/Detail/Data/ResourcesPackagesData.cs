using System.Collections.Generic;

namespace GS.AssetBundlePacker
{
    /// <summary>资源包清单数据</summary>
    public class ResourcesPackagesData
    {
        /// <summary>资源包</summary>
        public class Package
        {
            public string Name;
            public List<string> AssetList = new List<string>();
        }
        /// <summary>包集合</summary>
        public Dictionary<string, Package> Packages = new Dictionary<string, Package>();
    }

    /// <summary>资源包</summary>
    public class ResourcesPackages
    {
        /// <summary>资源包数据</summary>
        public ResourcesPackagesData Data;

        public ResourcesPackages()
        {
            Data = new ResourcesPackagesData();
        }

        public bool Load(string file_name)
        {
            return SimpleJsonReader.ReadFromFile<ResourcesPackagesData>(ref Data, file_name);
        }
        public bool Save(string file_name)
        {
            return SimpleJsonWriter.WriteToFile(Data, file_name);
        }

        public ResourcesPackagesData.Package Find(string name)
        {
            if (Data == null)
                return null;

            ResourcesPackagesData.Package result;
            if (Data.Packages.TryGetValue(name, out result))
                return result;
            
            return null;
        }
    }
}

