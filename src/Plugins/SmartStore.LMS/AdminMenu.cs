using SmartStore.Collections;
using SmartStore.Web.Framework.UI;
using System.Web;

namespace SmartStore.LMS
{
    public class AdminMenu : AdminMenuProvider
    {
        protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
            var menuItem = new MenuItem().ToBuilder()
                .Text("LMS")
                .ResKey("Plugins.FriendlyName.SmartStore.LMS")
                .Icon("icm icm-icm icm-desktop navbar-icon")
                .Action("ConfigurePlugin", "Plugin", new { systemName = Plugin.SystemName, area = "Admin" })
                .ToItem();

            //if (!HttpContext.Current.Request.IsLocal)
            {
                var removeIds = new string[] { "sales", "stores", "promotions" };
                removeIds.Each(x =>
                {
                    pluginsNode.Parent.Remove(pluginsNode.Parent.SelectNodeById(x));
                });
                
            }


            pluginsNode.Parent.Prepend(menuItem);
        }

        public override int Ordinal => 100;

    }
}
