using SmartStore.Collections;
using SmartStore.Web.Framework.UI;

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

            pluginsNode.Parent.Prepend(menuItem);
        }

        public override int Ordinal => 100;

    }
}
