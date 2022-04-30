using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Web.Models.Catalogs;

namespace Web.Validators
{
    public class CourseUpdateInputValidator:AbstractValidator<CourseUpdateInput>
    {
        public CourseUpdateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Olamaz");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Süre Alanı Boş Olamaz");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş Olamaz").ScalePrecision(2, 6)
                .WithMessage("Geçersiz Para Formatı");
        }
    }
}
