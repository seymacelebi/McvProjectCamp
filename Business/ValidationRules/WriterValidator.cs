using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("En Az 3 Karakter Girişi Yapın.");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("En Fazla 20 Karakter Girişi Yapın.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş geçilmez");
            // RuleFor(x => x.WriterAbout).Must("a").WithMessage("Hakkımda kısmında mutlaka a olmalı");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Hakkımda kısmı boş geçilmez");

        }
    }

}
