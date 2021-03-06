﻿using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.OrderModule.Web.Security
{
    /// <summary>
    /// Scope bounded by order store
    /// </summary>
    public class OrderStoreScope : PermissionScope
    {
        public override bool IsScopeAvailableForPermission(string permission)
        {
            return permission == OrderPredefinedPermissions.Read ||
                   permission == OrderPredefinedPermissions.Update;
        }

        public override IEnumerable<string> GetEntityScopeStrings(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var customerOrder = entity as CustomerOrder;
            return customerOrder != null
                ? new[] { Type + ":" + customerOrder.StoreId }
                : Enumerable.Empty<string>();
        }
    }
}
