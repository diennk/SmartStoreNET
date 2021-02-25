using SmartStore.Collections;
using SmartStore.LMS.Security;
using SmartStore.Web.Framework.UI;
using System;
using System.Web;

namespace SmartStore.LMS
{
    public class AdminMenu : AdminMenuProvider
    {
        protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
            var xmlSiteMap = new Telerik.Web.Mvc.XmlSiteMap();
            xmlSiteMap.LoadFrom("~/Plugins/SmartStore.LMS/sitemap.config");

            var rootNode = ConvertSitemapNodeToMenuItemNode(xmlSiteMap.RootNode);

            pluginsNode.Parent.Append(rootNode);

            //var menuItem = new MenuItem().ToBuilder()
            //    .Text("LMS")
            //    .ResKey("Plugins.FriendlyName.SmartStore.LMS")
            //    .Icon("icm icm-icm icm-desktop navbar-icon")
            //    .Action("ConfigurePlugin", "Plugin", new { systemName = Plugin.SystemName, area = "Admin" })
            //    .PermissionNames(LMSPermissions.Read)
            //    .ToItem();

            ////if (!HttpContext.Current.Request.IsLocal)
            //{
            //    var removeIds = new string[] { "sales", "stores", "promotions" };
            //    removeIds.Each(x =>
            //    {
            //        pluginsNode.Parent.Remove(pluginsNode.Parent.SelectNodeById(x));
            //    });

            //}

            //var homeMenu = pluginsNode.Parent.SelectNodeById("dashboard");
            //var dashboard = homeMenu.Clone();
            //pluginsNode.Parent.Remove(homeMenu);

            //pluginsNode.Parent.Prepend(menuItem);
            //pluginsNode.Parent.Prepend(dashboard);

        }

        public override int Ordinal => 100;

        private TreeNode<MenuItem> ConvertSitemapNodeToMenuItemNode(Telerik.Web.Mvc.SiteMapNode node)
        {
            var item = new MenuItem();
            var root = new TreeNode<MenuItem>(item);

            var id = node.Attributes.ContainsKey("id")
                ? node.Attributes["id"] as string
                : string.Empty;

            root.Id = id;

            if (node.RouteName.HasValue())
            {
                item.RouteName = node.RouteName;
            }
            else if (node.ActionName.HasValue() && node.ControllerName.HasValue())
            {
                item.ActionName = node.ActionName;
                item.ControllerName = node.ControllerName;
            }
            else if (node.Url.HasValue())
            {
                item.Url = node.Url;
            }
            item.RouteValues = node.RouteValues;

            item.Id = id;
            item.Visible = node.Visible;
            item.Text = node.Title;
            item.Attributes.Merge(node.Attributes);

            if (node.Attributes.ContainsKey("permissionNames"))
            {
                item.PermissionNames = node.Attributes["permissionNames"] as string;
            }

            if (node.Attributes.ContainsKey("resKey"))
            {
                item.ResKey = node.Attributes["resKey"] as string;
            }

            if (node.Attributes.ContainsKey("iconClass"))
            {
                item.Icon = node.Attributes["iconClass"] as string;
            }

            if (node.Attributes.ContainsKey("imageUrl"))
            {
                item.ImageUrl = node.Attributes["imageUrl"] as string;
            }

            if (node.Attributes.ContainsKey("isGroupHeader"))
            {
                item.IsGroupHeader = Boolean.Parse(node.Attributes["isGroupHeader"] as string);
            }

            // Iterate children recursively.
            foreach (var childNode in node.ChildNodes)
            {
                var childTreeNode = ConvertSitemapNodeToMenuItemNode(childNode);
                root.Append(childTreeNode);
            }

            return root;
        }

    }
}
