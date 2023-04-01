using CvAPI.Application.ViewModels.Educations;
using FluentValidation;

namespace CvAPI.Application.Validators.Educations
{
    public class CreateEducationValidator : AbstractValidator<Vm_Create_Education>
    {
        public CreateEducationValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Başlık alanını boş geçmeyiniz.")
                .MaximumLength(300)
                .MinimumLength(10)
                    .WithMessage("Lütfen Başlık kısmını 10 ile 300 karakter arasında giriniz");

            RuleFor(p => p.SubTitle)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Bu kısmı boş geçmeyiniz.")
                .MaximumLength(300)
                .MinimumLength(10)
                    .WithMessage("Lütfen Başlık kısmını 10 ile 300 karakter arasında giriniz");

            RuleFor(p => p.SubTitle2)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen Bu kısmı boş geçmeyiniz.")
               .MaximumLength(300)
               .MinimumLength(10)
                   .WithMessage("Lütfen Başlık kısmını 10 ile 300 karakter arasında giriniz");


            RuleFor(p => p.GPA)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen Bu kısmı boş geçmeyiniz.");             

            RuleFor(p => p.Date)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen Bu kısmı boş geçmeyiniz.");
        }
    }
}
