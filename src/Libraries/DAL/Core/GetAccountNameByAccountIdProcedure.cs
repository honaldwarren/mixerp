/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).
This file is part of MixERP.
MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
//Resharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using PetaPoco;
using MixERP.Net.Entities.Core;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Core.Data
{
	/// <summary>
	/// Prepares, validates, and executes the function "core.get_account_name_by_account_id(_account_id bigint)" on the database.
	/// </summary>
	public class GetAccountNameByAccountIdProcedure: DbAccess
	{
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
	    public override string ObjectNamespace => "core";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
	    public override string ObjectName => "get_account_name_by_account_id";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
		public long LoginId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Maps to "_account_id" argument of the function "core.get_account_name_by_account_id".
		/// </summary>
		public long AccountId { get; set; }

		/// <summary>
		/// Prepares, validates, and executes the function "core.get_account_name_by_account_id(_account_id bigint)" on the database.
		/// </summary>
		public GetAccountNameByAccountIdProcedure()
		{
		}

		/// <summary>
		/// Prepares, validates, and executes the function "core.get_account_name_by_account_id(_account_id bigint)" on the database.
		/// </summary>
		/// <param name="accountId">Enter argument value for "_account_id" parameter of the function "core.get_account_name_by_account_id".</param>
		public GetAccountNameByAccountIdProcedure(long accountId)
		{
			this.AccountId = accountId;
		}
		/// <summary>
		/// Prepares and executes the function "core.get_account_name_by_account_id".
		/// </summary>
		public string Execute()
		{
			if (!this.SkipValidation)
			{
				if (!this.Validated)
				{
					this.Validate(AccessTypeEnum.Execute, this.LoginId, false);
				}
				if (!this.HasAccess)
				{
                    Log.Information("Access to the function \"GetAccountNameByAccountIdProcedure\" was denied to the user with Login ID {LoginId}.", this.LoginId);
					throw new UnauthorizedException("Access is denied.");
				}
			}
			const string query = "SELECT * FROM core.get_account_name_by_account_id(@0::bigint);";
			return Factory.Scalar<string>(this.Catalog, query, this.AccountId);
		} 
	}
}