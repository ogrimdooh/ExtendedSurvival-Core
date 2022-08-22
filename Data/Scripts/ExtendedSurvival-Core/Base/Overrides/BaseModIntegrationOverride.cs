using Sandbox.ModAPI;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Core
{
    public abstract class BaseModIntegrationOverride : BaseIntegrationOverride
    {

        protected abstract ulong[] GetModId();
        protected abstract void OnSetDefinitions();

        protected virtual bool IsCustomCheckOk()
        {
            return false;
        }

        public override void SetDefinitions()
        {
            var ids = GetModId();
            if (ids.Length == 0 || MyAPIGateway.Session.Mods.Any(x => ids.Contains(x.PublishedFileId)) || IsCustomCheckOk())
            {
                OnSetDefinitions();
                OnAfterSetDefinitions();
            }
            else
                ExtendedSurvivalCoreLogging.Instance.LogInfo(GetType(), $"Override mod not found. ID=[{GetIds(ids)}]");
        }

        private string GetIds(ulong[] ids)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ids)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }

        protected virtual void OnAfterSetDefinitions()
        {

        }

    }

}