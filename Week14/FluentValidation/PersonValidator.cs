using System;
using FluentValidation;
using Week14.FluentValidation;
using Week14.Model;

namespace Week14
{
	public class PersonValidator:AbstractValidator<Person>
	{
		public PersonValidator()
		{

            RuleFor(x => x.firstname).NotEmpty().Length(0, 50);
            RuleFor(x => x.lastname).NotEmpty().Length(0, 50);
            RuleFor(x => x.jobposition).NotEmpty().Length(0, 50);
            RuleFor(x => x.createtime).LessThan(DateTime.Now);
            RuleFor(x => x.salary).GreaterThan(0).LessThanOrEqualTo(10000);
            RuleFor(x => x.workexperience).NotEmpty();
            RuleFor(x => x.personaddress).SetValidator(new AddressValidator());




        }
	}
}

