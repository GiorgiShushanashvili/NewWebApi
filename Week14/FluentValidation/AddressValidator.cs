using System;
using FluentValidation;
using Week14.Model;

namespace Week14.FluentValidation
{
	public class AddressValidator : AbstractValidator<Address>
	{
		


		public AddressValidator()
		{

			RuleFor(x => x.country).NotEmpty()
							.WithMessage("country cant be empty");
			RuleFor(x => x.city).NotEmpty()
				.WithMessage("city cant be empty");
			RuleFor(x => x.homenumber).NotEmpty()
				.WithMessage("homenumber cant be empty");



		} 
	}
}

