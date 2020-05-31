using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Некорректный ввод")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [Display(Name = Constants.NameCompany)]
        public string Name { get; set; }
        public int Count { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Некорректный ввод")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [Display(Name =  Constants.Prefix)]
        public string Prefix { get; set; }
    }
}
