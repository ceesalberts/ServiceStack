using System;
using System.Collections.Generic;
using ServiceStack.Validation;
using @DomainModelNamespace@;

namespace @ServiceNamespace@.Logic.LogicCommands
{
	public class Store@ModelName@LogicCommand : LogicCommandBase<bool>
	{
		public @ModelName@ @ModelName@ { get; set; }

		public override bool Execute()
		{
			ThrowAnyValidationErrors(Validate());

			using (var transaction = Provider.BeginTransaction())
			{
				var db@ModelName@ = Provider.GetById<@ModelName@>(this.@ModelName@.Id);
				db@ModelName@.Id = this.@ModelName@.Id;
				Provider.Store(db@ModelName@);

				transaction.Commit();
			}

			return true;
		}


		public override ValidationResult Validate()
		{
			var errors = base.Validate().Errors;

			return new ValidationResult(errors, "@ModelName@ saved", "Could not save customer");
		}
	}
}