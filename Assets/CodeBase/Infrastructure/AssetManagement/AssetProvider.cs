using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private IAssetProvider assetProviderImplementation;
        private IAssetProvider assetProviderImplementation1;

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public Task<T> Load<T>(object spawner)
        {
            return assetProviderImplementation1.Load<T>(spawner);
        }
    }
}