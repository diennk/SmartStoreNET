using SmartStore.Collections;
using SmartStore.Web.Framework.UI;

namespace SmartStore.Slider
{
    public class AdminMenu : AdminMenuProvider
    {
        protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
            var menuItem = new MenuItem().ToBuilder()
                .Text("Home Slider")
                .ResKey("Plugins.FriendlyName.SmartStore.Slider")
                .Icon("far fa-moon")
                .Action("ConfigurePlugin", "Plugin", new { systemName = "SmartStore.Slider", area = "Admin" })
                .ToItem();

            pluginsNode.Prepend(menuItem);
        }

        public override int Ordinal => 100;

    }
}
