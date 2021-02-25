using SmartStore.Core.Domain.Customers;
using SmartStore.Core.Domain.Security;
using SmartStore.Core.Security;
using System.Collections.Generic;
using System.Linq;

namespace SmartStore.LMS.Security
{
    public static class LMSPermissions
    {
        public const string Self = "LMS";
        public const string Read = "LMS.read";
        public const string Update = "LMS.update";
        public const string Display = "LMS.display";
        public const string Edit = "LMS.edit";
    }


    public class LMSPermissionProvider : IPermissionProvider
    {
        public IEnumerable<PermissionRecord> GetPermissions()
        {
            var permissionSystemNames = PermissionHelper.GetPermissions(typeof(LMSPermissions));
            var permissions = permissionSystemNames.Select(x => new PermissionRecord { SystemName = x });

            return permissions;
        }

        public IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
        {
            return new[]
            {
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Administrators,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = LMSPermissions.Self }
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.ForumModerators,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = LMSPermissions.Display }
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Guests,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = LMSPermissions.Display }
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Registered,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = LMSPermissions.Display }
                    }
                }
            };
        }
    }
}